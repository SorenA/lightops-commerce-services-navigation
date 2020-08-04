using LightOps.Commerce.Proto.Types;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Api.Services;
using LightOps.Mapping.Api.Mappers;

namespace LightOps.Commerce.Services.Navigation.Configuration
{
    public interface INavigationServiceComponent
    {
        #region Services
        INavigationServiceComponent OverrideHealthService<T>() where T : IHealthService;
        INavigationServiceComponent OverrideNavigationService<T>() where T : INavigationService;
        #endregion Services

        #region Mappers
        INavigationServiceComponent OverrideNavigationProtoMapper<T>() where T : IMapper<INavigation, NavigationProto>;
        INavigationServiceComponent OverrideSubNavigationProtoMapper<T>() where T : IMapper<ISubNavigation, SubNavigationProto>;
        INavigationServiceComponent OverrideNavigationLinkProtoMapper<T>() where T : IMapper<INavigationLink, NavigationLinkProto>;
        #endregion Mappers

        #region Query Handlers
        INavigationServiceComponent OverrideCheckNavigationHealthQueryHandler<T>() where T : ICheckNavigationHealthQueryHandler;

        INavigationServiceComponent OverrideFetchNavigationsByHandlesQueryHandler<T>() where T : IFetchNavigationsByHandlesQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationsByIdsQueryHandler<T>() where T : IFetchNavigationsByIdsQueryHandler;
        #endregion Query Handlers
    }
}