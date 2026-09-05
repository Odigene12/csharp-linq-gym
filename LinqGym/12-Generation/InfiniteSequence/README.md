# InfiniteSequence

| | |
|---|---|
| Category | 12 - Generation |
| Available since | .NET 10 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.InfiniteSequence on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.infinitesequence) |

## What it does

`Enumerable.InfiniteSequence(start, step)` generates an endless arithmetic progression. It only makes
sense combined with an operator that stops: `Take`, `TakeWhile`, `First(predicate)`, `Zip` with a finite
sequence, `Skip(n).First()`.

## Signature

```csharp
static IEnumerable<T> InfiniteSequence<T>(T start, T step) where T : IAdditionOperators<T, T, T>;
```

## How it behaves

- **Deferred** and streaming. It never ends on its own, so the operator you put after it is what stops the query.
- A cleaner counter than `Range(0, int.MaxValue)` for numbering or generating candidates until a condition is met.

## Watch out for

- `Count()`, `ToList()`, `Last()`, `Reverse()`, `OrderBy()`, `Max()`, `foreach` without `break`, `TakeLast`, `SkipLast`, `Shuffle` - anything that needs the end - **never returns**.
- `Where` alone is still infinite; pair it with `Take`/`First`.

## Compare with

- `Sequence` - with an end.
- `Range` - with a count.

## Query syntax

None.

## Exercises

Open `InfiniteSequenceExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~InfiniteSequenceExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_FirstFiveNaturals` | 1, 2, 3, 4, 5 from an infinite sequence starting at 1 with step 1. |
| 2 | Easy | `Easy_02_FirstFourEvens` | 0, 2, 4, 6. |
| 3 | Easy | `Easy_03_CountingDownForever` | 10, 9, 8 (negative step, then Take 3). |
| 4 | Medium | `Medium_04_StopWithTakeWhile` | the naturals whose square is below 50 (1..7). |
| 5 | Medium | `Medium_05_SkipIntoAnInfiniteSequence` | the 101st natural number (Skip 100, then First). |
| 6 | Hard | `Hard_06_NumberWordsWithZip` | "1. apple", "2. Banana", ... - Zip the infinite counter with Data.Words (Zip stops at the shorter one). |
| 7 | Hard | `Hard_07_FirstSquareAboveOneThousand` | the first natural number whose square exceeds 1000 (First with a predicate stops the infinite sequence). |
<!-- exercises:end -->
