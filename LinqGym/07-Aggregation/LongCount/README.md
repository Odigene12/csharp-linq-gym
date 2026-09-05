# LongCount

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.LongCount on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.longcount) |

## What it does

`Count` that returns a `long`. Use it when a sequence could plausibly exceed `int.MaxValue`
(2,147,483,647) elements - streamed data, generated sequences, very large query results.

## Signatures

```csharp
long LongCount<T>(this IEnumerable<T> source);
long LongCount<T>(this IEnumerable<T> source, Func<T, bool> predicate);
```

## How it behaves

- **Immediate**; always enumerates (there is no `ICollection` shortcut to a 64-bit count).
- Otherwise identical to `Count`, including the predicate overload.

## Watch out for

- The result type is `long`; assigning it to an `int` needs a cast.
- It is not faster than `Count` - just wider.

## Compare with

- `Count` - 32-bit.
- `Sum(x => 1L)` - the same thing by hand.

## Query syntax

None.

## Exercises

Open `LongCountExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~LongCountExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_LongCountOfNumbers` | how many numbers, as a long. |
| 2 | Easy | `Easy_02_InactiveStudents` | how many students are inactive, as a long (predicate overload). |
| 3 | Easy | `Easy_03_EmptyIsZero` | LongCount of Data.Empty. |
| 4 | Medium | `Medium_04_CountAMillion` | LongCount of Enumerable.Range(1, 1_000_000). |
| 5 | Medium | `Medium_05_CellsInTheMatrix` | how many cells Data.Matrix has in total (flatten, then LongCount). |
| 6 | Hard | `Hard_06_MultiplesOfSevenBelow100001` | how many numbers in Range(1, 100000) are divisible by 7. |
| 7 | Hard | `Hard_07_EnrollmentsGradedEightyOrMore` | how many enrollments have a Grade of 80 or more (null grades do not count). |
<!-- exercises:end -->
