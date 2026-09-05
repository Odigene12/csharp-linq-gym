# MinBy

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET 6 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.MinBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.minby) |

## What it does

`MinBy(keySelector)` returns the **element** whose key is smallest. Before .NET 6 the idiom was
`OrderBy(k).First()` (sorts everything) or a hand-written loop; `MinBy` does it in one pass.

## Signatures

```csharp
T? MinBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector);
T? MinBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey>? comparer);
```

## How it behaves

- **Immediate**, single pass, O(n).
- **Ties -> the first element** with the minimal key.
- Empty sequence: `null` for reference types, `InvalidOperationException` for non-nullable value types.
- Keys can be computed on the fly (an average, a distance, a string length...).

## Watch out for

- Return type is `T?` - the compiler asks you to handle `null` even when you know the sequence is not empty.
- The key comparer is applied to the *key* (`StringComparer.OrdinalIgnoreCase` when keys are strings).

## Compare with

- `Min(selector)` - returns the key value, not the element.
- `OrderBy(k).First()` - O(n log n) alternative.
- `MaxBy` - mirror image.

## Query syntax

None.

## Exercises

Open `MinByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~MinByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_OldestStudent` | the student with the earliest Birthday. |
| 2 | Easy | `Easy_02_ShortestWord` | the word with the smallest Length. |
| 3 | Easy | `Easy_03_CourseWithFewestCredits` | the course with the fewest Credits. |
| 4 | Medium | `Medium_04_MinByOnEmptyIsNull` | MinBy over students from "Paris" (none) returns null. |
| 5 | Medium | `Medium_05_TiesGoToTheFirstElement` | the number with the smallest remainder mod 3. Both 3s and the 9 have remainder 0 - the FIRST wins. |
| 6 | Hard | `Hard_06_MinByWithAComparer` | the alphabetically-first word ignoring case (pass StringComparer.OrdinalIgnoreCase as the key comparer). |
| 7 | Hard | `Hard_07_StudentWithTheLowestAverageGrade` | among students that have at least one graded enrollment, the one with the lowest average Grade. |
<!-- exercises:end -->
