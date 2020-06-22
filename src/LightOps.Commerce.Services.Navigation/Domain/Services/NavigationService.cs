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

        public Task<INavigation> GetByIdAsync(string id)
        {
            return _queryDispatcher.DispatchAsync<FetchNavigationByIdQuery, INavigation>(new FetchNavigationByIdQuery
            {
                Id = id,
            });
        }

        public Task<INavigation> GetByHandleAsync(string handle)
        {
            return _queryDispatcher.DispatchAsync<FetchNavigationByHandleQuery, INavigation>(new FetchNavigationByHandleQuery
            {
                Handle = handle,
            });
        }

        public Task<IList<INavigation>> GetByRootAsync()
        {
            return _queryDispatcher.DispatchAsync<FetchNavigationsByRootQuery, IList<INavigation>>(new FetchNavigationsByRootQuery());
        }

        public Task<IList<INavigation>> GetByParentIdAsync(string parentId)
        {
            return _queryDispatcher.DispatchAsync<FetchNavigationsByParentIdQuery, IList<INavigation>>(new FetchNavigationsByParentIdQuery
            {
                ParentId = parentId,
            });
        }
    }
}