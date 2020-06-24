using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Navigation.Api.Queries
{
    public class FetchNavigationsByParentIdQuery : IQuery
    {
        public string ParentId { get; set; }
    }
}