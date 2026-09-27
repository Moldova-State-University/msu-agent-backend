# Ubiquitous Language

| Term                 | Meaning                                                                 |
|----------------------|-------------------------------------------------------------------------|
| **User**             | An account inside MSUAgent. **Aggregate root.**                          |
| **Identity**         | A link between a `User` and an external account. **Aggregate root.**    |
| **IdentityProvider** | The external system (Telegram, Google, ...). Enum.                      |
| **ExternalId**       | Identifier of the account inside the provider. Stored as `IdentityId`.  |
| **Link**             | Creating an `Identity` bound to a `User`.                               |
| **Unlink**           | Removing an `Identity`.                                                 |
| **Merge**            | Combining two `User`s. Out of scope for now.                            |

## Naming notes

- `Identity.Id` — internal surrogate key (`Guid`).
- `Identity.ExternalId` — external identifier (`string`).
- `Identity.UserId` — reference to the owning `User` (cross-aggregate reference
  by ID, not by object).
- `IdentityProvider` is an enum: adding a provider is a code change.