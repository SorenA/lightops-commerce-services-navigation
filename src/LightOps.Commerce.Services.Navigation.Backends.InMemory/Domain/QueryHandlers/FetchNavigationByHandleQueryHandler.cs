using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchNavigationByHandleQueryHandler : IFetchNavigationByHandleQueryHandler
    {
        private readonly IInMemoryNavigationProvider _inMemoryNavigationProvider;

        public FetchNavigationByHandleQueryHandler(IInMemoryNavigationProvider inMemoryNavigationProvider)
        {
            _inMemoryNavigationProvider = inMemoryNavigationProvider;
        }

        public Task<INavigation> HandleAsync(FetchNavigationByHandleQuery query)
        {
            var navigation = _inMemoryNavigationProvider
                .Navigations
                .FirstOrDefault(c => c.Handle == query.Handle);

            return Task.FromResult(navigation);
        }
    }
}