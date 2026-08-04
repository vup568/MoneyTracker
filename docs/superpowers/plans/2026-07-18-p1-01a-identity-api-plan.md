# P1-01A: Identity and Protected API Implementation Plan

> **For learner-led implementation:** Work one task at a time. The learner writes the code first; the mentor reviews it before the next task. Do not implement a later task early.

**Goal:** Build and verify ASP.NET Core Identity, bearer-authenticated API access, and user-owned Category/Transaction data without introducing the MVC browser flow.

**Architecture:** `PersonalLifeOS.Domain` keeps only framework-independent finance and preference data. `PersonalLifeOS.Infrastructure` owns EF Core, ASP.NET Core Identity, password persistence, token creation, and mappings to Identity tables. `PersonalLifeOS.Api` is the composition root and HTTP boundary; it resolves the authenticated user from claims and delegates only defined application operations.

**Tech Stack:** .NET 8, ASP.NET Core Identity, EF Core 8 SQL Server, JWT bearer authentication, xUnit, Swagger.

## Global Constraints

- Work only on `feat/identity-foundation`; do not create a `codex/` branch.
- The existing development database is disposable, but the learner manually confirms the target connection before dropping or recreating it.
- JWT is permitted only for Swagger/Postman API learning in P1-01A; it must not be added to MVC browser JavaScript, local storage, or session storage.
- A record's owner comes only from the authenticated claim; no request DTO, route, or query value may select an owner.
- An ID owned by another user must behave as `404 Not Found`.
- Finish each task with review, test evidence, and a focused commit. Do not commit unrelated existing changes.

---

## File map

| Path | Responsibility |
|---|---|
| `src/PersonalLifeOS.Infrastructure/Identity/ApplicationUser.cs` | Identity user and only Identity-specific profile fields. |
| `src/PersonalLifeOS.Infrastructure/Persistence/FinanceDbContext.cs` | Identity-aware EF Core context and model mappings. |
| `src/PersonalLifeOS.Infrastructure/DependencyInjection.cs` | SQL Server, Identity, token/auth services registration. |
| `src/PersonalLifeOS.Domain/Finance/Models/Category.cs` | Framework-independent owner ID for a category. |
| `src/PersonalLifeOS.Domain/Finance/Models/Transaction.cs` | Framework-independent owner ID for a transaction. |
| `src/PersonalLifeOS.Domain/Users/*.cs` | Preference entity and constrained theme/language values. |
| `src/PersonalLifeOS.Application/Identity/*` | Auth request/response contracts and application-facing service contracts. |
| `src/PersonalLifeOS.Infrastructure/Identity/*Service.cs` | Identity and JWT implementation behind application contracts. |
| `src/PersonalLifeOS.Api/Controllers/AuthController.cs` | Anonymous register/login endpoints only. |
| `src/PersonalLifeOS.Api/Controllers/*Controller.cs` | `[Authorize]`, current-user resolution, and user-scoped finance operations. |
| `src/PersonalLifeOS.Api/Program.cs` | JWT authentication setup, middleware order, Swagger bearer support. |
| `src/PersonalLifeOS.Infrastructure/Persistence/Migrations/*` | Reviewed EF Core migration history. |
| `tests/PersonalLifeOS.IntegrationTests/*` | Authentication and two-user isolation tests. |

## Task 1: Identity foundation and model boundaries

**Files:**

- Modify: `src/PersonalLifeOS.Infrastructure/Identity/ApplicationUser.cs`
- Modify: `src/PersonalLifeOS.Infrastructure/Persistence/FinanceDbContext.cs`
- Modify: `src/PersonalLifeOS.Infrastructure/DependencyInjection.cs`
- Modify: `src/PersonalLifeOS.Domain/Users/ThemePreference.cs`
- Modify: `src/PersonalLifeOS.Domain/Users/LanguagePreference.cs`
- Modify: `src/PersonalLifeOS.Domain/Users/UserPreference.cs`
- Modify: `src/PersonalLifeOS.Infrastructure/PersonalLifeOS.Infrastructure.csproj`

**Produces:** an Identity-enabled context that can create Identity schema and a persisted preference model, without any HTTP auth endpoint yet.

- [ ] Read `IdentityDbContext<TUser>` documentation and explain, in your own words, why `FinanceDbContext` must inherit it instead of plain `DbContext`.
- [ ] Decide the minimum `ApplicationUser` fields: inherited Identity fields plus non-empty `DisplayName`; do not add roles or preference fields to this class.
- [ ] Model `ThemePreference` as exactly `System`, `Light`, `Dark`; model `LanguagePreference` as exactly `Auto`, `Vietnamese`, `English`.
- [ ] Model `UserPreference` with a string user ID, theme, language, `VND` currency default, and `Asia/Ho_Chi_Minh` timezone default. Keep it independent of `ApplicationUser` and Identity packages.
- [ ] Change the context base type to the generic Identity context, preserve Categories and Transactions DbSets, then call the Identity base model configuration before custom mappings.
- [ ] Configure one-to-one `ApplicationUser`/`UserPreference` in Infrastructure using a string foreign key; define a unique index on `UserPreference.UserId`.
- [ ] Run `dotnet build PersonalLifeOS.sln` and bring the changed files for review. Expected result: build succeeds; no migration is created in this task.
- [ ] After review, commit only Task 1 files with message `feat(identity): establish identity-aware persistence`.

## Task 2: Auth contracts, password rules, and token service

**Files:**

- Create: `src/PersonalLifeOS.Application/Identity/RegisterRequest.cs`
- Create: `src/PersonalLifeOS.Application/Identity/LoginRequest.cs`
- Create: `src/PersonalLifeOS.Application/Identity/AuthResponse.cs`
- Create: `src/PersonalLifeOS.Application/Identity/IAuthService.cs`
- Create: `src/PersonalLifeOS.Infrastructure/Identity/AuthService.cs`
- Create: `src/PersonalLifeOS.Infrastructure/Identity/JwtTokenService.cs`
- Modify: `src/PersonalLifeOS.Application/DependencyInjection.cs`
- Modify: `src/PersonalLifeOS.Infrastructure/DependencyInjection.cs`
- Modify: `src/PersonalLifeOS.Api/appsettings.json`
- Modify: `src/PersonalLifeOS.Api/appsettings.Development.json`
- Modify: `src/PersonalLifeOS.Api/PersonalLifeOS.Api.csproj`

**Consumes:** Task 1 `ApplicationUser`, `FinanceDbContext`, and Identity registration.

**Produces:** validated register/login operations. Registration creates a user and its default `UserPreference`; login returns an API-testing token with a stable user-ID claim.

- [ ] Define request DTO validation: email required and valid, display name required with an explicit maximum length, password required with no password property on responses.
- [ ] Define `AuthResponse` with token, expiration timestamp, and safe user identity fields only; never include a password, password hash, security stamp, or raw Identity error object.
- [ ] Define an application-facing authentication interface with explicit register and login asynchronous operations. Decide and document how validation/Identity failures are represented before coding its implementation.
- [ ] Configure Identity password requirements and lockout explicitly: require a non-alphanumeric character, digit, uppercase, lowercase; minimum length 8; lock out after 5 failed attempts for 15 minutes; allow lockout for new users.
- [ ] Configure JWT issuer, audience, signing key, and lifetime through configuration. Keep the development signing key outside tracked configuration using User Secrets; tracked files may contain only non-secret settings and key names.
- [ ] Implement registration so user creation and default preference creation either both succeed or return a failure; use `UserManager<ApplicationUser>` rather than custom password hashing.
- [ ] Implement login with `CheckPasswordSignInAsync(..., lockoutOnFailure: true)` or the equivalent Identity API, then issue a token only on success.
- [ ] Run the focused build and bring your DTO/interface/service code for review before creating the controller.
- [ ] After review, commit only Task 2 files with message `feat(identity): add auth service and token issuance`.

## Task 3: HTTP authentication boundary and Swagger verification

**Files:**

- Create: `src/PersonalLifeOS.Api/Controllers/AuthController.cs`
- Modify: `src/PersonalLifeOS.Api/Program.cs`
- Modify: `src/PersonalLifeOS.Api/PersonalLifeOS.Api.csproj`
- Modify: `src/PersonalLifeOS.Api/appsettings.Development.json`

**Consumes:** Task 2 `IAuthService`, DTOs, and JWT configuration.

**Produces:** anonymous register/login endpoints, JWT bearer authentication middleware, and Swagger authorization input.

- [ ] Make only `POST /api/auth/register` and `POST /api/auth/login` anonymous. Return clear validation/authentication failures without leaking whether an email exists during login.
- [ ] Configure `AddAuthentication().AddJwtBearer(...)` to validate issuer, audience, signing key, and token lifetime.
- [ ] Put `UseAuthentication()` before `UseAuthorization()` in the API pipeline.
- [ ] Add Swagger bearer security definition and requirement so the learner can authorize requests with `Bearer <token>`.
- [ ] Manually verify: register a new account; login; copy the token to Swagger; call a temporary authenticated diagnostic endpoint only if one is needed for learning, then remove it before Task 4.
- [ ] Verify incorrect credentials and repeated incorrect credentials follow the configured failure/lockout behavior.
- [ ] Bring the controller and `Program.cs` changes for review. Do not modify finance controllers yet.
- [ ] After review, commit only Task 3 files with message `feat(api): expose identity authentication endpoints`.

## Task 4: User ownership schema and reviewed migration

**Files:**

- Modify: `src/PersonalLifeOS.Domain/Finance/Models/Category.cs`
- Modify: `src/PersonalLifeOS.Domain/Finance/Models/Transaction.cs`
- Modify: `src/PersonalLifeOS.Infrastructure/Persistence/FinanceDbContext.cs`
- Create: `src/PersonalLifeOS.Infrastructure/Persistence/Migrations/<timestamp>_AddIdentityAndFinanceOwnership.cs`
- Modify: `src/PersonalLifeOS.Infrastructure/Persistence/Migrations/FinanceDbContextModelSnapshot.cs`

**Consumes:** Task 1 context and `ApplicationUser`.

**Produces:** a migration creating Identity tables and required `UserId` foreign keys/indexes for Category and Transaction.

- [ ] Add a required string `UserId` to both finance entities, but do not add a Domain navigation property to `ApplicationUser`.
- [ ] In Infrastructure Fluent configuration, map each user ID to `ApplicationUser`, make deletion restrictive, and add an index suitable for user-scoped list queries.
- [ ] Generate the migration with Infrastructure as the migrations project and API as startup project. Do not hand-edit generated migration before reading it.
- [ ] Review the migration line by line. Confirm it creates `AspNetUsers`/related Identity tables, adds non-null `UserId` columns, creates foreign keys/indexes, and does not unexpectedly drop unrelated objects.
- [ ] Confirm the configured connection string points to the disposable local development database. Then the learner manually drops/recreates that database and applies the reviewed migration.
- [ ] Run `dotnet ef migrations list` and a build. Bring the migration diff and command output for review.
- [ ] After review, commit only Task 4 files with message `feat(data): add identity and finance ownership schema`.

## Task 5: Current-user abstraction and Category isolation

**Files:**

- Create: `src/PersonalLifeOS.Application/Identity/ICurrentUser.cs`
- Create: `src/PersonalLifeOS.Api/Identity/HttpCurrentUser.cs`
- Modify: `src/PersonalLifeOS.Api/Program.cs`
- Modify: `src/PersonalLifeOS.Api/Controllers/CategoriesController.cs`
- Modify: `src/PersonalLifeOS.Application/Finance/DTOs/CategoryCreateDto.cs`
- Modify: `src/PersonalLifeOS.Application/Finance/DTOs/CategoryDto.cs`

**Consumes:** bearer-authenticated claims from Task 3 and required Category ownership from Task 4.

**Produces:** authenticated Category CRUD where all lookup, create, update, and delete operations are ownership-safe.

- [ ] Design `ICurrentUser` to expose only the required authenticated user ID; its API implementation must read the standard NameIdentifier claim and throw no data into request models.
- [ ] Add `[Authorize]` to the Category controller.
- [ ] List only `Categories` matching the current user ID; preserve OData learning features only if their query is applied after the ownership filter.
- [ ] On create, set `Category.UserId` on the server; do not add user ID to the create DTO.
- [ ] On get/update/delete, query by both `Id` and `UserId`; return `404` when no matching record exists.
- [ ] Preserve the existing DTO response shape; do not expose owner IDs in the browser-facing category response.
- [ ] Manually verify with two registered users: User A sees only A records, and an A request to User B's numeric ID receives 404.
- [ ] Bring your Category controller for review, then commit only Task 5 files with message `feat(finance): scope categories to current user`.

## Task 6: Transaction isolation and same-owner category rule

**Files:**

- Modify: `src/PersonalLifeOS.Api/Controllers/TransactionsController.cs`
- Modify: `src/PersonalLifeOS.Application/Finance/DTOs/TransactionCreateDto.cs`
- Modify: `src/PersonalLifeOS.Application/Finance/DTOs/TransactionDto.cs`

**Consumes:** `ICurrentUser`, protected Category behavior, and Transaction `UserId` from Tasks 4–5.

**Produces:** authenticated Transaction CRUD and validation that a transaction's category belongs to the same current user.

- [ ] Add `[Authorize]` to the Transaction controller.
- [ ] For create, require positive amount, load the selected category using both category ID and current user ID, assign transaction user ID server-side, and return `404` for another user's category.
- [ ] For all list and single-item reads, filter transactions by current user ID before loading the category.
- [ ] For update, first load the transaction by ID/current user ID, then validate the replacement category with ID/current user ID before changing tracked fields.
- [ ] For delete, delete only a transaction fetched by ID/current user ID.
- [ ] Retain the existing income/expense enum behavior. Do not add Account or Transfer concepts; those belong to P1-02.
- [ ] Manually verify all four operations with two users and both same-owner and cross-owner category IDs.
- [ ] Bring the transaction controller for review, then commit only Task 6 files with message `feat(finance): scope transactions to current user`.

## Task 7: Automated verification and project tracking

**Files:**

- Create: `tests/PersonalLifeOS.IntegrationTests/PersonalLifeOS.IntegrationTests.csproj`
- Create: `tests/PersonalLifeOS.IntegrationTests/CustomWebApplicationFactory.cs`
- Create: `tests/PersonalLifeOS.IntegrationTests/AuthAndOwnershipTests.cs`
- Modify: `PersonalLifeOS.sln`
- Modify: `PROJECT_TRACKING.md`
- Modify: `BACKLOG.md`
- Modify: `DEVLOG.md`
- Modify: `README.md`

**Consumes:** all P1-01A endpoint and schema behavior.

**Produces:** repeatable evidence for registration, authentication, ownership isolation, and updated project state.

- [ ] Create a test host with an isolated database configuration; tests must never point to the developer's local SQL Server database.
- [ ] Add a test that anonymous `GET /api/categories` returns 401.
- [ ] Add a two-user test: register/login User A and User B, create a Category as A, request that category as B, and assert 404.
- [ ] Add a transaction test: create an A category, attempt to create a B transaction using A's category ID, and assert 404.
- [ ] Add a failed-login/lockout test matching the configured policy and time behavior; use deterministic configuration where necessary so the test does not sleep for 15 minutes.
- [ ] Run `dotnet test PersonalLifeOS.sln`; save the command and result in the DEVLOG entry.
- [ ] Update tracking to mark P1-01A done and P1-01B next. Document local secrets, API test flow, and the explicit rule that browser token storage remains forbidden.
- [ ] Bring the tests and documentation for final review, then commit only Task 7 files with message `test(identity): verify authentication and ownership isolation`.

## Plan self-review

- Spec coverage: Tasks 1–4 cover Identity, preferences, migration, and disposable-data policy; Tasks 2–3 cover register/login, password policy, lockout, and testing token; Tasks 5–6 cover user-scoped authorization; Task 7 covers all stated acceptance checks and project documentation.
- Scope: MVC cookie/BFF, roles, password reset, and P1-02 domain work are explicitly excluded.
- Type consistency: Domain uses string `UserId`; the claim, `ApplicationUser.Id`, EF foreign keys, and current-user abstraction use the same string identifier.
