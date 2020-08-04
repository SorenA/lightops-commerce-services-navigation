using System.Collections.Generic;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Navigation.Api.Queries
{
    public class FetchNavigationsByIdsQuery : IQuery
    {
        /// <summary>
        /// The ids of the navigations requested
        /// </summary>
        public IList<string> Ids { get; set; }
    }
}