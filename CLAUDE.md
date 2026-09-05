# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## The rule that governs everything else

This repo has two branches and **`main` is generated, not authored**.

- **`solutions`** is the source of truth. Every exercise has a working answer inline. All 668 tests pass.
- **`main`** is produced from `solutions` by `tools/Make-StudentVersion.ps1`, which replaces each answer with
  a `TODO` placeholder. All 668 tests fail with `NotImplementedException`, by design.

**Never edit a `*Exercises.cs` file on `main`.** Any such edit is destroyed by the next sync, and it ships
answers to learners in the meantime. Author on `solutions`, then regenerate. CI enforces both halves: it runs
the suite on `solutions`, and on `main` it fails if a `//!` marker survives or if any test does something
other than throw `NotImplementedException`.

A red `dotnet test` on `main` is the correct state, not a problem to fix.

## Commands

```bash
dotnet build                                                  # net10.0; CI builds with -warnaserror
dotnet test                                                   # 668 pass on solutions, 668 fail on main
dotnet test --filter "FullyQualifiedName~WhereExercises"      # one method
dotnet test --filter "FullyQualifiedName~LinqGym.Sorting"     # one category (namespace)
dotnet test --filter "FullyQualifiedName~WhereExercises.Easy_02"   # one exercise
dotnet test --list-tests                                      # all 668 names
```

Maintainer scripts (Windows PowerShell 5.1; run from anywhere, they resolve their own root):

```bash
powershell -File tools/Update-ReadmeTables.ps1   # rebuild the exercise table in every README
powershell -File tools/Make-StudentVersion.ps1   # strip answers -> TODO (run on main only)
tools/reset-exercises.sh [filter]                # discard answers; powershell tools/Reset-Exercises.ps1 -Only X
```

Sync `main` after changing anything on `solutions`:

```bash
git checkout main
git checkout solutions -- .          # copy every tracked file, so tools/ and docs/ cannot be missed
powershell -File tools/Make-StudentVersion.ps1
dotnet build
git commit -am "Sync from solutions"
```

`git checkout solutions -- .` does not propagate deletions; remove deleted files on `main` by hand.

## How an exercise is wired together

Three pieces have to agree, and two of them are generated:

1. **The answer marker.** On `solutions`, an answer is tagged so the generator can find it:
   `IEnumerable<int> result = Data.Numbers.Where(n => n > 2); //!` for one line, or `= //!{` ... `//!}` for a
   block. The generator rewrites either form to `= TODO;`. An answer without a marker survives into `main`
   and CI fails.
2. **`TODO`** is a `dynamic` property on `LinqExercise` (`Support/LinqExercise.cs`) that throws
   `NotImplementedException`. It is `dynamic` only so any declared result type compiles. The explicit type on
   the left of `= TODO` is the exercise's main hint, so always declare it, never `var`.
3. **The README table** between `<!-- exercises:start -->` / `<!-- exercises:end -->` is generated from the
   `// Task:` comment of each `[Fact]` by `Update-ReadmeTables.ps1`. Editing it by hand is pointless; add or
   change the `// Task:` comment and regenerate.

## Architecture

`LinqGym/` is a single xUnit project. Folders `01-Filtering` through `15-Utilities` hold one folder per LINQ
method (`README.md` + `<Method>Exercises.cs`, namespace `LinqGym.<Category>`); `16-Combinations` holds the
multi-operator module. All 74 `Enumerable` methods of .NET 10 are covered, plus `Queryable.AsQueryable`.
`FullJoin` is .NET 11 and is deliberately absent.

`Data/SchoolData.cs` is **load-bearing**. A fresh instance is built for every test, and several hundred
expected values across the suite are derived from its exact contents. Adding a collection is safe; changing
an existing student, grade or number silently breaks unrelated exercises. `docs/DATASET.md` documents it and
must be updated in step. Ages come from `Clock.Today`, pinned to 2026-01-01 so nothing drifts with real time.

`Support/` holds the `TODO` placeholder, `PersonIdComparer` (for exercises that need key equality on
reference types) and `LinqAssert` (order-insensitive comparison).

## Conventions

- 7 exercises per method (3 easy / 2 medium / 2 hard), or 10 for a heavily used one (3 / 4 / 3). The
  README header states the count and split, and those claims are checked during review.
- Test names are `Easy_01_...`, `Medium_04_...`, `Hard_08_...`. The number runs continuously across levels
  so Test Explorer sorts them in teaching order.
- Every `[Fact]` needs a `// Task:` comment directly under the signature. It feeds the README table.
- Assert against literals (ids, names, small arrays), not against a re-derived LINQ expression. A test that
  computes the expected value with the operator under test proves nothing.
- Source files are ASCII only.
- Analyzer suppressions in `LinqGym.csproj` are deliberate and documented there; the flagged patterns are
  usually the lesson (`Assert.Equal(n, x.Count())` teaches `Count()`, so `Assert.Single` would hide it).

## Method README shape

Each method README carries: a fact table (category, availability, exercise count, Microsoft Learn link),
What it does, Signatures, How it behaves, Watch out for, Compare with, Query syntax, and the generated
Exercises table. Keep availability accurate (several methods are .NET 6/7/9/10 only) and verify behavioural
claims against the runtime rather than from memory; a review already found wrong claims about analyzer
rules, `Sequence` argument validation and `Reverse` overload binding.

## Windows notes

`tools/*.ps1` target Windows PowerShell 5.1: no three-argument `Join-Path`, no `&&`/`??`/ternary, and
`$PSScriptRoot` is unreliable in a `param()` default, so the scripts resolve their root from `$PSCommandPath`.
`.gitattributes` pins `*.sh` to LF so `reset-exercises.sh` stays runnable on Linux and macOS.
