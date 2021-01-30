using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.CQRS.Api.Queries;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Navigation.Api.QueryHandlers
{
    public interface ICheckNavigationServiceHealthQueryHandler : IQueryHandler<CheckNavigationServiceHealthQuery, HealthStatus>
    {

    }
}