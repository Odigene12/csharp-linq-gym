# ElementAt

| | |
|---|---|
| Category | 06 - Element operators |
| Available since | .NET Framework 3.5 (Index overload: .NET 6) |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.ElementAt on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.elementat) |

## What it does

`ElementAt(i)` returns the element at zero-based position `i`. Since .NET 6 it also takes a
`System.Index`, so `ElementAt(^1)` is the last element. Out of range -> `ArgumentOutOfRangeException`.

## Signatures

```csharp
T ElementAt<T>(this IEnumerable<T> source, int index);
T ElementAt<T>(this IEnumerable<T> source, Index index);
```

## How it behaves

- **Immediate.** On `IList<T>` it is a direct index; on anything else it enumerates `i + 1` elements (and, for `^n`, the whole sequence).
- `OrderBy(k).ElementAt(i)` is "the (i+1)-th smallest" - the median, for instance.

## Watch out for

- Indexing a lazy query repeatedly in a loop is O(n^2). Materialize with `ToList()` first.
- `ElementAt(0)` on an empty sequence throws `ArgumentOutOfRangeException`, not `InvalidOperationException` like `First()`.

## Compare with

- `ElementAtOrDefault` - default instead of throwing.
- `First` / `Last` - positions 0 and ^1 with `InvalidOperationException` semantics.
- `Skip(i).First()` - the pre-LINQ-optimization way; same result.

## Query syntax

None.

## Exercises

Open `ElementAtExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ElementAtExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_FifthNumber` | the element at index 4. |
| 2 | Easy | `Easy_02_TenthStudent` | the student at index 9. |
| 3 | Easy | `Easy_03_LastViaIndexFromEnd` | the last number using an Index from the end (^1). |
| 4 | Medium | `Medium_04_OutOfRangeThrows` | ElementAt(10) on a 10-element list throws ArgumentOutOfRangeException. |
| 5 | Medium | `Medium_05_MiddleOfASortedSequence` | sort Data.Numbers ascending and return the element at index 4. |
| 6 | Hard | `Hard_06_SecondToLastStudent` | the second-to-last student using an Index from the end. |
| 7 | Hard | `Hard_07_ThirdYoungestStudent` | the third-youngest student (order by Birthday descending, then ElementAt). |
<!-- exercises:end -->
