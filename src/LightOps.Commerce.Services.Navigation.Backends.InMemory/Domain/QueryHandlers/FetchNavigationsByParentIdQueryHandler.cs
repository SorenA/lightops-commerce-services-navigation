using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchNavigationsByParentIdQueryHandler : IFetchNavigationsByParentIdQueryHandler
    {
        private readonly IInMemoryNavigationProvider _inMemoryNavigationProvider;

        public FetchNavigationsByParentIdQueryHandler(IInMemoryNavigationProvider inMemoryNavigationProvider)
        {
            _inMemoryNavigationProvider = inMemoryNavigationProvider;
        }
        
        public Task<IList<INavigation>> HandleAsync(FetchNavigationsByParentIdQuery query)
        {
            var navigations = _inMemoryNavigationProvider
                .Navigations
                .Where(c => c.ParentNavigationId == query.ParentId)
                .ToList();

            return Task.FromResult<IList<INavigation>>(navigations);
        }
    }
}