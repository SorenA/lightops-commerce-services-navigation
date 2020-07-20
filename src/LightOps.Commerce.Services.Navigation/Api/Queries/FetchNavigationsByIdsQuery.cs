using System.Collections.Generic;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Navigation.Api.Queries
{
    public class FetchNavigationsByIdsQuery : IQuery
    {
        public IList<string> Ids { get; set; }
    }
}