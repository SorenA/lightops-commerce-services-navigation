using System.Collections.Generic;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.Providers
{
    public class InMemoryNavigationProvider : IInMemoryNavigationProvider
    {
        public IList<INavigation> Navigations { get; internal set; }
    }
}