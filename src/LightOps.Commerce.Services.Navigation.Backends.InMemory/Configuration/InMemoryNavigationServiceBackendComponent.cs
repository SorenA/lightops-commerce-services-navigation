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
            return new List<ServiceRegistration>()
                .Union(_providers.Values)
                .ToList();
        }

        #region Entities
        public IInMemoryNavigationServiceBackendComponent UseNavigations(IList<INavigation> navigations)
        {
            // Populate in-memory providers
            _providers[Providers.InMemoryNavigationProvider].ImplementationType = null;
            _providers[Providers.InMemoryNavigationProvider].ImplementationInstance = new InMemoryNavigationProvider
            {
                Navigations = navigations,
            };

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
            [Providers.InMemoryNavigationProvider] = ServiceRegistration.Singleton<IInMemoryNavigationProvider, InMemoryNavigationProvider>(),
        };

        public IInMemoryNavigationServiceBackendComponent OverrideNavigationProvider<T>() where T : IInMemoryNavigationProvider
        {
            _providers[Providers.InMemoryNavigationProvider].ImplementationInstance = null;
            _providers[Providers.InMemoryNavigationProvider].ImplementationType = typeof(T);
            return this;
        }
        #endregion Providers
    }
}