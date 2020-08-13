# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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

[unreleased]: https://github.com/SorenA/lightops-commerce-services-navigation/compare/0.4.0...develop
[0.4.0]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.4.0
[0.3.1]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.3.1
[0.3.0]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.3.0
[0.2.1]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.2.1
[0.2.0]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.2.0
[0.1.0]: https://github.com/SorenA/lightops-commerce-services-navigation/tree/0.1.0
