# CleanArchMinimalApi

Quick start template for a .NET 7 Minimal API solution that follows Clean Architecture

This is a very opinionated, batteries included template

---

## What is included in the template?

### Packages

- Mediatr
- Serilog
- StackExchange.Redis
- Fluent Validation
- Entity Framework (In-Memory DB -> To be switched out to preferred DBMS)
- Carter
- XUnit

### Features

- Central package versioning management
- Editorconfig for standardised styling
- CQRS enabled with abstractions in front of MediatR
    - Validation injected into pipeline
- Global exception/error handling middleware
- Easy to setup and register Minimal API modules through Carter
- Thin Minimal API endpoints with only mapping + mediator command/query calls

---

## Folder structure

The solution is modeled around clean architecture,
but with vertical/feature-based slicing inside of each project

Most of the projects look like a variation of this:

* Abstractions
    * Subfolders...
* Features
    * FeatureOne
        * Subfolders...
    * FeatureTwo
        * Subfolders...
* Shared
    * Subfolders...
* Options
    * Subfolders...

### Abstractions

The `Abstractions` folder contains any interfaces that are meant to be implemented by other layers
that have the current project as a dependency

### Features

The `Features` folder will contain the features of the application,
following vertical slicing while still maintaining the Clean Architecture project structure

These are replicated out across the different projects, so you always know where the relevant classes, etc
for a given feature are in each project

### Shared

The `Shared` folder is a place where you can put re-usable services, interfaces, middleware, exceptions
or any other cross-cutting concerns for that specific layer

The classes, records, etc found in this folder should be internal for the most part.

### Options

The `Options` folder is meant to contain any configuration classes that are meant to be registered
and used through the IOptions pattern

### Interfaces

Interfaces can either lie in the abstractions folder, if they are to be implemented by another layer,
or in the same namespace as the implementation, if the implementation is located in the same assembly/layer.

See
[IDateTimeService.cs](./src/CleanArchMinimalApi.Application/Shared/Services/IDateTimeService.cs)
and
[DateTimeService.cs](./src/CleanArchMinimalApi.Application/Shared/Services/DateTimeService.cs) for same assembly
organisation

See
[ICacheService.cs](./src/CleanArchMinimalApi.Application/Abstractions/Caching/ICacheService.cs)
and
[CacheService.cs](./src/CleanArchMinimalApi.Infrastructure/Shared/Caching/CacheService.cs) for different assembly
organisation

---

## Guidelines

* Unless a class needs to be visible in other layers, it should always be `internal` (or `private`) by default, instead
  of `public`
* Apart from classes that are meant to be inherited, all others should be `sealed`