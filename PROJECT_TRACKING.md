# PersonalLifeOS Project Tracking

## Current status

- **Product:** PersonalLifeOS — finance-first personal life management system
- **Current version:** P1 planning
- **Current stage:** `P1-01 — Identity and user preferences`
- **Current focus:** Design the Identity/user-ownership slice before implementation.
- **Source of truth:** [P1_PRODUCT_PLAN.md](P1_PRODUCT_PLAN.md)

## Completed before P1

- ASP.NET Core Web API and SQL Server baseline
- EF Core Code First initial migration
- Category CRUD API and MVC integration
- Transaction CRUD API and MVC integration
- DTO, AutoMapper, Swagger, CORS, XML formatter, and OData learning exercises

## P1 progress

| Item | Status |
|---|---|
| P1 product scope and decisions | Complete |
| P1-00 project transition / clean architecture | Complete |
| P1-01 identity and user ownership | Next |
| P1-02 real accounts and transactions | Planned |
| P1-03 funds and goals | Planned |
| P1-04 budget, dashboard, reports | Planned |
| P1-05 on-demand financial review | Planned |
| P1-06 hardening and portfolio hand-off | Planned |

## Current task

Define P1-01 requirements, data ownership model, authentication flow, and migration plan before writing Identity code.

## Guardrails

- Work one P1 item at a time.
- Preserve and reuse working Category/Transaction functionality where it fits.
- No database reset or destructive migration without explicit approval.
- No private exchange/broker credentials in the application.
- No feature is “done” without verification and a DEVLOG entry.
