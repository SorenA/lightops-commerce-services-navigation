﻿using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Commerce.Services.Navigation.Api.Queries;
using LightOps.CQRS.Api.Queries;

namespace LightOps.Commerce.Services.Navigation.Api.QueryHandlers
{
    public interface IFetchNavigationByHandleQueryHandler : IQueryHandler<FetchNavigationByHandleQuery, INavigation>
    {

    }
}