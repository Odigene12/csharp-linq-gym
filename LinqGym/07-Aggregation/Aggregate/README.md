# Aggregate

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Aggregate on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.aggregate) |

## What it does

`Aggregate` is the general-purpose **fold**: it carries an accumulator through the sequence, calling
your function with `(accumulator, element)` for each element, and returns the final accumulator. Every
other aggregate - `Sum`, `Min`, `Count`, `string.Join` - is a special case.

## Signatures

```csharp
T Aggregate<T>(this IEnumerable<T> source, Func<T, T, T> func);                                    // seed = first element
TAcc Aggregate<T, TAcc>(this IEnumerable<T> source, TAcc seed, Func<TAcc, T, TAcc> func);
TResult Aggregate<T, TAcc, TResult>(this IEnumerable<T> source, TAcc seed, Func<TAcc, T, TAcc> func, Func<TAcc, TResult> resultSelector);
```

## How it behaves

- **Immediate**, single pass, left to right.
- **No seed:** the first element is the initial accumulator; the accumulator type equals the element type; an empty sequence throws `InvalidOperationException`.
- **With seed:** the accumulator can be any type (a tuple, a list, a dictionary, a string); an empty sequence returns the seed.
- **Result selector:** a final transformation of the accumulator - e.g. divide a `(sum, count)` tuple.

## Watch out for

- Mutable accumulators (a `List` or `Dictionary` seed) work but the lambda must `return` the same object.
- String concatenation with `Aggregate` is O(n^2); prefer `string.Join` or `StringBuilder` for real code. Here it is a learning device.
- If a dedicated operator exists (`Sum`, `Max`, `CountBy`...) it is clearer and often faster than `Aggregate`.

## Compare with

- `Sum` / `Min` / `Max` / `Count` - specialised folds.
- `AggregateBy` (.NET 9) - a fold per key.
- `Select` with running state - use `Aggregate` into a list for prefix sums.

## Query syntax

None.

## Exercises

Open `AggregateExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~AggregateExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ProductOfAllNumbers` | multiply every number together (no seed needed - the first element is the starting accumulator). |
| 2 | Easy | `Easy_02_JoinWordsWithCommas` | "apple,Banana,cherry,..." built with Aggregate (string.Join would be the real-world choice). |
| 3 | Easy | `Easy_03_SumWithASeed` | the sum of Data.Numbers using the (seed, func) overload with a seed of 0. |
| 4 | Medium | `Medium_04_MaxViaAggregate` | the largest number, using Aggregate with Math.Max. |
| 5 | Medium | `Medium_05_AverageViaTupleAccumulatorAndResultSelector` | accumulate a (Sum, Count) tuple, then use the third overload's result selector to divide. |
| 6 | Medium | `Medium_06_EmptySequenceNeedsASeed` | without a seed, Aggregate over Data.Empty throws. With a seed, it returns the seed. |
| 7 | Medium | `Medium_07_CountOccurrencesIntoADictionary` | build a Dictionary<string, int> of word -> occurrences, using a new Dictionary as the seed. |
| 8 | Hard | `Hard_08_ReverseAStringWithAggregate` | reverse "linq" by prepending each character to the accumulator (seed: empty string). |
| 9 | Hard | `Hard_09_RunningTotals` | the running (cumulative) totals of Data.Numbers as a List<int>: 5, 8, 16, 17, ... |
| 10 | Hard | `Hard_10_RowSumsJoinedWithPipes` | "6\|9\|30" - the sum of each row in Data.Matrix, joined with '\|', built in a single Aggregate. |
<!-- exercises:end -->
