using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.Commerce.Services.Navigation.Api.Services;
using LightOps.CQRS.Api.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Navigation.Domain.Services
{
    public class HealthService : IHealthService
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public HealthService(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public Task<HealthStatus> CheckNavigation()
        {
            return _queryDispatcher.DispatchAsync<CheckNavigationHealthQuery, HealthStatus>(new CheckNavigationHealthQuery());
        }
    }
}