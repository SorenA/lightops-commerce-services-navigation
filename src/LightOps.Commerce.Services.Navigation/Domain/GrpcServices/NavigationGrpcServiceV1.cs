using System.Threading.Tasks;
using Grpc.Core;
using LightOps.Commerce.Proto.Services.Navigation.V1;
using Microsoft.Extensions.Logging;

namespace LightOps.Commerce.Services.Navigation.Domain.GrpcServices
{
    public class NavigationGrpcServiceV1 : NavigationService.NavigationServiceBase
    {
        private readonly ILogger<NavigationGrpcServiceV1> _logger;

        public NavigationGrpcServiceV1(ILogger<NavigationGrpcServiceV1> logger)
        {
            _logger = logger;
        }

        public override Task<GetNavigationResponse> GetNavigation(GetNavigationRequest request, ServerCallContext context)
        {
            return base.GetNavigation(request, context);
        }

        public override Task<GetNavigationsByRootResponse> GetNavigationsByRoot(GetNavigationsByRootRequest request, ServerCallContext context)
        {
            return base.GetNavigationsByRoot(request, context);
        }

        public override Task<GetNavigationsByParentIdResponse> GetNavigationsByParentId(GetNavigationsByParentIdRequest request, ServerCallContext context)
        {
            return base.GetNavigationsByParentId(request, context);
        }
    }
}
