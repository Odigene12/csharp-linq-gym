# Sequence

| | |
|---|---|
| Category | 12 - Generation |
| Available since | .NET 10 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Sequence on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.sequence) |

## What it does

`Enumerable.Sequence(start, endInclusive, step)` generates an arithmetic progression for **any numeric
type** (`int`, `long`, `double`, `decimal`, `char`, ...): from `start`, stepping by `step`, up to and
including `endInclusive` (or as close as the step allows). It is `Range` with an end value and a step.

## Signature

```csharp
static IEnumerable<T> Sequence<T>(T start, T endInclusive, T step) where T : INumber<T>;
```

## How it behaves

- **Deferred**, streaming.
- Positive step: values ascend until the next one would exceed `endInclusive`. Negative step: descend.
- `endInclusive` is only produced if the step lands on it exactly (`Sequence(1, 10, 4)` = 1, 5, 9).
- `start == endInclusive` yields a single element regardless of step.

## Watch out for

- .NET 10+ only.
- A step whose sign points away from the end (`Sequence(10, 1, 1)`) throws `ArgumentOutOfRangeException` immediately. A zero step throws too - unless `start == endInclusive`, where the single-element rule above wins and you get one element.
- Floating-point steps accumulate rounding; `Sequence(0.0, 1.0, 0.1)` may stop at 0.9999.

## Compare with

- `Range` - ints, start + count.
- `InfiniteSequence` - no end.

## Query syntax

None.

## Exercises

Open `SequenceExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~SequenceExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_OneToTen` | 1 through 10 with a step of 1. |
| 2 | Easy | `Easy_02_MultiplesOfFive` | 0, 5, 10, 15, 20. |
| 3 | Easy | `Easy_03_CountingDown` | 10, 7, 4, 1 (negative step). |
| 4 | Medium | `Medium_04_DoublesInQuarterSteps` | 0.0, 0.25, 0.5, 0.75, 1.0. |
| 5 | Medium | `Medium_05_EndIsInclusiveButNotAlwaysHit` | from 1 to 10 in steps of 4 - the sequence stops at 9 because 13 would exceed the end. |
| 6 | Hard | `Hard_06_InvalidStepThrows` | a positive step with start > end throws ArgumentOutOfRangeException (as does a step of 0). |
| 7 | Hard | `Hard_07_LettersAToE` | the characters a, b, c, d, e - char is a numeric type as far as Sequence is concerned (step (char)1). |
<!-- exercises:end -->
