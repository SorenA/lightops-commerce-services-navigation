using System.Collections.Generic;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.Providers
{
    public class InMemoryNavigationProvider : IInMemoryNavigationProvider
    {
        public IList<Proto.Types.Navigation> Navigations { get; internal set; } = new List<Proto.Types.Navigation>();
    }
}