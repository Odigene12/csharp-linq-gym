# Range

| | |
|---|---|
| Category | 12 - Generation |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Range on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.range) |

## What it does

`Enumerable.Range(start, count)` generates `count` consecutive integers beginning at `start`. It is a
static factory on `Enumerable`, not an extension method, and the usual way to "loop with LINQ".

## Signature

```csharp
static IEnumerable<int> Range(int start, int count);
```

## How it behaves

- **Deferred**, streaming, and it knows its count (`TryGetNonEnumeratedCount` succeeds).
- `count == 0` is empty; a negative `count` (or `start + count - 1 > int.MaxValue`) throws `ArgumentOutOfRangeException` immediately.
- `Range(1, n).Select(f)` is the functional `for` loop: squares, FizzBuzz, multiplication tables, matrix transposition by column index.

## Watch out for

- The second argument is a **count**, not an end value. `Range(10, 3)` is 10, 11, 12.
- `int` only; for other numeric types or a step, see `Sequence` (.NET 10).

## Compare with

- `Sequence` (.NET 10) - start / end / step, any numeric type.
- `Repeat` - the same value n times.
- `InfiniteSequence` - no end.

## Query syntax

None.

## Exercises

Open `RangeExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~RangeExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_OneToFive` | the integers 1 through 5. |
| 2 | Easy | `Easy_02_ZeroCountIsEmpty` | Range with a count of 0. |
| 3 | Easy | `Easy_03_StartAtTen` | three integers starting at 10. |
| 4 | Medium | `Medium_04_SquaresOfOneToFive` | the squares 1, 4, 9, 16, 25 (Range + Select). |
| 5 | Medium | `Medium_05_NegativeStart` | -3 through 3. |
| 6 | Hard | `Hard_06_NegativeCountThrows` | a negative count throws ArgumentOutOfRangeException (immediately). |
| 7 | Hard | `Hard_07_FizzBuzz` | FizzBuzz for 1..15: multiples of 15 -> "FizzBuzz", of 3 -> "Fizz", of 5 -> "Buzz", otherwise the number as text. |
<!-- exercises:end -->
