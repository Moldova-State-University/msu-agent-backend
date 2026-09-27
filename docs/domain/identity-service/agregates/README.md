# Aggregates

## Index

- [User](user.md) — aggregate root
- [Identity](identity.md) — aggregate root

## Rules

- References between aggregates go **by ID only**.
- Cross-aggregate consistency is coordinated by application services.
- Invariants are DB-enforced where they cannot be enforced inside a single
  aggregate instance.

## Aggregate map

```mermaid
classDiagram
    class User {
        +Guid Id
        +LinkIdentity(provider, externalId)
        +UnlinkIdentity(identityId)
    }

    class Identity {
        +Guid Id
        +Guid UserId
        +string IdentityId
        +IdentityProvider Provider
        +DateTime CreatedAt
        +DateTime UpdatedAt
    }

    User "1" ..> "0..*" Identity : references by UserId