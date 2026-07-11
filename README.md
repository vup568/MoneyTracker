# PersonalLifeOS

PersonalLifeOS is a finance-first personal life management system. Phase 1 focuses on a secure and usable personal-finance web application while keeping the architecture ready for future life-management modules.

## Solution structure

```text
src/
  PersonalLifeOS.Api/
  PersonalLifeOS.Application/
  PersonalLifeOS.Domain/
  PersonalLifeOS.Infrastructure/
  PersonalLifeOS.Web/
tests/
  PersonalLifeOS.UnitTests/
```

See [docs/ARCHITECTURE.md](docs/ARCHITECTURE.md) for responsibilities and dependency rules. See [P1_PRODUCT_PLAN.md](P1_PRODUCT_PLAN.md) for the active product plan.

## Local setup

The SQL Server connection string is intentionally not stored in tracked `appsettings.json` files. Configure it using .NET User Secrets:

```powershell
dotnet user-secrets set "ConnectionStrings:PersonalLifeOS" "<your-local-connection-string>" --project src/PersonalLifeOS.Api/PersonalLifeOS.Api.csproj
```

Build and test:

```powershell
dotnet build PersonalLifeOS.sln
dotnet test tests/PersonalLifeOS.UnitTests/PersonalLifeOS.UnitTests.csproj
```

Run the API and web client in separate terminals:

```powershell
dotnet run --project src/PersonalLifeOS.Api/PersonalLifeOS.Api.csproj --launch-profile https
dotnet run --project src/PersonalLifeOS.Web/PersonalLifeOS.Web.csproj --launch-profile https
```

The development URLs remain compatible with the original application:

- API Swagger: `https://localhost:7271/swagger`
- Web client: `https://localhost:7227`

## EF Core migrations

Migrations live in `PersonalLifeOS.Infrastructure`; `PersonalLifeOS.Api` is the startup project:

```powershell
dotnet ef migrations list --project src/PersonalLifeOS.Infrastructure/PersonalLifeOS.Infrastructure.csproj --startup-project src/PersonalLifeOS.Api/PersonalLifeOS.Api.csproj -- --environment Development
```

Always inspect a generated migration before applying it. Do not reset or drop the database without an explicit data decision and backup.
