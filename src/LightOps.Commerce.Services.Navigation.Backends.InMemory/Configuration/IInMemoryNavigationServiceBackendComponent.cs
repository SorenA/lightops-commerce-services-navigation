using System.Collections.Generic;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Configuration
{
    public interface IInMemoryNavigationServiceBackendComponent
    {
        #region Entities
        IInMemoryNavigationServiceBackendComponent UseNavigations(IList<Proto.Types.Navigation> navigations);
        #endregion Entities

        #region Providers
        IInMemoryNavigationServiceBackendComponent OverrideNavigationProvider<T>() where T : IInMemoryNavigationProvider;
        #endregion Providers
    }
}