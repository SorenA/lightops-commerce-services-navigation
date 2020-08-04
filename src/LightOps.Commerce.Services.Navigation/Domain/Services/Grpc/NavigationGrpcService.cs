using System.Threading.Tasks;
using Grpc.Core;
using LightOps.Commerce.Proto.Services;
using LightOps.Commerce.Proto.Types;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Services;
using LightOps.Mapping.Api.Services;
using Microsoft.Extensions.Logging;

namespace LightOps.Commerce.Services.Navigation.Domain.Services.Grpc
{
    public class NavigationGrpcService : NavigationProtoService.NavigationProtoServiceBase
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

        public override async Task<GetNavigationsByHandlesProtoResponse> GetNavigationsByHandles(GetNavigationsByHandlesProtoRequest request, ServerCallContext context)
        {
            var entities = await _navigationService.GetByHandleAsync(request.Handles);
            var protoEntities = _mappingService.Map<INavigation, NavigationProto>(entities);

            var result = new GetNavigationsByHandlesProtoResponse();
            result.Navigations.AddRange(protoEntities);

            return result;
        }

        public override async Task<GetNavigationsByIdsProtoResponse> GetNavigationsByIds(GetNavigationsByIdsProtoRequest request, ServerCallContext context)
        {
            var entities = await _navigationService.GetByIdAsync(request.Ids);
            var protoEntities = _mappingService.Map<INavigation, NavigationProto>(entities);

            var result = new GetNavigationsByIdsProtoResponse();
            result.Navigations.AddRange(protoEntities);

            return result;
        }
    }
}
