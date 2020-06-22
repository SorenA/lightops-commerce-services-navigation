using System.Collections.Generic;
using LightOps.Commerce.Services.Navigation.Api.Models;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers
{
    public interface IInMemoryNavigationProvider
    {
        IList<INavigation> Navigations { get; }
    }
}