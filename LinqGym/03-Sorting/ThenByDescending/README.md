# ThenByDescending

| | |
|---|---|
| Category | 03 - Sorting |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.ThenByDescending on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.thenbydescending) |

## What it does

`ThenByDescending` is `ThenBy` with the direction flipped: a secondary key sorted largest-first, applied
inside the groups that tied on the earlier keys.

## Signatures

```csharp
IOrderedEnumerable<T> ThenByDescending<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector);
IOrderedEnumerable<T> ThenByDescending<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey>? comparer);
```

## How it behaves

- Typical shapes: "by category, then best first" (`OrderBy(c => c.Category).ThenByDescending(c => c.Credits)`) and "by count, then name Z-A".
- `null` secondary keys go last within their group.
- Any mix of ascending and descending levels is allowed.

## Watch out for

- Only available after an `OrderBy*`/`Order*`/`ThenBy*` call - it does not exist on a plain `IEnumerable<T>`.
- Same string-comparer advice as every sort: be explicit for mixed-case text.

## Compare with

- `ThenBy` - ascending secondary key.
- `OrderByDescending` - primary descending key (starts a chain).

## Query syntax

```csharp
var sorted = from c in Data.Courses
             orderby c.Category, c.Credits descending
             select c;
```

## Exercises

Open `ThenByDescendingExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ThenByDescendingExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ByCityThenOldestFirst` | students by City, then by Age descending within each city. |
| 2 | Easy | `Easy_02_ByCategoryThenMostCredits` | courses by Category, then by Credits descending. |
| 3 | Easy | `Easy_03_EvensThenOddsEachDescending` | even numbers first (largest first), then odd numbers (largest first). |
| 4 | Medium | `Medium_04_ByCourseThenBestGradeFirst` | enrollments by CourseId, then Grade descending (in-progress/null grades last within a course). |
| 5 | Medium | `Medium_05_ByLengthThenReverseAlphabetical` | words by Length ascending, then ordinal descending within a length. |
| 6 | Hard | `Hard_06_MixAscendingAndDescendingLevels` | instructors by Specialty (asc), then Active (true first), then Birthday (asc). |
| 7 | Hard | `Hard_07_CitiesByCountThenNameDescending` | city names by student count (most first); ties broken by name DESCENDING. |
<!-- exercises:end -->
