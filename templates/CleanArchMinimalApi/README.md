# CleanArchMinimalApi

Quick start template for a .NET 7 Minimal API solution that follows Clean Architecture

This is an opinionated batteries included template

## What is included in the template

### Packages

- Mediatr
- Mapster
- Carter
- XUnit

### Features

- Central package versioning management
- Editorconfig for standardised styling
- CQRS enabled with abstractions in front of Mediatr
- Easy to setup and register Minimal API modules through Carter
  - Straightforward mediation of requests with Mediate[HTTPVerb] extensions methods
  - Thin Minimal API endpoints (logic starts inside the Mediatr handlers)
- Feature folder structure inside each layer for vertical slicing
