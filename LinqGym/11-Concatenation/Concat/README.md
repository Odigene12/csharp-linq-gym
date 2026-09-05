# Concat

| | |
|---|---|
| Category | 11 - Concatenation |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Concat on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.concat) |

## What it does

`Concat` yields every element of the first sequence, then every element of the second. Nothing is
removed, nothing is reordered - SQL's `UNION ALL`.

## Signature

```csharp
IEnumerable<T> Concat<T>(this IEnumerable<T> first, IEnumerable<T> second);
```

## How it behaves

- **Deferred and streaming**; the second sequence is not touched until the first is exhausted.
- Any two `IEnumerable<T>` of the same `T`: arrays, lists, ranges, other queries.
- Chain for more: `a.Concat(b).Concat(c)` (the runtime flattens the chain).

## Watch out for

- Duplicates are kept. Use `Union` for set semantics.
- Element types must match; `IEnumerable<Student>.Concat(IEnumerable<Instructor>)` does not compile - `Cast<Person>()` both sides first.

## Compare with

- `Union` - distinct.
- `Append` / `Prepend` - one extra element.
- `SelectMany` - concatenating many sequences produced per element.

## Query syntax

None.

## Exercises

Open `ConcatExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ConcatExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_AThenB` | Data.SetA followed by Data.SetB, duplicates and all. |
| 2 | Easy | `Easy_02_TwoCohortsOfStudents` | the students of cohort 1 followed by those of cohort 2 (Ids). |
| 3 | Easy | `Easy_03_AddAWordAtTheEnd` | Data.Words followed by a one-element array containing "kiwi". |
| 4 | Medium | `Medium_04_ConcatVersusUnion` | write both. Concat keeps everything (11), Union keeps distinct values only (7). |
| 5 | Medium | `Medium_05_JuniorsThenPrimaryPerCohort` | for every cohort, its JuniorInstructors followed by its PrimaryInstructor, flattened (13 in total). |
| 6 | Hard | `Hard_06_ConcatIsDeferred` | build first.Concat(second); elements added to either list afterwards must be included. |
| 7 | Hard | `Hard_07_ConcatDifferentCollectionTypes` | an array, a List and an Enumerable.Range chained into one sequence: 1, 2, 3, 4. |
<!-- exercises:end -->
