using System.Collections.Generic;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers
{
    public interface IInMemoryNavigationProvider
    {
        IList<Proto.Types.Navigation> Navigations { get; }
    }
}