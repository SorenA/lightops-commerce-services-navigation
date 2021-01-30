using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.QueryHandlers
{
    public class CheckNavigationServiceHealthQueryHandler : ICheckNavigationServiceHealthQueryHandler
    {
        private readonly IInMemoryNavigationProvider _inMemoryNavigationProvider;

        public CheckNavigationServiceHealthQueryHandler(IInMemoryNavigationProvider inMemoryNavigationProvider)
        {
            _inMemoryNavigationProvider = inMemoryNavigationProvider;
        }

        public Task<HealthStatus> HandleAsync(CheckNavigationServiceHealthQuery query)
        {
            return _inMemoryNavigationProvider.Navigations != null
                ? Task.FromResult(HealthStatus.Healthy)
                : Task.FromResult(HealthStatus.Unhealthy);
        }
    }
}