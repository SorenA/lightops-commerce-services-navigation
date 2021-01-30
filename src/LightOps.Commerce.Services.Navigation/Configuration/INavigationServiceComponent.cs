using LightOps.Commerce.Services.Navigation.Api.CommandHandlers;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;

namespace LightOps.Commerce.Services.Navigation.Configuration
{
    public interface INavigationServiceComponent
    {
        #region Query Handlers
        INavigationServiceComponent OverrideCheckNavigationServiceHealthQueryHandler<T>() where T : ICheckNavigationServiceHealthQueryHandler;

        INavigationServiceComponent OverrideFetchNavigationsByHandlesQueryHandler<T>() where T : IFetchNavigationsByHandlesQueryHandler;
        INavigationServiceComponent OverrideFetchNavigationsByIdsQueryHandler<T>() where T : IFetchNavigationsByIdsQueryHandler;
        #endregion Query Handlers

        #region Command Handlers
        INavigationServiceComponent OverridePersistNavigationCommandHandler<T>() where T : IPersistNavigationCommandHandler;
        INavigationServiceComponent OverrideDeleteNavigationCommandHandler<T>() where T : IDeleteNavigationCommandHandler;
        #endregion Command Handlers
    }
}