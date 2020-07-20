using System.Collections.Generic;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Navigation.Api.Queries
{
    public class FetchNavigationsByParentIdsQuery : IQuery
    {
        public IList<string> ParentIds { get; set; }
    }
}