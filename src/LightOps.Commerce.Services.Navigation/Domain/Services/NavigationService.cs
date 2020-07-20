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

        public Task<IList<INavigation>> GetByIdAsync(IList<string> ids)
        {
            return _queryDispatcher.DispatchAsync<FetchNavigationsByIdsQuery, IList<INavigation>>(new FetchNavigationsByIdsQuery
            {
                Ids = ids,
            });
        }

        public Task<IList<INavigation>> GetByHandleAsync(IList<string> handles)
        {
            return _queryDispatcher.DispatchAsync<FetchNavigationsByHandlesQuery, IList<INavigation>>(new FetchNavigationsByHandlesQuery
            {
                Handles = handles,
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