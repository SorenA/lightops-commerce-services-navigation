using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchNavigationsByIdsQueryHandler : IFetchNavigationsByIdsQueryHandler
    {
        private readonly IInMemoryNavigationProvider _inMemoryNavigationProvider;

        public FetchNavigationsByIdsQueryHandler(IInMemoryNavigationProvider inMemoryNavigationProvider)
        {
            _inMemoryNavigationProvider = inMemoryNavigationProvider;
        }
        
        public Task<IList<Proto.Types.Navigation>> HandleAsync(FetchNavigationsByIdsQuery query)
        {
            var navigations = _inMemoryNavigationProvider
                .Navigations?
                .Where(c => query.Ids.Contains(c.Id))
                .ToList();

            return Task.FromResult<IList<Proto.Types.Navigation>>(navigations ?? new List<Proto.Types.Navigation>());
        }
    }
}