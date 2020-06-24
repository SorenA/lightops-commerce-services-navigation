using System.Collections.Generic;
using System.Linq;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.Providers;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Domain.Configuration;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Configuration
{
    public class InMemoryNavigationServiceBackendComponent : IDependencyInjectionComponent, IInMemoryNavigationServiceBackendComponent
    {
        public string Name => "lightops.commerce.services.navigation.backend.in-memory";

        public IReadOnlyList<ServiceRegistration> GetServiceRegistrations()
        {
            // Populate in-memory providers
            _providers[Providers.InMemoryNavigationProvider].ImplementationInstance = new InMemoryNavigationProvider
            {
                Navigations = _navigations,
            };

            return new List<ServiceRegistration>()
                .Union(_providers.Values)
                .ToList();
        }

        #region Entities
        private readonly IList<INavigation> _navigations = new List<INavigation>();

        public IInMemoryNavigationServiceBackendComponent UseNavigations(IList<INavigation> navigations)
        {
            foreach (var navigation in navigations)
            {
                _navigations.Add(navigation);
            }

            return this;
        }
        #endregion Entities

        #region Providers
        internal enum Providers
        {
            InMemoryNavigationProvider,
        }

        private readonly Dictionary<Providers, ServiceRegistration> _providers = new Dictionary<Providers, ServiceRegistration>()
        {
            [Providers.InMemoryNavigationProvider] = ServiceRegistration.Singleton<IInMemoryNavigationProvider>(),
        };
        #endregion Providers
    }
}