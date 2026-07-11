# PersonalLifeOS Architecture

## Architecture style

PersonalLifeOS uses a **Clean Architecture lite modular monolith**. The architecture creates useful dependency boundaries without introducing microservices, CQRS, MediatR, or generic repositories before the domain requires them.

```text
PersonalLifeOS.Web  --->  PersonalLifeOS.Api
                              |
                              +---> PersonalLifeOS.Application ---> PersonalLifeOS.Domain
                              |
                              +---> PersonalLifeOS.Infrastructure ---> PersonalLifeOS.Application
                                             |
                                             +-----------------------> PersonalLifeOS.Domain
```

The API is the composition root: it starts the application and asks the Application and Infrastructure layers to register their services.

## Project responsibilities

### PersonalLifeOS.Domain

- Core entities, enums, value objects, and business rules.
- No dependency on EF Core, ASP.NET Core, SQL Server, or UI frameworks.
- Current reused finance entities: `Category`, `Transaction`, and `TransactionType`.

### PersonalLifeOS.Application

- Use-case contracts, DTOs, mapping, validation, and application service interfaces.
- Depends only on Domain plus small application-level libraries.
- Current reused code: finance DTOs and `MappingProfile`.

### PersonalLifeOS.Infrastructure

- EF Core `FinanceDbContext`, SQL Server provider, migrations, and future external adapters.
- Implements infrastructure required by Application/Domain.
- Owns migration assembly configuration.

### PersonalLifeOS.Api

- HTTP controllers, middleware pipeline, CORS, Swagger, and OData compatibility.
- Acts as the composition root through `AddApplication()` and `AddInfrastructure()`.
- Must not contain business rules or direct secrets.

### PersonalLifeOS.Web

- Server-rendered MVC web client and browser assets.
- Reuses the existing MVC controllers, ViewModels, Razor views, and Bootstrap assets.
- Calls the API through the existing named `HttpClient` while P1 evolves toward the secure browser-cookie/BFF flow.

### PersonalLifeOS.UnitTests

- Fast tests for Domain/Application rules.
- Starts with an architecture smoke test; P1 will add ownership, balance, transfer, and reporting tests.

## Reuse mapping from FinanceTracker

| Previous location | New location | Decision |
|---|---|---|
| `FinanceTracker/Models` | `PersonalLifeOS.Domain/Finance/Models` | Reused and namespace-cleaned. |
| `FinanceTracker/DTOs` | `PersonalLifeOS.Application/Finance/DTOs` | Reused; nullable contracts corrected. |
| `FinanceTracker/Mappings` | `PersonalLifeOS.Application/Finance/Mappings` | Reused; registration moved to Application DI. |
| `FinanceTracker/Data` | `PersonalLifeOS.Infrastructure/Persistence` | Reused as `FinanceDbContext`. |
| `FinanceTracker/Migrations` | `PersonalLifeOS.Infrastructure/Persistence/Migrations` | History preserved; no migration was regenerated. |
| `FinanceTracker/Controllers` | `PersonalLifeOS.Api/Controllers` | Reused; endpoint routes and behaviour preserved. |
| `FinanceTracker.MvcClient` | `PersonalLifeOS.Web` | Reused; views/assets were not rebuilt. |

## Dependency guardrails

1. Domain never references another solution project.
2. Application may reference Domain, but not Infrastructure, API, or Web.
3. Infrastructure may reference Application and Domain.
4. API may reference Application, Domain (temporary OData compatibility), and Infrastructure.
5. Web does not reference persistence or domain internals; it consumes API contracts.
6. New business rules belong in Domain/Application, not controllers.
7. EF Core migrations remain in Infrastructure and are reviewed before applying.

## Security configuration

- No SQL password is stored in tracked `appsettings.json`.
- Local connection strings use .NET User Secrets under key `ConnectionStrings:PersonalLifeOS`.
- Production must provide the same key through environment/secret management.
- P1-01 will add Identity, user data ownership, and secure web session handling.
