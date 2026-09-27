# MSUAgent.Identity — Documentation

Identity management module. Owns the mapping between internal `User`s and
external identities (Telegram, Google, GitHub, ...).

## Map

- [Ubiquitous Language](domain/ubiquitous-language.md) — terms used across the domain
- [Invariants](domain/invariants.md) — rules that must never be violated
- [Scenarios](domain/scenarios.md) — canonical use cases (Given/When/Then)
- [Aggregates](domain/aggregates/README.md) — aggregate-by-aggregate reference
- [ADR](adr/README.md) — why the model is shaped this way

## Where to start

New to the module? Read in this order:

1. [Ubiquitous Language](domain/ubiquitous-language.md)
2. [Invariants](domain/invariants.md)
3. [ADR-001: Identity inside User aggregate](adr/001-identity-inside-user.md)