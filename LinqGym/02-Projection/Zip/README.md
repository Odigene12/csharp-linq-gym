# Zip

| | |
|---|---|
| Category | 02 - Projection |
| Available since | .NET Framework 4.0 (tuple overloads: .NET Core 3.0, three-sequence overload: .NET 6) |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Zip on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.zip) |

## What it does

`Zip` walks two (or three) sequences in lock-step and combines the elements at the same position.
Without a result selector it yields tuples `(First, Second)`; with one, whatever you build. It stops as
soon as the shortest input is exhausted.

## Signatures

```csharp
IEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second);
IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector);
IEnumerable<(TFirst, TSecond, TThird)> Zip<TFirst, TSecond, TThird>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third);
```

## How it behaves

- **Deferred and streaming.** Both inputs are pulled one element at a time.
- Length of the result = length of the *shortest* input; extra elements are ignored, no exception.
- Zipping a sequence with itself shifted by one (`xs.Zip(xs.Skip(1))`) gives consecutive pairs - the classic way to compute differences.
- Zipping with `Enumerable.Range` or `InfiniteSequence` numbers the elements.

## Watch out for

- Zip is positional, not key-based. To match on a key you want `Join`.
- The inputs are enumerated in parallel, so a deferred, expensive query zipped with itself runs twice.

## Compare with

- `Select` with index - when the "second sequence" is just the position.
- `Join` - combine by matching keys instead of positions.
- `Index()` (.NET 9) - `Zip` with the position, ready-made.

## Query syntax

None. Use method syntax.

## Exercises

Open `ZipExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ZipExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ZipIntoTuples` | pair each number with the word at the same position. The no-selector overload returns (First, Second) tuples. |
| 2 | Easy | `Easy_02_ZipWithResultSelector` | element-wise sums of the two arrays. |
| 3 | Easy | `Easy_03_StopsAtTheShorterSequence` | zip five numbers with two letters. Extra elements of the longer sequence are ignored. |
| 4 | Medium | `Medium_04_ZipThreeSequences` | the three-sequence overload yields (First, Second, Third) tuples. |
| 5 | Medium | `Medium_05_NumberEachWord` | "1. apple", "2. Banana", ... by zipping Data.Words with Enumerable.Range(1, 100). |
| 6 | Hard | `Hard_06_PairwiseDifferences` | the difference between each number and the one before it (next - previous). Hint: zip the sequence with itself shifted by one (Skip(1)). |
| 7 | Hard | `Hard_07_DotProduct` | the dot product of two vectors: sum of the element-wise products (1*4 + 2*5 + 3*6 = 32). |
<!-- exercises:end -->
