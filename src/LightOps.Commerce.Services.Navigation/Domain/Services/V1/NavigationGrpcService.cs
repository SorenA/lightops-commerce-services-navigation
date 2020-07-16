using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using LightOps.Commerce.Proto.Services.Navigation.V1;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Services;
using LightOps.Mapping.Api.Services;
using Microsoft.Extensions.Logging;

namespace LightOps.Commerce.Services.Navigation.Domain.Services.V1
{
    public class NavigationGrpcService : ProtoNavigationService.ProtoNavigationServiceBase
    {
        private readonly ILogger<NavigationGrpcService> _logger;
        private readonly INavigationService _navigationService;
        private readonly IMappingService _mappingService;

        public NavigationGrpcService(
            ILogger<NavigationGrpcService> logger,
            INavigationService navigationService,
            IMappingService mappingService)
        {
            _logger = logger;
            _navigationService = navigationService;
            _mappingService = mappingService;
        }

        public override async Task<ProtoGetNavigationResponse> GetNavigation(ProtoGetNavigationRequest request, ServerCallContext context)
        {
            INavigation entity;
            switch (request.IdentifierCase)
            {
                case ProtoGetNavigationRequest.IdentifierOneofCase.Id:
                    entity = await _navigationService.GetByIdAsync(request.Id);
                    break;
                case ProtoGetNavigationRequest.IdentifierOneofCase.Handle:
                    entity = await _navigationService.GetByHandleAsync(request.Handle);
                    break;
                default:
                    throw new RpcException(new Status(StatusCode.InvalidArgument, "Missing identifier"));
            }

            var protoEntity = _mappingService.Map<INavigation, ProtoNavigation>(entity);

            var result = new ProtoGetNavigationResponse
            {
                Navigation = protoEntity,
            };

            return result;
        }

        public override async Task<GetNavigationsByIdResponse> GetNavigationsById(GetNavigationsByIdRequest request, ServerCallContext context)
        {
            var entities = await _navigationService.GetByIdAsync(request.Ids);
            var protoEntities = _mappingService.Map<INavigation, ProtoNavigation>(entities);

            var result = new GetNavigationsByIdResponse();
            result.Navigations.AddRange(protoEntities);

            return result;
        }

        public override async Task<GetNavigationsByHandleResponse> GetNavigationsByHandle(GetNavigationsByHandleRequest request, ServerCallContext context)
        {
            var entities = await _navigationService.GetByHandleAsync(request.Handles);
            var protoEntities = _mappingService.Map<INavigation, ProtoNavigation>(entities);

            var result = new GetNavigationsByHandleResponse();
            result.Navigations.AddRange(protoEntities);

            return result;
        }

        public override async Task<ProtoGetNavigationsByRootResponse> GetNavigationsByRoot(ProtoGetNavigationsByRootRequest request, ServerCallContext context)
        {
            var entities = await _navigationService.GetByRootAsync();
            var protoEntities = _mappingService.Map<INavigation, ProtoNavigation>(entities);

            var result = new ProtoGetNavigationsByRootResponse();
            result.Navigations.AddRange(protoEntities);

            return result;
        }

        public override async Task<ProtoGetNavigationsByParentIdResponse> GetNavigationsByParentId(ProtoGetNavigationsByParentIdRequest request, ServerCallContext context)
        {
            var entities = await _navigationService.GetByParentIdAsync(request.ParentId);
            var protoEntities = _mappingService.Map<INavigation, ProtoNavigation>(entities);

            var result = new ProtoGetNavigationsByParentIdResponse();
            result.Navigations.AddRange(protoEntities);

            return result;
        }
    }
}
