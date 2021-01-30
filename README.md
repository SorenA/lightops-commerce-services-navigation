# LightOps Commerce - Navigation Service

Microservice for navigations.

Defines navigations and navigation links.  
Uses CQRS to fetch entities from data-source without defining any.  
Provides gRPC services for integrations into other services.

![Nuget](https://img.shields.io/nuget/v/LightOps.Commerce.Services.Navigation)

| Branch | CI |
| --- | --- |
| master | ![Build Status](https://dev.azure.com/sorendev/LightOps%20Commerce/_apis/build/status/LightOps.Commerce.Services.Navigation?branchName=master) |
| develop | ![Build Status](https://dev.azure.com/sorendev/LightOps%20Commerce/_apis/build/status/LightOps.Commerce.Services.Navigation?branchName=develop) |

## gRPC services

Protobuf service definitions located at [SorenA/lightops-commerce-proto](https://github.com/SorenA/lightops-commerce-proto).

Navigation is implemented in `Domain.GrpcServices.NavigationGrpcService`.

Health is implemented in `Domain.GrpcServices.HealthGrpcService`.

### Health-check

Health-checks conforms to the [GRPC Health Checking Protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md)

Available services are as follows

```bash
service = '' - System as a whole
service = 'lightops.service.NavigationService' - Navigation
```

For embedding a gRPC client for use with Kubernetes, see [grpc-ecosystem/grpc-health-probe](https://github.com/grpc-ecosystem/grpc-health-probe)

## Samples

A sample application hosting the gRPC service with mock data is available in the `samples/Sample.NavigationService` project.

## Requirements

LightOps packages available on NuGet:

- `LightOps.DependencyInjection`
- `LightOps.CQRS`

## Using the service component

Register during startup through the `AddNavigationService(options)` extension on `IDependencyInjectionRootComponent`.

```csharp
services.AddLightOpsDependencyInjection(root =>
{
    root
        .AddCqrs()
        .AddNavigationService(service =>
        {
            // Configure service
            // ...
        });
});

services.AddGrpc();
```

Register gRPC services for integrations.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<NavigationGrpcService>();
    endpoints.MapGrpcService<HealthGrpcService>();

    // Map other endpoints...
});
```

The gRPC services use `ICommandDispatcher` & `IQueryDispatcher` from the `LightOps.CQRS` package to dispatch commands and queries, see configuration bellow.

### Configuration options

A component backend is required, implementing the command & query handlers tied to a data-source, see configuration overridables bellow.

A custom backend, or one of the following standard backends can be used:

- InMemory

### Overridables

Using the `INavigationServiceComponent` configuration, the following can be overridden:

```csharp
public interface INavigationServiceComponent
{
    #region Query Handlers
    INavigationServiceComponent OverrideCheckNavigationServiceHealthQueryHandler<T>() where T : ICheckNavigationServiceHealthQueryHandler;

    INavigationServiceComponent OverrideFetchNavigationsByHandlesQueryHandler<T>() where T : IFetchNavigationsByHandlesQueryHandler;
    INavigationServiceComponent OverrideFetchNavigationsByIdsQueryHandler<T>() where T : IFetchNavigationsByIdsQueryHandler;
    #endregion Query Handlers

    #region Command Handlers
    INavigationServiceComponent OverridePersistNavigationCommandHandler<T>() where T : IPersistNavigationCommandHandler;
    INavigationServiceComponent OverrideDeleteNavigationCommandHandler<T>() where T : IDeleteNavigationCommandHandler;
    #endregion Command Handlers
}
```

## Backend modules

### In-Memory

Register during startup through the `UseInMemoryBackend(root, options)` extension on `INavigationServiceComponent`.

```csharp
root.AddNavigationService(service =>
{
    service.UseInMemoryBackend(root, backend =>
    {
        var navigations = new List<Navigation>();
        // ...

        backend.UseNavigations(navigations);
    });

    // Configure service
    // ...
});
```
