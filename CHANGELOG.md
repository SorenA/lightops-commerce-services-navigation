# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.6.0] - 2021-02-20

### Changed

- **Breaking** - Change handles to localized strings

## [0.5.1] - 2021-01-31

### Changed

- **Breaking** - Change protobuf service namespace to prevent message clashes when using multiple services
- Fix grpc service implementation namespace typo

## [0.5.0] - 2021-01-30

### Added

- Persist and delete navigation commands
- In-memory backend persist and delete command handlers

### Changed

- **Breaking** - Migrated to .NET 5
- **Breaking** - Updated refactored and renamed service definition
- **Breaking** - Refactored health check query
- Use Protobuf generated models and services directly instead of mapping and re-implementing services, reduce code required by a lot

### Removed

- **Breaking** - Local entity interfaces, models and mappers, no longer needed
- **Breaking** - NavigationService and HealthService

## [0.4.1] - 2020-12-03

### Changed

- In-memory backend navigation provider made overridable on startup
- In-memory query handlers now support navigation collection being null

## [0.4.0] - 2020-08-11

### Changed

- **Breaking** - Updated refactored service definition
- **Breaking** - Removed deprecated queries, query handlers and service methods
- **Breaking** - Changed health-check service name

## [0.3.1] - 2020-07-21

### Fixed

- Null exeption in in-memory query handler for fetching by parent ids

## [0.3.0] - 2020-07-21

### Added

- Service endpoint, queryies and query handlers for fetching multiple navigations by parent ids

### Changed

- Service endpoint for fetching multiple navigations by ids or handles pluralized
- Queries and query handlers for fetching multiple navigations by ids or handles pluralized

## [0.2.1] - 2020-07-16

### Added

- Service endpoint for fetching multiple navigations by ids or handles
- Queries and query handlers for fetching multiple navigations by ids or handles

## [0.2.0] - 2020-07-04

### Changed

- Service lifespans changed to transient from scoped
- Query handler lifespan changed to transient from scoped
- Mapper lifespan changed to transient from scoped

## [0.1.0] - 2020-06-24

### Added

- CHANGELOG file
- README file describing project
- Azure Pipelines based CI/CD setup
- Navigation v1 gRPC server implementation and mappers
- Health v1 gRPC server implementation and mappers
- Navigation models
- Sample application with mock data
- Queries and query handlers for fetching data and running health-checks
- Navigation service using CQRS for data retrival
- Health service using CQRS for status checks
- In-memory backend providing default query handlers

[unreleased]: https://github.com/SorenA/lightops-commerce-services-navigation/compare/0.6.0...develop
[0.6.0]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.6.0
[0.5.1]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.5.1
[0.5.0]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.5.0
[0.4.1]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.4.1
[0.4.0]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.4.0
[0.3.1]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.3.1
[0.3.0]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.3.0
[0.2.1]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.2.1
[0.2.0]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.2.0
[0.1.0]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.1.0
