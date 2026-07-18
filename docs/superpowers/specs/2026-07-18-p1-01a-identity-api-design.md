# P1-01A: Identity and protected API design

## Purpose

Complete the backend identity and data-ownership foundation before building the MVC browser-cookie/BFF flow. This is the first half of P1-01.

## Scope

- ASP.NET Core Identity with `ApplicationUser`.
- Register, login, password policy, unique email, and lockout.
- Bearer authentication for Swagger/Postman learning and API verification only.
- Required `UserId` ownership on `Category` and `Transaction`.
- Authenticated, user-scoped finance API reads and mutations.
- Tests for unauthenticated access and cross-user isolation.

## Exclusions

- MVC register/login UI and browser cookie/BFF flow; these are P1-01B.
- Email confirmation, reset password, external login, social login, and passkeys.
- Roles and administrator features.

## Security decisions

- A JWT may be used only by Swagger/Postman during P1-01A. It must not be put in browser JavaScript, local storage, or session storage.
- API controllers require authentication except register/login endpoints.
- The current user ID is read from the authenticated claim, never from a request body, route, or query parameter.
- Every finance lookup and mutation is constrained by the current user ID. An inaccessible ID returns `404 Not Found` rather than revealing that another user owns it.

## Data model

- `ApplicationUser` extends `IdentityUser` and has `DisplayName`.
- `Category` has required `UserId` and a relationship to `ApplicationUser`.
- `Transaction` has required `UserId` and a relationship to `ApplicationUser`.
- A transaction may reference only a category owned by the same user.
- Existing local finance data is explicitly disposable. The developer will reset the local development database manually before applying the new migration; no application code or migration deletes data automatically.

## API flow

1. Register creates an `ApplicationUser` with a validated email and password.
2. Login validates credentials and lockout state, then returns an access token for API testing.
3. A protected request carries `Authorization: Bearer <token>`.
4. The API resolves the user ID from claims.
5. Finance queries filter by that user ID; writes assign it server-side.

## Delivery slices

1. Identity foundation: context, DI, configuration, migration design.
2. Authentication endpoints and token issuance.
3. Ownership schema and migration.
4. User-scoped Category and Transaction endpoints.
5. Automated verification and tracking updates.

## Acceptance checks

- Anonymous finance requests receive `401 Unauthorized`.
- User A cannot read, update, or delete User B's category or transaction, even with the correct numeric ID.
- A user cannot create or update a transaction using another user's category.
- Password policy and lockout failure paths are tested.
- No JWT is introduced into the MVC browser flow.

## Follow-up

P1-01B will add MVC register/login/logout and a secure HTTP-only cookie/BFF flow. It will not expose the P1-01A bearer token to browser code.
