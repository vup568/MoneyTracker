# PersonalLifeOS — Phase 1 Product Plan

**Status:** Active

**Product direction:** A Personal Life OS that starts with a useful personal-finance module.

**Phase 1 boundary:** A secure, web-first finance MVP. Finance is the first module, not the entire future product.

---

## 1. Phase 1 outcome

At the end of P1, a user can register, sign in securely, record and understand their money, manage real wallets/accounts, reserve money in virtual funds, progress toward a dream/goal, and see a useful overall dashboard.

The application must answer these questions on first use:

1. How much money do I have, and where is it?
2. What did I spend, when, and on what?
3. How much has come in and gone out this month?
4. Which dream or saving goal am I progressing toward?
5. Is my financial management reasonable, based on an on-demand review?

---

## 2. Product decisions already agreed

| Area | P1 decision |
|---|---|
| Product name in code | `PersonalLifeOS`; `Finance` remains a bounded module. |
| Platform | Web first: API first, then MVC web client. Mobile is later. |
| Architecture | Clean Architecture *lite* + modular monolith. No microservices, CQRS, MediatR, or generic repository by default. |
| Data access | EF Core Code First; every schema change is an explicit, reviewed migration committed to Git. |
| Authentication | ASP.NET Core Identity with basic registration, login, logout, password policy, and lockout. |
| Browser security | Browser has only a secure HTTP-only session cookie. A JWT is not exposed to JavaScript or browser storage. |
| Data ownership | Every personal record belongs to exactly one user and all finance queries are user-scoped. |
| Currency | VND first. Crypto is entered as a VND-valued account in P1; no live price or P&L. |
| Investments | No broker/exchange private API keys or account sync in P1. |
| Funds and goals | Real wallets hold actual money; virtual Funds/Jars reserve money by purpose; Goals represent specific dreams. A goal can receive contributions from one or more funds. |
| Goal completion | User manually links a purchase/transaction to a goal and explicitly confirms completion. |
| Budget | All categories are tracked. A monthly budget limit is optional per expense category; it is not a restriction on category tracking. |
| AI/review | User-triggered only in P1. Start with transparent rule-based review; AI narrative is an optional later increment after the data and privacy flow are sound. |
| Theme and language | Theme: System / Light / Dark. Language: Auto / Vietnamese / English. Preference persists per user. |
| Email/SMS verification | Not P1. It is P1.1 security hardening, together with password reset. |

---

## 3. Scope

### In scope

- Rename the technical solution to `PersonalLifeOS` and introduce the minimal Clean Architecture boundary.
- Basic user account and secure ownership of data.
- Real accounts/wallets: cash, bank account, e-wallet, crypto account (manual VND valuation).
- Income, expense, and transfer transactions with history and filters.
- User-owned income/expense categories and starter category templates.
- Virtual Funds/Jars, Unallocated money, saving goals, and manual goal-linked purchases.
- Monthly optional budgets, dashboard, and finance reports.
- On-demand financial review using deterministic rules.
- Light/dark/system theme and Vietnamese/English/automatic language preference foundation.
- Swagger/API verification and a small automated test base for critical rules.

### Explicitly out of scope

- Mobile/Flutter application.
- Email confirmation, forgot-password flow, phone/SMS verification, social login, passkeys.
- Live crypto/Vietnamese stock prices, P&L, Binance/OKX/DNSE account sync, or any trading action.
- Bank login scraping, bank credentials, private exchange API keys, or automated transaction import.
- Scheduled AI review, AI changing data automatically, or a full AI chatbot.
- Tasks, habits, calendar, social features, microservices, gRPC, Docker deployment, and CI/CD.

---

## 4. Domain language and guardrails

| Term | Meaning | Must not be confused with |
|---|---|---|
| Account / Wallet | A real place where money exists: cash, bank, e-wallet, crypto. | A saving goal or a virtual envelope. |
| Transaction | A movement of real money: income, expense, or transfer. | An allocation inside a Fund. |
| Fund / Jar | A virtual allocation by purpose: emergency, health, shopping. | Extra money added to net worth. |
| Goal | A specific dream/item: laptop, travel, course. | A wallet or a generic category. |
| Goal contribution | A recorded amount moved from one Fund to one Goal. | An expense by itself. |
| Transfer | Movement between two real accounts. | Income or expense. |

**Accounting rules for P1**

1. A transfer never changes income, expense, or cash-flow reports.
2. Net worth counts real Account balances once. Funds and Goals are allocations only and must never be added again.
3. Transaction amount is always positive; its type determines direction.
4. Account balance is derived from opening balance plus transactions, rather than maintained by duplicated mutable totals.
5. A category with transactions cannot be deleted silently; P1 will use a safe restriction/archive rule.
6. Every API read/write verifies both authentication and record ownership.

---

## 5. P1 delivery backlog

Work is delivered as small vertical slices. A later item does not start until the previous item is demonstrated, reviewed, and recorded in `DEVLOG.md`.

### P1-00 — Project transition and safety foundation

**Goal:** Make the current small codebase ready to grow without changing its business behaviour.

- Rename solution/projects/namespaces from `FinanceTracker` to `PersonalLifeOS`.
- Create `Domain`, `Application`, `Infrastructure`, `Api`, and `Web` boundaries.
- Move existing Category/Transaction code gradually; the build must remain green after each move.
- Keep the current API + MVC client as the starting point; do not rewrite CRUD screens.
- Move the database connection secret out of tracked configuration into User Secrets / environment configuration.
- Add a test project and one smoke test path.

**Done when:** solution builds, current Category/Transaction endpoints still work, no real connection secret remains in tracked configuration, and the architecture dependency direction is documented.

### P1-01 — Identity and user preferences

**Goal:** A user can own and protect their data.

- Add `ApplicationUser` with ASP.NET Core Identity.
- Registration, login, logout, password validation, unique email, and lockout on repeated failures.
- Secure MVC session cookie; API uses authenticated user identity for authorization.
- Add `UserPreference`: theme, language, currency (`VND`), and timezone (`Asia/Ho_Chi_Minh` initially).
- Add `UserId` ownership to existing Category and Transaction records through a reviewed migration.
- Protect all finance endpoints and enforce user filtering on every query and mutation.

**Acceptance checks:**

- An unauthenticated request cannot access finance data.
- User A cannot read, update, or delete User B's Category or Transaction, even by guessing an ID.
- Theme/language preference survives logout and login.
- Browser JavaScript never receives a JWT or password.

### P1-02 — Real accounts and reliable transactions

**Goal:** The user can see where real money is and what happened to it.

- Add Account/Wallet CRUD with type, opening balance, VND currency, and optional “include in net worth”.
- Evolve Category into user-owned income/expense categories; create starter templates at registration.
- Evolve Transaction into Income, Expense, and Transfer, linked to the required Account(s).
- Add history filters: date range, account, category, and transaction type.
- Standardise request DTOs so create/update follow one validated contract.
- Correct the existing deletion behaviour and transaction/category constraints.

**Acceptance checks:**

- Income increases and expense decreases the derived balance of the selected account.
- A transfer moves money between two accounts but does not appear as income or expense.
- Monthly totals match the transaction history.

### P1-03 — Funds, dreams, and saving goals

**Goal:** Turn money into intentional progress without double-counting it.

- Show a derived Unallocated amount.
- Create and manage virtual Funds/Jars (for example: emergency, health, shopping).
- Allocate available money to a Fund; release it back to Unallocated when necessary.
- Create Goals with target amount, target date, image/description, and status.
- Record Goal Contributions from one or more Funds.
- Let the user link an expense to a Goal and manually mark the Goal completed.

**Acceptance checks:**

- Fund and goal amounts do not alter net worth a second time.
- A contribution is traceable to its Fund and Goal.
- The dashboard can show the primary goal and current progress when the application opens.

### P1-04 — Budget, dashboard, and reports

**Goal:** Convert records into an understandable financial picture.

- Optional monthly budget limits per expense category, including “no limit”.
- Dashboard: total real balance, monthly income, monthly expense, net cash flow, primary goal, Funds, and recent transactions.
- Reports: monthly cash flow, spending by category, account balance, and budget progress.
- Apply the theme/language preference to the shared layout and dashboard.

**Acceptance checks:**

- A transfer is excluded from spending charts and cash flow.
- Every category remains visible in reports, whether it has a budget or not.
- Dashboard figures reconcile with source transactions.

### P1-05 — On-demand financial review

**Goal:** Help the user reflect without pretending the system knows more than the data supports.

- A user presses “Review today” or “Review this month”.
- Rule-based insights explain changes in spending, budget pressure, and goal progress using visible calculations.
- Each insight includes the period and data used.
- No automatic scheduled review and no automated data-changing action.

**Acceptance checks:**

- An insight can be traced back to transactions/budgets/goals.
- If data is insufficient, the review says so instead of inventing an answer.

### P1-06 — P1 hardening and portfolio hand-off

**Goal:** Make P1 demonstrable and safe to use daily.

- Critical unit/integration tests: ownership, transaction direction, transfer exclusion, and balance calculation.
- API examples in Swagger; manual smoke-test checklist.
- Error handling and validation messages appropriate for the web UI.
- Update README, architecture diagram, setup guide, and demo seed instructions.
- Review backlog and select P1.1 based on actual personal usage.

---

## 6. Execution order for the next session

P1-00 is complete. Only **P1-01** starts next. Its first task is requirement/design work for Identity, user ownership, browser session handling, and migration of existing Category/Transaction data. No Identity implementation or database migration starts until those decisions and acceptance cases are reviewed.

### P1-01 learning objectives

- Authentication versus authorization.
- ASP.NET Core Identity user/password lifecycle.
- Cookie session for the browser and bearer authentication for APIs.
- Claims and current-user resolution.
- User-owned data and object-level authorization.
- Safe Code First migration/backfill when existing rows do not have a `UserId`.

---

## 7. Definition of Done for each task

A task is done only when all applicable items are true:

- Acceptance criteria have been demonstrated manually.
- Validation and failure paths were checked, not only the happy path.
- Build is green and relevant automated tests pass.
- Migration is reviewed before it is applied; no unapproved database reset.
- The UI does not expose sensitive data or JWTs.
- `PROJECT_TRACKING.md`, `BACKLOG.md`, and `DEVLOG.md` reflect the outcome.
- The next task is small enough to be reviewed and learned in one session.

---

## 8. Data migration policy

The existing Category/Transaction records have no `UserId`. Before P1-01 applies its migration, we will explicitly decide whether the local data is disposable test data or must be preserved. We will not drop or overwrite the database automatically.

For non-disposable data, the migration plan is: back up database → create/identify owner user → backfill ownership intentionally → make `UserId` required → verify records and API isolation.

---

## 9. P1.1 candidates, not P1 commitments

- Email confirmation and password reset.
- Crypto/stock market quotes and manual position/P&L tracking.
- CSV import.
- Recurring transactions and rule-based auto-categorisation.
- A provider-backed AI narrative over deterministic review data.
