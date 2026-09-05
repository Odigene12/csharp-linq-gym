# Max

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET Framework 3.5 (comparer overload: .NET 6) |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Max on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.max) |

## What it does

`Max` returns the largest **value** in a sequence, directly or via a selector.

## Signatures

```csharp
int Max(this IEnumerable<int> source);                     // ... per numeric type, plus nullable versions
T?  Max<T>(this IEnumerable<T> source);
T?  Max<T>(this IEnumerable<T> source, IComparer<T>? comparer);
TResult? Max<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector);
```

## How it behaves

- **Immediate**, single pass.
- Empty: throws for non-nullable value types, `null` for nullable/reference types.
- Nulls in nullable sources are ignored.
- `GroupBy(k).Max(g => g.Count())` = size of the largest group.

## Watch out for

- `Max(selector)` returns the key; `MaxBy` returns the element.
- For `DateOnly`, `TimeSpan`, tuples and other comparable types the generic overload works fine.
- A `Max` over `double` containing `NaN`: `NaN` is treated as the smallest value, so it never wins.

## Compare with

- `MaxBy` - the element with the largest key.
- `Min` - the mirror image.
- `OrderByDescending(k).First()` - same answer, more work.

## Query syntax

None.

## Exercises

Open `MaxExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~MaxExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_LargestNumber` | the largest value in Data.Numbers. |
| 2 | Easy | `Easy_02_HighestPrice` | the largest price. |
| 3 | Easy | `Easy_03_LongestWordLength` | the largest word Length. |
| 4 | Medium | `Medium_04_LatestInstructorBirthday` | the latest Birthday among instructors. |
| 5 | Medium | `Medium_05_MaxOfEmptyThrows` | Max() on Data.Empty throws InvalidOperationException. |
| 6 | Medium | `Medium_06_MaxIgnoresNulls` | the largest non-null score in Data.NullableScores. |
| 7 | Medium | `Medium_07_HighestGrade` | the highest Grade across all enrollments. |
| 8 | Hard | `Hard_08_MaxWithAComparer` | the largest word ignoring case (StringComparer.OrdinalIgnoreCase). |
| 9 | Hard | `Hard_09_LargestCityPopulation` | the number of students in the most populous city (group by City, then Max of the group sizes). |
| 10 | Hard | `Hard_10_OldestAgePerCohort` | for each cohort, the highest student Age. |
<!-- exercises:end -->
