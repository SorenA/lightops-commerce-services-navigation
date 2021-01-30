using System.Collections.Generic;
using System.Linq;
using LightOps.Commerce.Services.Navigation.Api.CommandHandlers;
using LightOps.Commerce.Services.Navigation.Api.Commands;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.CQRS.Api.Commands;
using LightOps.CQRS.Api.Queries;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Domain.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Navigation.Configuration
{
    public class NavigationServiceComponent : IDependencyInjectionComponent, INavigationServiceComponent
    {
        public string Name => "lightops.commerce.services.navigation";

        public IReadOnlyList<ServiceRegistration> GetServiceRegistrations()
        {
            return new List<ServiceRegistration>()
                .Union(_queryHandlers.Values)
                .Union(_commandHandlers.Values)
                .ToList();
        }

        #region Query Handlers
        internal enum QueryHandlers
        {
            CheckNavigationServiceHealthQueryHandler,

            FetchNavigationsByHandlesQueryHandler,
            FetchNavigationsByIdsQueryHandler,
        }

        private readonly Dictionary<QueryHandlers, ServiceRegistration> _queryHandlers = new Dictionary<QueryHandlers, ServiceRegistration>
        {
            [QueryHandlers.CheckNavigationServiceHealthQueryHandler] = ServiceRegistration.Transient<IQueryHandler<CheckNavigationServiceHealthQuery, HealthStatus>>(),

            [QueryHandlers.FetchNavigationsByHandlesQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchNavigationsByHandlesQuery, IList<Proto.Types.Navigation>>>(),
            [QueryHandlers.FetchNavigationsByIdsQueryHandler] = ServiceRegistration.Transient<IQueryHandler<FetchNavigationsByIdsQuery, IList<Proto.Types.Navigation>>>(),
        };

        public INavigationServiceComponent OverrideCheckNavigationServiceHealthQueryHandler<T>() where T : ICheckNavigationServiceHealthQueryHandler
        {
            _queryHandlers[QueryHandlers.CheckNavigationServiceHealthQueryHandler].ImplementationType = typeof(T);
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

        #region Command Handlers
        internal enum CommandHandlers
        {
            PersistNavigationCommandHandler,
            DeleteNavigationCommandHandler,
        }

        private readonly Dictionary<CommandHandlers, ServiceRegistration> _commandHandlers = new Dictionary<CommandHandlers, ServiceRegistration>
        {
            [CommandHandlers.PersistNavigationCommandHandler] = ServiceRegistration.Transient<ICommandHandler<PersistNavigationCommand>>(),
            [CommandHandlers.DeleteNavigationCommandHandler] = ServiceRegistration.Transient<ICommandHandler<DeleteNavigationCommand>>(),
        };

        public INavigationServiceComponent OverridePersistNavigationCommandHandler<T>() where T : IPersistNavigationCommandHandler
        {
            _commandHandlers[CommandHandlers.PersistNavigationCommandHandler].ImplementationType = typeof(T);
            return this;
        }

        public INavigationServiceComponent OverrideDeleteNavigationCommandHandler<T>() where T : IDeleteNavigationCommandHandler
        {
            _commandHandlers[CommandHandlers.DeleteNavigationCommandHandler].ImplementationType = typeof(T);
            return this;
        }
        #endregion Command Handlers
    }
}