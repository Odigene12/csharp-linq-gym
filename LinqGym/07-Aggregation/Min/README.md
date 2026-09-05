# Min

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET Framework 3.5 (comparer overload: .NET 6) |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Min on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.min) |

## What it does

`Min` returns the smallest **value** in a sequence, or the smallest value produced by a selector. It
works for numbers, strings, dates, anything `IComparable`, or with an explicit `IComparer<T>`.

## Signatures

```csharp
int Min(this IEnumerable<int> source);                     // ... per numeric type, plus nullable versions
T?  Min<T>(this IEnumerable<T> source);
T?  Min<T>(this IEnumerable<T> source, IComparer<T>? comparer);
TResult? Min<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector);
```

## How it behaves

- **Immediate**, single pass.
- Empty sequence: throws `InvalidOperationException` for non-nullable value types; returns `null` for nullable value types and reference types.
- Nullable sources ignore nulls.
- Vectorized for arrays/lists of primitives on modern .NET.

## Watch out for

- `Min(selector)` gives you the smallest *key*, not the element that has it. For the element use `MinBy`.
- Default string comparison is culture-sensitive; pass `StringComparer.Ordinal` for deterministic results.
- `DefaultIfEmpty().Min()` avoids the empty-sequence exception when `0`/`default` is an acceptable answer.

## Compare with

- `MinBy` - returns the element.
- `Max` - the mirror image.
- `OrderBy(k).First()` - same answer, more work.

## Query syntax

None.

## Exercises

Open `MinExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~MinExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_SmallestNumber` | the smallest value in Data.Numbers. |
| 2 | Easy | `Easy_02_CheapestPrice` | the smallest price. |
| 3 | Easy | `Easy_03_ShortestWordLength` | the smallest word Length (selector overload). |
| 4 | Medium | `Medium_04_EarliestBirthday` | the earliest student Birthday (DateOnly is comparable, so Min works on it). |
| 5 | Medium | `Medium_05_MinOfEmptyThrows` | Min() on Data.Empty throws InvalidOperationException. |
| 6 | Medium | `Medium_06_MinIgnoresNulls` | the smallest non-null score in Data.NullableScores. |
| 7 | Medium | `Medium_07_MinOfEmptyNullableIsNull` | Min over an empty sequence of int? is null, not an exception. Project Data.Empty to int? first. |
| 8 | Hard | `Hard_08_MinWithAComparer` | the smallest word using StringComparer.Ordinal (uppercase sorts first, so "APPLE"). |
| 9 | Hard | `Hard_09_YoungestAgeInNashville` | the smallest Age among students living in Nashville. |
| 10 | Hard | `Hard_10_LowestGradeInCourseOne` | the lowest Grade among enrollments in course 1. |
<!-- exercises:end -->
