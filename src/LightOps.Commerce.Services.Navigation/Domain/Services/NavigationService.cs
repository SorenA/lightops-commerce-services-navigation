using System.Collections.Generic;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.Services;
using LightOps.CQRS.Api.Services;

namespace LightOps.Commerce.Services.Navigation.Domain.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public NavigationService(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public Task<IList<INavigation>> GetByHandleAsync(IList<string> handles)
        {
            return _queryDispatcher.DispatchAsync<FetchNavigationsByHandlesQuery, IList<INavigation>>(new FetchNavigationsByHandlesQuery
            {
                Handles = handles,
            });
        }

        public Task<IList<INavigation>> GetByIdAsync(IList<string> ids)
        {
            return _queryDispatcher.DispatchAsync<FetchNavigationsByIdsQuery, IList<INavigation>>(new FetchNavigationsByIdsQuery
            {
                Ids = ids,
            });
        }
    }
}