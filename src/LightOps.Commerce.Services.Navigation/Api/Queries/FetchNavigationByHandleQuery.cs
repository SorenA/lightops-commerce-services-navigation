using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Navigation.Api.Queries
{
    public class FetchNavigationByHandleQuery : IQuery
    {
        public string Handle { get; set; }
    }
}