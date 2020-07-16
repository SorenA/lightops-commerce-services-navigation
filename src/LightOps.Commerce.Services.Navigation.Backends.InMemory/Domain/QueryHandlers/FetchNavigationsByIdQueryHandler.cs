using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchNavigationsByIdQueryHandler : IFetchNavigationsByIdQueryHandler
    {
        private readonly IInMemoryNavigationProvider _inMemoryNavigationProvider;

        public FetchNavigationsByIdQueryHandler(IInMemoryNavigationProvider inMemoryNavigationProvider)
        {
            _inMemoryNavigationProvider = inMemoryNavigationProvider;
        }
        
        public Task<IList<INavigation>> HandleAsync(FetchNavigationsByIdQuery query)
        {
            var navigations = _inMemoryNavigationProvider
                .Navigations
                .Where(c => query.Ids.Contains(c.Id))
                .ToList();

            return Task.FromResult<IList<INavigation>>(navigations);
        }
    }
}