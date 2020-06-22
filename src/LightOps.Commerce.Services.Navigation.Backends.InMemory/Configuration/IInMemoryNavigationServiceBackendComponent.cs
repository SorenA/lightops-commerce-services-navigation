using System.Collections.Generic;
using LightOps.Commerce.Services.Navigation.Api.Models;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Configuration
{
    public interface IInMemoryNavigationServiceBackendComponent
    {
        #region Entities
        IInMemoryNavigationServiceBackendComponent UseNavigations(IList<INavigation> navigations);
        #endregion Entities
    }
}