# Average

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Average on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.average) |

## What it does

`Average` computes the arithmetic mean. `int`/`long` sources produce a `double`; `decimal` produces
`decimal`; `float` produces `float`.

## Signatures (one per numeric type)

```csharp
double  Average(this IEnumerable<int> source);      double? Average(this IEnumerable<int?> source);
decimal Average(this IEnumerable<decimal> source);
double  Average<T>(this IEnumerable<T> source, Func<T, int> selector);   // ... and the other numeric types
```

## How it behaves

- **Immediate.**
- **Empty non-nullable sequence -> `InvalidOperationException`** ("Sequence contains no elements").
- **Empty nullable sequence -> `null`**, and nulls are excluded from both the sum and the count. Project to `int?` when "no data" should be `null` rather than an exception.
- Internally sums as `long`/`double`, so integer overflow is not a concern for realistic data.

## Watch out for

- Floating-point results: assert with a tolerance (`Assert.Equal(expected, actual, precision)`).
- Averaging an already-averaged value (average of course averages) is not the overall average - weight by count or go back to the raw data.

## Compare with

- `Sum` / `Count` - the two ingredients.
- `Aggregate` with a `(sum, count)` tuple - how you would write it yourself.
- `AggregateBy` - averages per key.

## Query syntax

None.

## Exercises

Open `AverageExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~AverageExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_AverageOfNumbers` | the mean of Data.Numbers (56 / 10). |
| 2 | Easy | `Easy_02_AverageTemperature` | the mean of Data.Temperatures. |
| 3 | Easy | `Easy_03_AveragePrice` | the mean of Data.Prices (decimal in, decimal out). |
| 4 | Medium | `Medium_04_AverageOfEmptyThrows` | Average() over Data.Empty throws InvalidOperationException. |
| 5 | Medium | `Medium_05_NullsAreIgnored` | the average of Data.NullableScores. Nulls are skipped: (90 + 85 + 70 + 100) / 4. |
| 6 | Medium | `Medium_06_AverageStudentAge` | the average Age of all students. |
| 7 | Medium | `Medium_07_AverageWordLength` | the average Length of Data.Words. |
| 8 | Hard | `Hard_08_AverageGradeAcrossAllGradedEnrollments` | the average Grade of all enrollments (selector returns int?; nulls skipped; result is double?). |
| 9 | Hard | `Hard_09_AverageOfEmptyNullableIsNull` | make the average of Data.Empty come back as null instead of throwing, by projecting to int? first. |
| 10 | Hard | `Hard_10_AverageGradeForCourseOne` | the average Grade of enrollments in course 1. |
<!-- exercises:end -->
