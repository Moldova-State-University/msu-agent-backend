# ADR-Use-Bff

* Status: accepted
* Deciders: Stanislav Ciobanu
* Date: 2026-09-09

Technical Story: https://github.com/Moldova-State-University/msu-agent-backend/issues/4

## Context and Problem Statement

University needs backend to be both reachable from future mobile app and telegram bot. A solution that makes backend independent and reusable has to be found.

## Decision Drivers

* One backend project for two frontends.
* Backend has to be independent.
* The solution should be flexible and allow changing infrastructure without touching domain.

## Considered Options

* Split Infrastructure layer into different assemblies and allow direct call of core business logic
* Use different BFF that call private backend api

## Decision Outcome

Chosen option: "Use different BFF that call private backend api", because Chosen decision will allow adding new BFF's without changing the core project. It will also make all frontends reuse common api endpoints and forbid direct backend calls.

### Positive Consequences

* Independant domain
* Logic reuse

### Negative Consequences

* Complex infrastructure
