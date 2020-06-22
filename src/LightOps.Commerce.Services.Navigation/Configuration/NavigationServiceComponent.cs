using System.Collections.Generic;
using System.Linq;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Api.Services;
using LightOps.Commerce.Services.Navigation.Domain.Services;
using LightOps.CQRS.Api.Queries;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Domain.Configuration;

namespace LightOps.Commerce.Services.Navigation.Configuration
{
    public class NavigationServiceComponent : IDependencyInjectionComponent, INavigationServiceComponent
    {
        public string Name => "lightops.commerce.services.navigation";

        public IReadOnlyList<ServiceRegistration> GetServiceRegistrations()
        {
            return new List<ServiceRegistration>()
                .Union(_services.Values)
                .Union(_queryHandlers.Values)
                .ToList();
        }

        #region Services
        internal enum Services
        {
            NavigationService,
        }

        private readonly Dictionary<Services, ServiceRegistration> _services = new Dictionary<Services, ServiceRegistration>
        {
            [Services.NavigationService] = ServiceRegistration.Scoped<INavigationService, NavigationService>(),
        };

        public INavigationServiceComponent OverrideNavigationService<T>()
            where T : INavigationService
        {
            _services[Services.NavigationService].ImplementationType = typeof(T);
            return this;
        }
        #endregion Services

        #region Query Handlers
        internal enum QueryHandlers
        {
            FetchNavigationsByParentIdQueryHandler,
            FetchNavigationsByRootQueryHandler,
            FetchNavigationByHandleQueryHandler,
            FetchNavigationByIdQueryHandler,
        }

        private readonly Dictionary<QueryHandlers, ServiceRegistration> _queryHandlers = new Dictionary<QueryHandlers, ServiceRegistration>
        {
            [QueryHandlers.FetchNavigationsByParentIdQueryHandler] = ServiceRegistration.Scoped<IQueryHandler<FetchNavigationsByParentIdQuery, IList<INavigation>>>(),
            [QueryHandlers.FetchNavigationsByRootQueryHandler] = ServiceRegistration.Scoped<IQueryHandler<FetchNavigationsByRootQuery, IList<INavigation>>>(),
            [QueryHandlers.FetchNavigationByHandleQueryHandler] = ServiceRegistration.Scoped<IQueryHandler<FetchNavigationByHandleQuery, INavigation>>(),
            [QueryHandlers.FetchNavigationByIdQueryHandler] = ServiceRegistration.Scoped<IQueryHandler<FetchNavigationByIdQuery, INavigation>>(),
        };

        public INavigationServiceComponent OverrideFetchNavigationsByParentIdQueryHandler<T>() where T : IFetchNavigationsByParentIdQueryHandler
        {
            _queryHandlers[QueryHandlers.FetchNavigationsByParentIdQueryHandler].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideFetchNavigationsByRootQueryHandler<T>() where T : IFetchNavigationsByRootQueryHandler
        {
            _queryHandlers[QueryHandlers.FetchNavigationsByRootQueryHandler].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideFetchNavigationByHandleQueryHandler<T>() where T : IFetchNavigationByHandleQueryHandler
        {
            _queryHandlers[QueryHandlers.FetchNavigationByHandleQueryHandler].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideFetchNavigationByIdQueryHandler<T>() where T : IFetchNavigationByIdQueryHandler
        {
            _queryHandlers[QueryHandlers.FetchNavigationByIdQueryHandler].ImplementationType = typeof(T);
            return this;
        }
        #endregion Query Handlers
    }
}