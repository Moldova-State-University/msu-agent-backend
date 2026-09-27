# Invariants

| ID                | Scope             | Invariant                                                            | Enforced in                                        |
|-------------------|-------------------|----------------------------------------------------------------------|----------------------------------------------------|
| [`I1`](#i1)       | Local (Identity)  | `(IdentityProvider, IdentityId)` is unique across the system.        | UNIQUE index on `identity(provider, external_id)`  |
| [`I2`](#i2)       | Cross-aggregate   | A `User` has at most one `Identity` per `IdentityProvider`.          | UNIQUE index on `identity(user_id, provider)`      |

## Notes

Both invariants are **cross-cutting** by nature: even `I2` talks about
"per user", which requires the DB to see all identities. Neither can be fully
enforced inside a single aggregate instance without a query. We therefore place
both on the persistence boundary and translate violations into domain errors
(`IdentityAlreadyTakenException`, `IdentityAlreadyLinkedException`) at the
repository boundary.

Every write path to the `identity` table goes through `IdentityRepository`
(see [ADR-002](../adr/002-unique-indexes.md)).

---

<a id="i1"></a>
## I1 — Global uniqueness of an external account

`(IdentityProvider, IdentityId)` is unique across the entire system. One
external account (e.g. one Telegram user) can be linked to at most one `User`.

- **Scope:** global.
- **Enforced in:** UNIQUE index on `identity(provider, external_id)`.
- **Violation error:** `IdentityAlreadyTakenException`.
- **Referenced from:** [Identity aggregate](aggregates/identity.md), [Scenario S3](scenarios.md#s3).

<a id="i2"></a>
## I2 — One identity per provider per user

For a given `UserId`, there is at most one `Identity` with a given
`IdentityProvider`.

- **Scope:** cross-aggregate (per `User`).
- **Enforced in:** UNIQUE index on `identity(user_id, provider)`.
- **Violation error:** `IdentityAlreadyLinkedException`.
- **Referenced from:** [Identity aggregate](aggregates/identity.md), [Scenario S2](scenarios.md#s2).