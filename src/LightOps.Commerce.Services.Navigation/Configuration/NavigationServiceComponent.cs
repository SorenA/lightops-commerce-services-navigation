using System.Collections.Generic;
using System.Linq;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Api.Services;
using LightOps.Commerce.Services.Navigation.Domain.Mappers.V1;
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
            ProtoNavigationMapperV1,
            ProtoNavigationLinkMapperV1,
        }

        private readonly Dictionary<Mappers, ServiceRegistration> _mappers = new Dictionary<Mappers, ServiceRegistration>
        {
            [Mappers.ProtoNavigationMapperV1] = ServiceRegistration
                .Transient<IMapper<INavigation, Proto.Services.Navigation.V1.ProtoNavigation>, ProtoNavigationMapper>(),
            [Mappers.ProtoNavigationLinkMapperV1] = ServiceRegistration
                .Transient<IMapper<INavigationLink, Proto.Services.Navigation.V1.ProtoNavigationLink>, ProtoNavigationLinkMapper>(),
        };

        public INavigationServiceComponent OverrideProtoNavigationMapperV1<T>() where T : IMapper<INavigation, Proto.Services.Navigation.V1.ProtoNavigation>
        {
            _mappers[Mappers.ProtoNavigationMapperV1].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideProtoNavigationLinkMapperV1<T>() where T : IMapper<INavigationLink, Proto.Services.Navigation.V1.ProtoNavigationLink>
        {
            _mappers[Mappers.ProtoNavigationLinkMapperV1].ImplementationType = typeof(T);
            return this;
        }
        #endregion Mappers

        #region Query Handlers
        internal enum QueryHandlers
        {
            CheckNavigationHealthQueryHandler,
            FetchNavigationsByParentIdQueryHandler,
            FetchNavigationsByRootQueryHandler,
            FetchNavigationByHandleQueryHandler,
            FetchNavigationByIdQueryHandler,
        }

        private readonly Dictionary<QueryHandlers, ServiceRegistration> _queryHandlers = new Dictionary<QueryHandlers, ServiceRegistration>
        {
            [QueryHandlers.CheckNavigationHealthQueryHandler] = ServiceRegistration.Transient<IQueryHandler<CheckNavigationHealthQuery, HealthStatus>>(),
            [QueryHandlers.FetchNavigationsByParentIdQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchNavigationsByParentIdQuery, IList<INavigation>>>(),
            [QueryHandlers.FetchNavigationsByRootQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchNavigationsByRootQuery, IList<INavigation>>>(),
            [QueryHandlers.FetchNavigationByHandleQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchNavigationByHandleQuery, INavigation>>(),
            [QueryHandlers.FetchNavigationByIdQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchNavigationByIdQuery, INavigation>>(),
        };

        public INavigationServiceComponent OverrideCheckNavigationHealthQueryHandler<T>() where T : ICheckNavigationHealthQueryHandler
        {
            _queryHandlers[QueryHandlers.CheckNavigationHealthQueryHandler].ImplementationType = typeof(T);
            return this;
        }

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