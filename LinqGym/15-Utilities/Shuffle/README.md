# Shuffle

| | |
|---|---|
| Category | 15 - Utilities |
| Available since | .NET 10 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Shuffle on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.shuffle) |

## What it does

`Shuffle()` yields the elements in a random order. The pre-.NET-10 idiom was
`OrderBy(_ => Random.Shared.Next())`, which is slower and, because the comparison keys can collide, not
uniformly random.

## Signature

```csharp
IEnumerable<T> Shuffle<T>(this IEnumerable<T> source);
```

## How it behaves

- **Deferred, buffering.** The whole source is read, shuffled, then yielded. Each enumeration reshuffles.
- The source is not modified.
- `Shuffle().Take(n)` is the idiomatic random sample of n elements.

## Watch out for

- .NET 10+ only.
- Not seedable - for reproducible shuffles use `Random` with a seed and `OrderBy(_ => rng.Next())`, or shuffle a copied array with `Random.Shuffle(span)`.
- Not for infinite sequences.

## Compare with

- `OrderBy(_ => Random.Shared.Next())` - the old way.
- `Random.Shared.Shuffle(array)` - in-place shuffle of an array/span.

## Query syntax

None.

## Exercises

Open `ShuffleExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ShuffleExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_SameItemsInSomeOrder` | Data.Numbers shuffled. |
| 2 | Easy | `Easy_02_CountIsUnchanged` | shuffled students still number 20. |
| 3 | Easy | `Easy_03_RandomSampleOfThree` | three random numbers from Data.Numbers (Shuffle then Take). |
| 4 | Medium | `Medium_04_SortingAShuffleRestoresOrder` | shuffle, then Order - equal to the plain sorted list. |
| 5 | Medium | `Medium_05_TwoRandomDistinctStudents` | two random students; they must be different people. |
| 6 | Hard | `Hard_06_GroupingIsUnaffectedByOrder` | the number of distinct values is the same whether or not you shuffle first. |
| 7 | Hard | `Hard_07_SourceIsNotModified` | shuffle and materialize; Data.Numbers itself must still be in its original order. |
<!-- exercises:end -->
