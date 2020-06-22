using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Navigation.Api.Queries
{
    public class FetchNavigationByIdQuery : IQuery
    {
        public string Id { get; set; }
    }
}