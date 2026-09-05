# MaxBy

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET 6 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.MaxBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.maxby) |

## What it does

`MaxBy(keySelector)` returns the **element** whose key is largest, in a single pass.

## Signatures

```csharp
T? MaxBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector);
T? MaxBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey>? comparer);
```

## How it behaves

- **Immediate**, O(n).
- **Ties -> the first element** with the maximal key (so `courses.MaxBy(c => c.Credits)` is JS201, not QC999).
- Empty: `null` for reference types, exception for non-nullable value types.
- Combines nicely with `CountBy`/`Index`: `xs.CountBy(k).MaxBy(kv => kv.Value)` = the most frequent key.

## Watch out for

- `T?` return type - deal with the null.
- Not the same as `OrderByDescending(k).First()` only in cost; results agree, including tie-breaking.

## Compare with

- `Max(selector)` - the key, not the element.
- `MinBy` - mirror image.

## Query syntax

None.

## Exercises

Open `MaxByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~MaxByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_YoungestStudent` | the student with the latest Birthday. |
| 2 | Easy | `Easy_02_LongestWord` | the word with the greatest Length. |
| 3 | Easy | `Easy_03_CourseWithMostCredits` | the course with the most Credits. Two courses have 5 credits - the first one in the list wins. |
| 4 | Medium | `Medium_04_MaxByOnEmptyIsNull` | MaxBy over instructors with Specialty "Cobol" (none) returns null. |
| 5 | Medium | `Medium_05_KeyIsNotTheValue` | the number with the largest remainder mod 5 (9 % 5 == 4 is the biggest remainder). |
| 6 | Hard | `Hard_06_MaxByWithAComparer` | the ordinally-largest word (pass StringComparer.Ordinal as the key comparer). |
| 7 | Hard | `Hard_07_CohortWithTheHighestAverageAge` | the cohort whose students have the highest average Age. |
<!-- exercises:end -->
