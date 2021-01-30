using System.Collections.Generic;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Navigation.Api.QueryHandlers
{
    public interface IFetchNavigationsByHandlesQueryHandler : IQueryHandler<FetchNavigationsByHandlesQuery, IList<Proto.Types.Navigation>>
    {

    }
}