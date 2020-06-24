using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LightOps.Commerce.Services.Navigation.Api.Services
{
    public interface IHealthService
    {
        Task<HealthStatus> CheckNavigation();
    }
}