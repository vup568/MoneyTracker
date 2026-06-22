# Development Log

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

