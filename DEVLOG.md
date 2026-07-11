# Development Log

## 2026-07-11

### Product and architecture decisions

* Product technical name will become `PersonalLifeOS`; Finance is its first bounded module.
* P1 is a web-first finance MVP, not a full life-management system yet.
* Use Clean Architecture lite and a modular monolith; avoid premature microservices, CQRS, MediatR, and generic repository abstractions.
* Continue EF Core Code First with explicit reviewed migrations committed to source control.
* Use ASP.NET Core Identity for basic registration/login/logout. Email/SMS verification and password reset are deferred to P1.1.
* Browser holds only a secure HTTP-only session cookie. JWT must not be available to JavaScript or browser storage.
* All personal finance data must be owned and filtered by `UserId`.
* P1 investment support is manual VND value only; no live quote, P&L, private exchange/broker API, or trading action.
* P1 review is user-triggered and rule-based first. AI cannot silently modify data.
* Theme preference is System/Light/Dark; language preference is Auto/Vietnamese/English and persists per user.

### Planning completed

* Created `P1_PRODUCT_PLAN.md` as the P1 product, architecture, and delivery source of truth.
* Replaced the legacy linear stage plan in `PROJECT_TRACKING.md` and `BACKLOG.md` with the ordered P1 backlog.

### Next session

* P1-01 only: design the Identity, user ownership, browser session, and data migration slice before implementation.

### P1-00 completed

* Renamed the solution and host projects to `PersonalLifeOS`.
* Introduced Domain, Application, Infrastructure, Api, Web, and UnitTests project boundaries.
* Reused and moved the existing Category/Transaction API and MVC code instead of rewriting it.
* Preserved the original EF Core migration history inside Infrastructure.
* Moved the local SQL Server connection string to .NET User Secrets and removed it from tracked configuration.
* Added architecture/setup documentation and one test-project smoke test.
* Verified: full solution build (`0 warnings, 0 errors`), unit test (`1 passed`), EF migration discovery, and API Category request (`HTTP 200`) through SQL Server.

---

## 2026-06-09

### Decisions

* Use TransactionType enum instead of string
* Add Description field to Category
* Postpone SavingGoal until later phase
* Use Fluent API inside DbContext
* Follow lab-style architecture before introducing DTO and Repository Pattern

---

### Completed

#### Requirement

* Create SRS document
* Define project scope
* Define core entities

#### Database Design

* Design Category entity
* Design Transaction entity
* Define one-to-many relationship

#### EF Core

* Install EF Core packages
* Create FinanceDbContext
* Configure DbSet
* Configure Fluent API
* Configure SQL Server connection
* Register DbContext using Dependency Injection
* Create Initial Migration
* Update Database successfully

#### Learning

* Understand DbContext
* Understand DbSet
* Understand Migration
* Understand Code First approach
* Understand Dependency Injection
* Understand base(options)
* Understand base.OnModelCreating()

---

### Current Task

* Build CategoryController
* Learn IActionResult
* Learn HTTP Response structure

---

### Next Session

* Create GET Categories API
* Create GET Category By Id API
* Create POST Category API
* Create DELETE Category API
* Test Category APIs using Swagger

---

## 2026-06-22

### Decisions

* Use Eager Loading (.Include()) for Transaction GET to load Category info
* Update fields manually in PUT instead of replacing entity (preserve EF Core tracking)
* Validate FK (CategoryId) before Create/Update Transaction

---

### Completed

#### Category Module

* Review & fix CategoryName nullable mismatch
* Fix CreatedAtAction to point to GetCategoryById with routeValues
* Remove unused imports
* All 4 Category APIs code complete (GET All, GET By Id, POST, DELETE)

#### Transaction Module

* POST CreateTransaction (with Amount validation + CategoryId validation)
* GET GetTransactionById
* GET GetAllTransaction (with Eager Loading .Include())
* DELETE DeleteTransactionById
* PUT UpdateTransaction (with id mismatch check + CategoryId validation)

#### Learning

* Understand CreatedAtAction (actionName, routeValues, value)
* Understand Eager Loading vs Lazy Loading
* Understand Task\<T\> as async return wrapper (Generic)
* Understand EF Core Change Tracking (why update fields, not replace entity)
* Understand RESTful status codes (201, 204, 400, 404)

---

### Current Task

* Test all Category APIs using Swagger
* Test all Transaction APIs using Swagger
* Test APIs using Postman

---

### Next Session

* Swagger Testing for all 9 APIs
* Postman Testing
* Start Stage 2 - Content Negotiation / DTO

---

## 2026-06-23

### Decisions

* Temporarily pause Backend Phase 5 (Repository Pattern) to build an MVC Frontend project to prepare for an upcoming test.
* Strict Content Negotiation implemented.
* Used DTOs for all endpoints to prevent over-posting and circular references.
* Used AutoMapper to eliminate manual property mapping.

---

### Completed

#### Advanced Backend

* Added XML Formatter and Strict Content Negotiation (`ReturnHttpNotAcceptable = true`)
* Configured OData (Entity Data Model & Middleware)
* Enabled OData querying on `GET` endpoints (`[EnableQuery]` & returning `IQueryable`)
* Created `CategoryDto`, `CategoryCreateDto` with `DataAnnotations` validation
* Created `TransactionDto`, `TransactionCreateDto`
* Configured `AutoMapper` with `MappingProfile` for entity-DTO mappings

#### Learning

* **Content Negotiation**: `Accept` (Client wants) vs `Content-Type` (Client sends).
* **OData**: Let clients dynamically query data (filter, sort, limit) directly from the URL.
* **DTO**: Plain objects used as a mask to protect domain models and shape API responses.
* **Validation**: `[Required]`, `[MaxLength]`, `[Range]` at the API boundary, automatically returning 400 Bad Request.
* **AutoMapper**: Lambda expressions (Anonymous Functions `=>`) to map properties automatically.

---

### Current Task

* Create a separate ASP.NET Core MVC Project.
* Use `HttpClient` to call the Backend API.

---

### Next Session

* Setup MVC Project.
* Implement `HttpClient` Service.
* Build Category/Transaction List View in MVC.

