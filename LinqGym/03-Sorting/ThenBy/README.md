# ThenBy

| | |
|---|---|
| Category | 03 - Sorting |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.ThenBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.thenby) |

## What it does

`ThenBy` adds a secondary ascending sort key. It only exists on `IOrderedEnumerable<T>`, so it must
follow `OrderBy`, `OrderByDescending`, `Order`, `OrderDescending`, or another `ThenBy*`. Within each group
of elements that tied on the previous keys, `ThenBy` decides the order.

## Signatures

```csharp
IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector);
IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey>? comparer);
```

## How it behaves

- Chain as many levels as you like: `OrderBy(a).ThenBy(b).ThenByDescending(c).ThenBy(d)`.
- The whole chain is one sort pass under the hood - it does not sort repeatedly.
- Stable, deferred, buffering - it inherits everything from the `OrderBy` that started the chain.
- Mixing directions is fine: `OrderByDescending(count).ThenBy(name)`.

## Watch out for

- `OrderBy(a).OrderBy(b)` is **not** `OrderBy(a).ThenBy(b)`. The second `OrderBy` throws away the first ordering. This is the most common sorting bug in LINQ code.
- In query syntax the comma does the job: `orderby s.City, s.LastName` compiles to `OrderBy(...).ThenBy(...)`.

## Compare with

- `ThenByDescending` - secondary key, descending.
- `OrderBy` with a tuple key `OrderBy(s => (s.City, s.LastName))` - works too, but every key must sort in the same direction.

## Query syntax

```csharp
var sorted = from s in Data.Students
             orderby s.City, s.Active, s.FirstName
             select s;
```

## Exercises

Open `ThenByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ThenByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ByCityThenLastName` | students by City, then by LastName within each city. |
| 2 | Easy | `Easy_02_ByLengthThenOrdinal` | words by Length, then alphabetically using StringComparer.Ordinal. |
| 3 | Easy | `Easy_03_ByCategoryThenCredits` | courses by Category, then by Credits (ascending). |
| 4 | Medium | `Medium_04_InactiveFirstThenByBirthday` | instructors ordered by Active (false first) then by Birthday. |
| 5 | Medium | `Medium_05_ByStudentThenCourse` | enrollments by StudentId then CourseId. Student 10 enrolled in course 5 before course 1, so the secondary key must reorder those two rows. |
| 6 | Medium | `Medium_06_ThreeLevels` | students by City, then Active (inactive first), then FirstName. |
| 7 | Medium | `Medium_07_ByRemainderThenValue` | numbers grouped by remainder when divided by 3 (0, 1, 2), and ascending within each remainder. |
| 8 | Hard | `Hard_08_ThenByAfterDescending` | cohorts with Active ones first (descending bool), then by Name. |
| 9 | Hard | `Hard_09_ThenByVersusASecondOrderBy` | write both queries. `correct` sorts by City then LastName. `overwritten` chains OrderBy(City).OrderBy(LastName) - the second OrderBy REPLACES the first, so the result is simply sorted by LastName (which for our data is Id order). |
| 10 | Hard | `Hard_10_OrderGroupsByCountThenKey` | city names ordered by student count (most first), ties broken alphabetically by city name. |
<!-- exercises:end -->
