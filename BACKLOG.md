# PersonalLifeOS Product Backlog

The ordered P1 backlog is maintained in [P1_PRODUCT_PLAN.md](P1_PRODUCT_PLAN.md). This file is the short operational queue.

## Completed — P1-00

- [x] Rename solution/projects/namespaces: `FinanceTracker` → `PersonalLifeOS`.
- [x] Map existing files/projects to Clean Architecture boundaries.
- [x] Create Domain, Application, Infrastructure, Api, Web, and UnitTests projects.
- [x] Move database secret from tracked configuration to .NET User Secrets.
- [x] Verify solution build, unit test, EF migration discovery, and an API-to-database smoke request.

## Now — P1-01

- [ ] ASP.NET Core Identity and `ApplicationUser`.
- [ ] Register, login, logout, password policy, lockout.
- [ ] User ownership migration for Category and Transaction.
- [ ] Protected APIs and user-scoped queries.
- [ ] Theme/language user preferences.

## Later in P1

- [ ] P1-02: accounts/wallets, income/expense/transfer, category templates, filters.
- [ ] P1-03: unallocated money, funds/jars, goals, goal contributions.
- [ ] P1-04: optional budgets, dashboard, reports, theme/i18n UI.
- [ ] P1-05: on-demand deterministic financial review.
- [ ] P1-06: tests, documentation, portfolio hand-off.

## Explicitly deferred

- [ ] Email/SMS verification and password reset (P1.1).
- [ ] Live prices, P&L, and Binance/OKX/DNSE connection (P2+).
- [ ] Mobile, tasks, habits, calendar, AI chatbot, microservices, gRPC, Docker, CI/CD.
