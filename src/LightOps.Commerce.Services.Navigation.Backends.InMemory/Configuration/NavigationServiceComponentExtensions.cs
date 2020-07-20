﻿using System;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.QueryHandlers;
using LightOps.Commerce.Services.Navigation.Configuration;
using LightOps.DependencyInjection.Configuration;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Configuration
{
    public static class NavigationServiceComponentExtensions
    {
        public static INavigationServiceComponent UseInMemoryBackend(
            this INavigationServiceComponent serviceComponent,
            IDependencyInjectionRootComponent rootComponent,
            Action<IInMemoryNavigationServiceBackendComponent> componentConfig = null)
        {
            var component = new InMemoryNavigationServiceBackendComponent();

            // Invoke config delegate
            componentConfig?.Invoke(component);

            // Attach to root component
            rootComponent.AttachComponent(component);

            // Override query handlers
            serviceComponent
                .OverrideCheckNavigationHealthQueryHandler<CheckNavigationHealthQueryHandler>()
                .OverrideFetchNavigationByIdQueryHandler<FetchNavigationByIdQueryHandler>()
                .OverrideFetchNavigationsByIdsQueryHandler<FetchNavigationsByIdsQueryHandler>()
                .OverrideFetchNavigationsByHandlesQueryHandler<FetchNavigationsByHandlesQueryHandler>()
                .OverrideFetchNavigationByHandleQueryHandler<FetchNavigationByHandleQueryHandler>()
                .OverrideFetchNavigationsByParentIdQueryHandler<FetchNavigationsByParentIdQueryHandler>()
                .OverrideFetchNavigationsByParentIdsQueryHandler<FetchNavigationsByParentIdsQueryHandler>()
                .OverrideFetchNavigationsByRootQueryHandler<FetchNavigationsByRootQueryHandler>();

            return serviceComponent;
        }
    }
}
