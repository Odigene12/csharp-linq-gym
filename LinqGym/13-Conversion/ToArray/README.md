# ToArray

| | |
|---|---|
| Category | 13 - Conversion |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.ToArray on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.toarray) |

## What it does

`ToArray` runs the query and copies the results into a new `T[]`. Same snapshot semantics as
`ToList`, but you get a fixed-size array - which is what many APIs (`Array.IndexOf`, `string.Join`
overloads, spans, `params`) want.

## Signature

```csharp
T[] ToArray<T>(this IEnumerable<T> source);
```

## How it behaves

- **Immediate**, always a new array (even from an array).
- Supports `arr[^1]`, ranges `arr[2..5]`, `Span<T>` conversions.
- Nested: `matrix.Select(r => r.ToArray()).ToArray()` gives a jagged `int[][]`.

## Watch out for

- Fixed size: no `Add`. Choose `ToList` when you will grow it.
- Slightly more work than `ToList` when the count is unknown (it may resize an internal buffer and trim at the end); irrelevant for small data.
- `Array.Sort` / `Array.Reverse` (static) are in-place.

## Compare with

- `ToList` - growable.
- `Order().ToArray()` - a sorted copy without mutating the source.

## Query syntax

None.

## Exercises

Open `ToArrayExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ToArrayExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_OddNumbersAsAnArray` | the odd numbers as an int[]. |
| 2 | Easy | `Easy_02_FirstNamesArray` | all first names as a string[] (then use Length). |
| 3 | Easy | `Easy_03_EmptyArray` | numbers greater than 100 as an array - Length 0, not null. |
| 4 | Medium | `Medium_04_ToArrayIsASnapshot` | materialize `source` as an array; adding to `source` afterwards does not change the array. |
| 5 | Medium | `Medium_05_ToArrayAlwaysCopies` | ToArray on an array returns a NEW array with equal contents. |
| 6 | Medium | `Medium_06_IndexFromEnd` | the last number, via ToArray and the ^1 index. |
| 7 | Medium | `Medium_07_SortedCopyWithoutMutatingTheSource` | a sorted array of Data.Numbers; Data.Numbers itself keeps its original order. |
| 8 | Hard | `Hard_08_JaggedArray` | Data.Matrix with every value doubled, as an int[][]. |
| 9 | Hard | `Hard_09_PassToAnArrayApi` | materialize Data.Numbers as an array so it can be handed to Array.IndexOf (which needs an array). |
| 10 | Hard | `Hard_10_ToArraySurfacesErrorsImmediately` | Cast<int> over Data.MixedBag throws only when materialized. |
<!-- exercises:end -->
