# Aggregate: User

## Purpose

An account in MSUAgent. References its identities by ID; does not own them.

## Root

`User`, identified by `User.Id` (`Guid`).

## Composition

| Member | Type   | Notes                       |
|--------|--------|-----------------------------|
| `Id`   | `Guid` | Surrogate key. Immutable.   |

> `User` does **not** hold a collection of `Identity` objects. Identities are
> queried via `IdentityRepository.FindByUserId(userId)`.

## Invariants

None of its own. The rule "≤ 1 identity per provider per user"
(`Identity-I2`) is enforced on the `Identity` side.

## Behavior

Behavior is intentionally thin. `User` does not mutate its identities directly;
the application service coordinates cross-aggregate operations.

| Method                             | Effect                                                |
|------------------------------------|-------------------------------------------------------|
| `LinkIdentity(provider, externalId)` | Delegates to the identity-link flow (app service).  |
| `UnlinkIdentity(identityId)`       | Delegates to the identity-unlink flow (app service).  |

## State diagram

```mermaid
stateDiagram-v2
    [*] --> Active
    Active --> [*] : deleted