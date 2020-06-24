# LightOps Commerce - Navigation Service

Microservice for navigations.

Defines navigations and navigation links.  
Uses CQRS to fetch entities from data-source without defining any.  
Provides gRPC services for integrations into other services.

## gRPC services

Protobuf service definitions located at [SorenA/lightops-commerce-proto](https://github.com/SorenA/lightops-commerce-proto).

Navigation v1 is implemented in `Domain.Services.V1.NavigationGrpcService`.

Health v1 is implemented in `Domain.Services.V1.HealthGrpcService`.

### Health-check

Health-checks conforms to the [GRPC Health Checking Protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md)

Available services are as follows

```bash
service = '' - System as a whole
service = 'service.navigation.v1.ProtoNavigationService' - Navigation v1
```

For embedding a gRPC client for use with Kubernetes, see [grpc-ecosystem/grpc-health-probe](https://github.com/grpc-ecosystem/grpc-health-probe)

## Samples

A sample application hosting the gRPC service with mock data is available in the `samples/Sample.NavigationService` project.

## Requirements

LightOps packages available on NuGet:

- `LightOps.DependencyInjection`
- `LightOps.CQRS`
- `LightOps.Mapping`

## Using the service component

Register during startup through the `AddNavigationService(options)` extension on `IDependencyInjectionRootComponent`.

```csharp
services.AddLightOpsDependencyInjection(root =>
{
    root
        .AddMapping()
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

### Configuration options

A component backend is required, defining the query handlers tied to a data-source, see **Query handlers** section bellow for more.

A custom backend, or one of the following standard backends can be used:

- InMemory

### Overridables

Using the `INavigationServiceComponent` configuration, the following can be overridden:

```csharp
public interface INavigationServiceComponent
{
    #region Services
    INavigationServiceComponent OverrideHealthService<T>() where T : IHealthService;
    INavigationServiceComponent OverrideNavigationService<T>() where T : INavigationService;
    #endregion Services

    #region Mappers
    INavigationServiceComponent OverrideProtoNavigationMapperV1<T>() where T : IMapper<INavigation, Proto.Services.Navigation.V1.ProtoNavigation>;
    INavigationServiceComponent OverrideProtoNavigationLinkMapperV1<T>() where T : IMapper<INavigationLink, Proto.Services.Navigation.V1.ProtoNavigationLink>;
    #endregion Mappers

    #region Query Handlers
    INavigationServiceComponent OverrideCheckNavigationHealthQueryHandler<T>() where T : ICheckNavigationHealthQueryHandler;
    INavigationServiceComponent OverrideFetchNavigationsByParentIdQueryHandler<T>() where T : IFetchNavigationsByParentIdQueryHandler;
    INavigationServiceComponent OverrideFetchNavigationsByRootQueryHandler<T>() where T : IFetchNavigationsByRootQueryHandler;
    INavigationServiceComponent OverrideFetchNavigationByHandleQueryHandler<T>() where T : IFetchNavigationByHandleQueryHandler;
    INavigationServiceComponent OverrideFetchNavigationByIdQueryHandler<T>() where T : IFetchNavigationByIdQueryHandler;
    #endregion Query Handlers
}
```

`INavigationService` is used by the gRPC services and query the data using the `IQueryDispatcher` from the `LightOps.CQRS` package.

The mappers are used for mapping the internal data structure to the versioned protobuf messages.
