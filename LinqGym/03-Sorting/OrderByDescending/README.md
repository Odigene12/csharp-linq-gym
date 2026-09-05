# OrderByDescending

| | |
|---|---|
| Category | 03 - Sorting |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.OrderByDescending on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.orderbydescending) |

## What it does

`OrderByDescending` sorts descending by a key - largest, latest, longest first. Everything said about
`OrderBy` applies: stable, deferred, buffering, returns `IOrderedEnumerable<T>`.

## Signatures

```csharp
IOrderedEnumerable<T> OrderByDescending<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector);
IOrderedEnumerable<T> OrderByDescending<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey>? comparer);
```

## How it behaves

- **Stable** - equal keys keep original order, exactly like `OrderBy` (the sort is not simply reversed).
- `null` keys are the smallest value, so they come *last* in a descending sort. This is how in-progress enrollments (`Grade == null`) drop to the bottom.
- `OrderByDescending(k).Take(n)` is the idiomatic "top N".

## Watch out for

- `OrderBy(k).Reverse()` is *not* equivalent for ties: `Reverse` flips the equal-key elements too.
- Booleans descending put `true` first - handy for "active first".
- Same culture warning as `OrderBy` for strings; pass an explicit `StringComparer`.

## Compare with

- `OrderBy` - ascending.
- `OrderDescending()` (.NET 7) - no key selector needed.
- `MaxBy` - when you only need the single top element.

## Query syntax

```csharp
var newest = from c in Data.Cohorts
             orderby c.StartDate descending
             select c;
```

## Exercises

Open `OrderByDescendingExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~OrderByDescendingExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_NumbersDescending` | Data.Numbers from largest to smallest. |
| 2 | Easy | `Easy_02_StudentsYoungestFirst` | students ordered by Birthday, latest birthday first. |
| 3 | Easy | `Easy_03_PricesHighToLow` | Data.Prices from most to least expensive. |
| 4 | Medium | `Medium_04_LongestWordsFirstIsStable` | words by Length, longest first. Equal lengths keep original order. |
| 5 | Medium | `Medium_05_NewestCohortsFirst` | cohorts by StartDate, most recent first. |
| 6 | Medium | `Medium_06_NullableGradesPutNullsLast` | enrollments by Grade, highest first. Null is the smallest possible value, so in-progress enrollments (Grade == null) end up at the END of a descending sort. |
| 7 | Medium | `Medium_07_CoursesByCredits` | courses by Credits, highest first (stable among equal credits). |
| 8 | Hard | `Hard_08_ThreeOldestStudents` | the first names of the three oldest students (highest Age first). |
| 9 | Hard | `Hard_09_DescendingCaseInsensitive` | words descending with StringComparer.OrdinalIgnoreCase (ties keep original order). |
| 10 | Hard | `Hard_10_CitiesByStudentCount` | city names ordered by how many students live there, most first. Memphis and Knoxville tie at 4 - because the sort is stable, the group that appeared first wins. |
<!-- exercises:end -->
