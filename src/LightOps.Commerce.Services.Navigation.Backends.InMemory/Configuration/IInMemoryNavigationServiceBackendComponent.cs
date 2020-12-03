using System.Collections.Generic;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Configuration
{
    public interface IInMemoryNavigationServiceBackendComponent
    {
        #region Entities
        IInMemoryNavigationServiceBackendComponent UseNavigations(IList<INavigation> navigations);
        #endregion Entities

        #region Providers
        IInMemoryNavigationServiceBackendComponent OverrideNavigationProvider<T>() where T : IInMemoryNavigationProvider;
        #endregion Providers
    }
}