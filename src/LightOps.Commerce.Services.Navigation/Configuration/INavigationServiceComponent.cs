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
        INavigationServiceComponent OverrideProtoNavigationMapperV1<T>() where T : IMapper<INavigation, Proto.Services.Navigation.V1.ProtoNavigation>;
        INavigationServiceComponent OverrideProtoNavigationLinkMapperV1<T>() where T : IMapper<INavigationLink, Proto.Services.Navigation.V1.ProtoNavigationLink>;
        #endregion Mappers

        #region Query Handlers
        INavigationServiceComponent OverrideCheckNavigationHealthQueryHandler<T>() where T : ICheckNavigationHealthQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationsByParentIdQueryHandler<T>() where T : IFetchNavigationsByParentIdQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationsByRootQueryHandler<T>() where T : IFetchNavigationsByRootQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationsByHandlesQueryHandler<T>() where T : IFetchNavigationsByHandlesQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationsByIdsQueryHandler<T>() where T : IFetchNavigationsByIdsQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationByHandleQueryHandler<T>() where T : IFetchNavigationByHandleQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationByIdQueryHandler<T>() where T : IFetchNavigationByIdQueryHandler;
        #endregion Query Handlers
    }
}