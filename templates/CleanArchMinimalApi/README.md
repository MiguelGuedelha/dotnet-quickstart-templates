# CleanArchMinimalApi

Quick start template for a .NET 7 Minimal API solution that follows Clean Architecture

This is a very opinionated, batteries included template

## What is included in the template

### Packages

- Mediatr
- Mapster
- Carter
- XUnit

### Features

- Central package versioning management
- Editorconfig for standardised styling
- CQRS enabled with abstractions in front of MediatR
  - Validation injected into pipeline
- Global exception/error handling middleware
- Easy to setup and register Minimal API modules through Carter
  - Straightforward mediation of requests with Mediate[HTTPVerb]<TRequest, TCommand|TQuery, TResponse> extensions methods
  - Thin Minimal API endpoints (logic starts inside the MediatR handlers)
