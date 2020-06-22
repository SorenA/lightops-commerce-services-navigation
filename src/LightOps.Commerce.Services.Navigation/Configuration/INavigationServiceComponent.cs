using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Api.Services;

namespace LightOps.Commerce.Services.Navigation.Configuration
{
    public interface INavigationServiceComponent
    {
        #region Services
        INavigationServiceComponent OverrideNavigationService<T>() where T : INavigationService;
        #endregion Services

        #region Query Handlers
        INavigationServiceComponent OverrideFetchNavigationsByParentIdQueryHandler<T>() where T : IFetchNavigationsByParentIdQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationsByRootQueryHandler<T>() where T : IFetchNavigationsByRootQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationByHandleQueryHandler<T>() where T : IFetchNavigationByHandleQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationByIdQueryHandler<T>() where T : IFetchNavigationByIdQueryHandler;
        #endregion Query Handlers
    }
}