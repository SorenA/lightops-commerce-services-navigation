using System.Collections.Generic;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Navigation.Api.Queries
{
    public class FetchNavigationsByHandlesQuery : IQuery
    {
        public IList<string> Handles { get; set; }
    }
}