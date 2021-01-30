using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using LightOps.Commerce.Proto.Services;
using LightOps.Commerce.Services.Navigation.Api.Commands;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.CQRS.Api.Services;
using Microsoft.Extensions.Logging;

namespace LightOps.Commerce.Services.Navigation.Domain.GprcServices
{
    public class NavigationGrpcService : NavigationService.NavigationServiceBase
    {
        private readonly ILogger<NavigationGrpcService> _logger;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public NavigationGrpcService(
            ILogger<NavigationGrpcService> logger,
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public override async Task<PersistResponse> Persist(PersistRequest request, ServerCallContext context)
        {
            try
            {
                await _commandDispatcher.DispatchAsync(new PersistNavigationCommand
                {
                    Id = request.Id,
                    Navigation = request.Navigation,
                });

                return new PersistResponse
                {
                    StatusCode = PersistResponse.Types.StatusCode.Ok,
                };
            }
            catch (ArgumentException e)
            {
                _logger.LogError($"Failed persisting entity {request.Id}", e);
                return new PersistResponse
                {
                    StatusCode = PersistResponse.Types.StatusCode.Invalid,
                    Errors = { e.Message },
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed persisting entity {request.Id}", e);
            }

            return new PersistResponse
            {
                StatusCode = PersistResponse.Types.StatusCode.Unavailable,
            };
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            try
            {
                await _commandDispatcher.DispatchAsync(new DeleteNavigationCommand
                {
                    Id = request.Id,
                });

                return new DeleteResponse
                {
                    StatusCode = DeleteResponse.Types.StatusCode.Ok,
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed deleting entity {request.Id}", e);
            }

            return new DeleteResponse
            {
                StatusCode = DeleteResponse.Types.StatusCode.Unavailable,
            };
        }

        public override async Task<GetByHandlesResponse> GetByHandles(GetByHandlesRequest request, ServerCallContext context)
        {
            try
            {
                var entities = await _queryDispatcher.DispatchAsync<FetchNavigationsByHandlesQuery, IList<Proto.Types.Navigation>>(new FetchNavigationsByHandlesQuery
                {
                    Handles = request.Handles,
                });

                return new GetByHandlesResponse
                {
                    Navigations = { entities },
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed fetching by handles '{string.Join(",", request.Handles)}'", e);
            }

            return new GetByHandlesResponse();
        }

        public override async Task<GetByIdsResponse> GetByIds(GetByIdsRequest request, ServerCallContext context)
        {
            try
            {
                var entities = await _queryDispatcher.DispatchAsync<FetchNavigationsByIdsQuery, IList<Proto.Types.Navigation>>(new FetchNavigationsByIdsQuery
                {
                    Ids = request.Ids,
                });

                return new GetByIdsResponse
                {
                    Navigations = { entities },
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed fetching by ids '{string.Join(",", request.Ids)}'", e);
            }

            return new GetByIdsResponse();
        }
    }
}
