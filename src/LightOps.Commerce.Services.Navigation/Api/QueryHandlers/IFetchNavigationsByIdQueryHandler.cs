using System.Collections.Generic;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Navigation.Api.QueryHandlers
{
    public interface IFetchNavigationsByIdQueryHandler : IQueryHandler<FetchNavigationsByIdQuery, IList<INavigation>>
    {

    }
}