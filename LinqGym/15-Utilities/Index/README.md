# Index

| | |
|---|---|
| Category | 15 - Utilities |
| Available since | .NET 9 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Index on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.index) |

## What it does

`Index()` pairs every element with its zero-based position as a `(int Index, T Item)` tuple. It is the
ready-made version of `Select((x, i) => (i, x))` and reads beautifully in `foreach`:

```csharp
foreach (var (i, word) in words.Index()) Console.WriteLine($"{i}: {word}");
```

## Signature

```csharp
IEnumerable<(int Index, T Item)> Index<T>(this IEnumerable<T> source);
```

## How it behaves

- **Deferred**, streaming, count preserved.
- Combine with `Where`/`First`/`MaxBy` to find *positions*: `xs.Index().MaxBy(x => x.Item).Index` = position of the maximum.
- Tuple element names are `Index` and `Item`.

## Watch out for

- .NET 9+ only.
- Indexes restart at 0 for each enumeration of the result.

## Compare with

- `Select((x, i) => ...)` / `Where((x, i) => ...)` - index overloads on the operators themselves.
- `Zip(Enumerable.Range(...))` - the manual way.
- `ElementAt` - the inverse: from index to element.

## Query syntax

None.

## Exercises

Open `IndexExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~IndexExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_IndexedWords` | Data.Words with their indexes. |
| 2 | Easy | `Easy_02_PositionOfFig` | the index of "fig" (Index, then First with a predicate, then .Index). |
| 3 | Easy | `Easy_03_AllPositionsOfEight` | every index at which the value 8 appears in Data.Numbers. |
| 4 | Medium | `Medium_04_FormatWithIndex` | "0:apple", "1:Banana", ... |
| 5 | Medium | `Medium_05_WeightedSum` | the sum of (index * word length) over Data.Words. |
| 6 | Hard | `Hard_06_PositionOfTheMaximum` | the index of the largest number (Index + MaxBy). |
| 7 | Hard | `Hard_07_ValuesEqualToTheirOneBasedPosition` | the numbers whose value equals their 1-based position in Data.Numbers. |
<!-- exercises:end -->
