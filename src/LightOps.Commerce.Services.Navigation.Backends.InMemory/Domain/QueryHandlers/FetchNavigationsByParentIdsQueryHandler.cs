﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.QueryHandlers
{
    public class FetchNavigationsByParentIdsQueryHandler : IFetchNavigationsByParentIdsQueryHandler
    {
        private readonly IInMemoryNavigationProvider _inMemoryNavigationProvider;

        public FetchNavigationsByParentIdsQueryHandler(IInMemoryNavigationProvider inMemoryNavigationProvider)
        {
            _inMemoryNavigationProvider = inMemoryNavigationProvider;
        }
        
        public Task<IList<INavigation>> HandleAsync(FetchNavigationsByParentIdsQuery query)
        {
            var navigations = _inMemoryNavigationProvider
                .Navigations
                .Where(c =>
                    !string.IsNullOrEmpty(c.ParentNavigationId)
                    && query.ParentIds.Contains(c.ParentNavigationId))
                .ToList();

            return Task.FromResult<IList<INavigation>>(navigations);
        }
    }
}