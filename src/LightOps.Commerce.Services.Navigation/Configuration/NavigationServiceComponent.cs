using System.Collections.Generic;
using System.Linq;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Api.Services;
using LightOps.Commerce.Services.Navigation.Domain.Mappers;
using LightOps.CQRS.Api.Queries;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Domain.Configuration;
using LightOps.Mapping.Api.Mappers;

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
            [Services.NavigationService] = ServiceRegistration.Scoped<INavigationService, Domain.Services.NavigationService>(),
        };

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
            NavigationGrpcMapperV1,
            NavigationLinkGrpcMapperV1,
        }

        private readonly Dictionary<Mappers, ServiceRegistration> _mappers = new Dictionary<Mappers, ServiceRegistration>
        {
            [Mappers.NavigationGrpcMapperV1] = ServiceRegistration.Scoped<IMapper<INavigation, Proto.Services.Navigation.V1.Navigation>, NavigationGrpcMapperV1>(),
            [Mappers.NavigationLinkGrpcMapperV1] = ServiceRegistration.Scoped<IMapper<INavigationLink, Proto.Services.Navigation.V1.NavigationLink>, NavigationLinkGrpcMapperV1>(),
        };

        public INavigationServiceComponent OverrideNavigationGrpcMapperV1<T>() where T : IMapper<INavigation, Proto.Services.Navigation.V1.Navigation>
        {
            _mappers[Mappers.NavigationGrpcMapperV1].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideNavigationLinkGrpcMapperV1<T>() where T : IMapper<INavigationLink, Proto.Services.Navigation.V1.NavigationLink>
        {
            _mappers[Mappers.NavigationLinkGrpcMapperV1].ImplementationType = typeof(T);
            return this;
        }
        #endregion Mappers

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