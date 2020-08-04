using System.Collections.Generic;
using System.Linq;
using LightOps.Commerce.Proto.Types;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Api.Services;
using LightOps.Commerce.Services.Navigation.Domain.Mappers;
using LightOps.Commerce.Services.Navigation.Domain.Services;
using LightOps.CQRS.Api.Queries;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Domain.Configuration;
using LightOps.Mapping.Api.Mappers;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Navigation.Configuration
{
    public class NavigationServiceComponent : IDependencyInjectionComponent, INavigationServiceComponent
    {
        public string Name => "lightops.commerce.services.navigation";

        public IReadOnlyList<ServiceRegistration> GetServiceRegistrations()
        {
            return new List<ServiceRegistration>()
                .Union(_services.Values)
                .Union(_mappers.Values)
                .Union(_queryHandlers.Values)
                .ToList();
        }

        #region Services
        internal enum Services
        {
            HealthService,
            NavigationService,
        }

        private readonly Dictionary<Services, ServiceRegistration> _services = new Dictionary<Services, ServiceRegistration>
        {
            [Services.HealthService] = ServiceRegistration.Transient<IHealthService, HealthService>(),
            [Services.NavigationService] = ServiceRegistration.Transient<INavigationService, NavigationService>(),
        };

        public INavigationServiceComponent OverrideHealthService<T>()
            where T : IHealthService
        {
            _services[Services.HealthService].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideNavigationService<T>()
            where T : INavigationService
        {
            _services[Services.NavigationService].ImplementationType = typeof(T);
            return this;
        }
        #endregion Services

        #region Mappers
        internal enum Mappers
        {
            NavigationProtoMapper,
            SubNavigationProtoMapper,
            NavigationLinkProtoMapper
        }

        private readonly Dictionary<Mappers, ServiceRegistration> _mappers = new Dictionary<Mappers, ServiceRegistration>
        {
            [Mappers.NavigationProtoMapper] = ServiceRegistration.Transient<IMapper<INavigation, NavigationProto>, NavigationProtoMapper>(),
            [Mappers.SubNavigationProtoMapper] = ServiceRegistration.Transient<IMapper<ISubNavigation, SubNavigationProto>, SubNavigationProtoMapper>(),
            [Mappers.NavigationLinkProtoMapper] = ServiceRegistration.Transient<IMapper<INavigationLink, NavigationLinkProto>, NavigationLinkProtoMapper>(),
        };

        public INavigationServiceComponent OverrideNavigationProtoMapper<T>() where T : IMapper<INavigation, NavigationProto>
        {
            _mappers[Mappers.NavigationProtoMapper].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideSubNavigationProtoMapper<T>() where T : IMapper<ISubNavigation, SubNavigationProto>
        {
            _mappers[Mappers.SubNavigationProtoMapper].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideNavigationLinkProtoMapper<T>() where T : IMapper<INavigationLink, NavigationLinkProto>
        {
            _mappers[Mappers.NavigationLinkProtoMapper].ImplementationType = typeof(T);
            return this;
        }
        #endregion Mappers

        #region Query Handlers
        internal enum QueryHandlers
        {
            CheckNavigationHealthQueryHandler,

            FetchNavigationsByHandlesQueryHandler,
            FetchNavigationsByIdsQueryHandler,
        }

        private readonly Dictionary<QueryHandlers, ServiceRegistration> _queryHandlers = new Dictionary<QueryHandlers, ServiceRegistration>
        {
            [QueryHandlers.CheckNavigationHealthQueryHandler] = ServiceRegistration.Transient<IQueryHandler<CheckNavigationHealthQuery, HealthStatus>>(),

            [QueryHandlers.FetchNavigationsByHandlesQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchNavigationsByHandlesQuery, IList<INavigation>>>(),
            [QueryHandlers.FetchNavigationsByIdsQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchNavigationsByIdsQuery, IList<INavigation>>>(),
        };

        public INavigationServiceComponent OverrideCheckNavigationHealthQueryHandler<T>() where T : ICheckNavigationHealthQueryHandler
        {
            _queryHandlers[QueryHandlers.CheckNavigationHealthQueryHandler].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideFetchNavigationsByHandlesQueryHandler<T>() where T : IFetchNavigationsByHandlesQueryHandler
        {
            _queryHandlers[QueryHandlers.FetchNavigationsByHandlesQueryHandler].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideFetchNavigationsByIdsQueryHandler<T>() where T : IFetchNavigationsByIdsQueryHandler
        {
            _queryHandlers[QueryHandlers.FetchNavigationsByIdsQueryHandler].ImplementationType = typeof(T);
            return this;
        }
        #endregion Query Handlers
    }
}