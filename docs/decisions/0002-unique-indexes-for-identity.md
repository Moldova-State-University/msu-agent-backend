# Unique Indexes for Identity

## Context and Problem Statement

`Identity-I1` and `Identity-I2` are global or cross-aggregate — neither can be
enforced by a single aggregate instance in isolation. Application-level checks
are subject to races: two concurrent requests can each pass the check before
either commits.

## Decision

Enforce both invariants via unique indexes on the `identity` table: