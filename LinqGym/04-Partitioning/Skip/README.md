# Skip

| | |
|---|---|
| Category | 04 - Partitioning |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Skip on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.skip) |

## What it does

`Skip(n)` bypasses the first `n` elements and yields everything after them.

## Signature

```csharp
IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count);
```

## How it behaves

- **Deferred and streaming.** The skipped elements are still *enumerated* (the source has to produce them), just not yielded. On lists and arrays the runtime jumps straight to the index.
- Skipping more than exists gives an empty sequence; `Skip(0)` and negative counts give everything. Never throws.
- Paging: `Skip((page - 1) * pageSize).Take(pageSize)`.
- `OrderBy(k).Skip(1).First()` is "the second smallest".

## Watch out for

- `Skip` then `Take` versus `Take` then `Skip` produce different windows.
- On a deferred query that is expensive, paging with `Skip` re-runs the query for every page. Materialize once if you page repeatedly.

## Compare with

- `Take` - the complement.
- `SkipWhile` - skip based on a condition.
- `SkipLast` - drop from the end.

## Query syntax

None - `(from ... select ...).Skip(n)`.

## Exercises

Open `SkipExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~SkipExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_SkipThree` | everything after the first three numbers. |
| 2 | Easy | `Easy_02_LastFiveStudents` | skip the first 15 students to get the last five. |
| 3 | Easy | `Easy_03_SkipMoreThanAvailable` | skipping more than exists yields an empty sequence (no exception). |
| 4 | Medium | `Medium_04_SkipZero` | Skip(0) yields everything. |
| 5 | Medium | `Medium_05_AllButTheFirstWord` | every word except the first. |
| 6 | Medium | `Medium_06_SecondOldestStudent` | the second-oldest student (sort by Birthday, skip the oldest, take the next). |
| 7 | Medium | `Medium_07_NegativeCountSkipsNothing` | Skip(-5) behaves like Skip(0). |
| 8 | Hard | `Hard_08_ThirdPageOfFour` | paging - page 3 (1-based) when the page size is 4. Only two elements remain on that page. |
| 9 | Hard | `Hard_09_SkipIsDeferred` | build a Skip(1) query over `list`; the element added afterwards must be included. |
| 10 | Hard | `Hard_10_AllButTheTwoLargest` | Data.Numbers sorted descending, without the two largest values. |
<!-- exercises:end -->
