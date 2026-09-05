# Sum

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Sum on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.sum) |

## What it does

`Sum` adds up a sequence of numbers - `int`, `long`, `float`, `double`, `decimal` and their nullable
forms - either directly or via a selector.

## Signatures (one per numeric type)

```csharp
int  Sum(this IEnumerable<int> source);      int?  Sum(this IEnumerable<int?> source);
int  Sum<T>(this IEnumerable<T> source, Func<T, int> selector);   // ... and long, float, double, decimal
```

## How it behaves

- **Immediate.** Empty sequence -> `0` (never an exception, unlike `Average`/`Min`/`Max`).
- **Nullable sources skip nulls.** `new int?[] { 1, null, 2 }.Sum()` is `3` (typed `int?`).
- **Integer sums are checked** - overflowing `int`/`long` throws `OverflowException`. Widen with a selector: `Sum(n => (long)n)`.
- Floating-point sums accumulate rounding error; compare with a tolerance.

## Watch out for

- `Sum` only exists for numeric types. For anything else (TimeSpan, custom money types) use `Aggregate`.
- `Select(x => x.Prop).Sum()` and `Sum(x => x.Prop)` are equivalent; the latter reads better.
- On .NET 8+ the runtime vectorizes sums over arrays and lists of primitives - fast.

## Compare with

- `Aggregate` - general folding.
- `Average` - sum divided by count.
- `AggregateBy` - sums per key.

## Query syntax

None.

## Exercises

Open `SumExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~SumExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_SumOfNumbers` | the total of Data.Numbers. |
| 2 | Easy | `Easy_02_SumOfPrices` | the total of Data.Prices (decimal). |
| 3 | Easy | `Easy_03_SumWithASelector` | the total number of characters in Data.Words, using Sum with a selector. |
| 4 | Medium | `Medium_04_NullsAreIgnored` | the sum of Data.NullableScores. The result type is int? and null entries are skipped. |
| 5 | Medium | `Medium_05_SumOfEmptyIsZero` | Sum of Data.Empty. |
| 6 | Medium | `Medium_06_TotalBackendCredits` | the total Credits of all courses in the "Backend" category. |
| 7 | Medium | `Medium_07_SumOfAllGrades` | the sum of every Grade across all enrollments (selector returns int?, nulls skipped). |
| 8 | Hard | `Hard_08_SumOfDoubles` | the sum of Data.Temperatures. Floating point, so the assertion allows a tiny tolerance. |
| 9 | Hard | `Hard_09_CreditsEnrolledByStudentOne` | the total Credits of all courses student 1 is enrolled in (look up each course with Data.Course(id)). |
| 10 | Hard | `Hard_10_OverflowThrowsUnlessYouWiden` | summing int.MaxValue + 1 as ints throws OverflowException. Summing them as longs (selector cast) works. |
<!-- exercises:end -->
