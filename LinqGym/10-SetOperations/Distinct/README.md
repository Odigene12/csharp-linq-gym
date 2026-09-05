# Distinct

| | |
|---|---|
| Category | 10 - Set operations |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Distinct on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.distinct) |

## What it does

`Distinct` removes duplicate elements, keeping the **first** occurrence of each and preserving order.
Equality comes from the default `EqualityComparer<T>` unless you pass your own.

## Signatures

```csharp
IEnumerable<T> Distinct<T>(this IEnumerable<T> source);
IEnumerable<T> Distinct<T>(this IEnumerable<T> source, IEqualityComparer<T>? comparer);
```

## How it behaves

- **Deferred and streaming** - it yields an element the moment it sees it for the first time, keeping a set of what it has seen.
- **Equality rules:** primitives, strings, tuples and records compare by value; classes by reference unless they override `Equals`/`GetHashCode` or you supply a comparer.
- `Distinct(StringComparer.OrdinalIgnoreCase)` folds case; the first spelling wins.
- `Distinct().Count()` = number of unique values.

## Watch out for

- Two "identical" objects of a class are two distinct elements. Compare by a key (`DistinctBy`) or with a comparer (`PersonIdComparer`).
- Ordering is preserved, but the *removed* duplicates are the later ones - sort first if you want a specific one to survive (see `DistinctBy`).
- When the comparer is an `IEqualityComparer<Base>`, type inference may pick `Base`; write `Distinct<Derived>(comparer)`.

## Compare with

- `DistinctBy` - unique by key, keeps the whole element.
- `ToHashSet` - unique values as a set (immediate).
- `Union` - distinct across two sequences.
- `GroupBy(x => x).Select(g => g.Key)` - the manual version.

## Query syntax

None - `(from ... select ...).Distinct()`.

## Exercises

Open `DistinctExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~DistinctExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_DistinctNumbers` | Data.Numbers without duplicates. |
| 2 | Easy | `Easy_02_DistinctWordsAreCaseSensitive` | Data.Words without exact duplicates ("apple" twice -> once; "APPLE" is different). |
| 3 | Easy | `Easy_03_DistinctCities` | the distinct cities students live in, in first-seen order. |
| 4 | Medium | `Medium_04_DistinctIgnoringCase` | Data.Words distinct with StringComparer.OrdinalIgnoreCase (first spelling wins). |
| 5 | Medium | `Medium_05_ReferenceEqualityForClasses` | `list` holds the SAME student object twice plus a data-identical copy. Distinct sees 2 distinct objects. |
| 6 | Medium | `Medium_06_DistinctJuniorInstructorsAcrossCohorts` | every distinct junior instructor Id across all cohorts, in first-seen order. |
| 7 | Medium | `Medium_07_RecordsUseValueEquality` | two StudentSummary records with identical values count as ONE distinct element. |
| 8 | Hard | `Hard_08_DistinctWithACustomComparer` | make the data-identical copy count as a duplicate by passing PersonIdComparer.Instance. The comparer is an IEqualityComparer<Person>, so give Distinct its type argument explicitly: Distinct<Student>(...). |
| 9 | Hard | `Hard_09_DistinctBirthMonths` | how many distinct birth months the students cover (nobody was born in June). |
| 10 | Hard | `Hard_10_DistinctIsDeferred` | build a Distinct query over `list`; an element added afterwards must show up. |
<!-- exercises:end -->
