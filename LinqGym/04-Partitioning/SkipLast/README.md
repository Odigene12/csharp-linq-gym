# SkipLast

| | |
|---|---|
| Category | 04 - Partitioning |
| Available since | .NET Core 2.0 / .NET Standard 2.1 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.SkipLast on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.skiplast) |

## What it does

`SkipLast(n)` yields everything except the last `n` elements.

## Signature

```csharp
IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count);
```

## How it behaves

- **Deferred.** For non-indexable sources it buffers `n` elements ahead so it knows which ones to withhold; for lists and arrays it simply stops early.
- More than the length -> empty; zero or negative -> everything. Never throws.
- `Skip(1).SkipLast(1)` trims both ends; `OrderBy(k).SkipLast(1)` drops the largest.

## Watch out for

- Because it must see `n` elements ahead, the first element comes out only after `n + 1` have been read.
- Infinite sequences never produce output.

## Compare with

- `TakeLast` - the complement.
- `Skip` - from the front.
- `Take(..^n)` - the range-based equivalent on .NET 6+.

## Query syntax

None.

## Exercises

Open `SkipLastExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~SkipLastExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_AllButLastThree` | Data.Numbers without its last three values. |
| 2 | Easy | `Easy_02_AllButTheLastStudent` | every student except the last one. |
| 3 | Easy | `Easy_03_SkipLastMoreThanAvailable` | SkipLast(100) is empty. |
| 4 | Medium | `Medium_04_SkipLastZero` | SkipLast(0) yields everything. |
| 5 | Medium | `Medium_05_AllButTheYoungest` | students ordered oldest-first, without the youngest one. |
| 6 | Hard | `Hard_06_TrimBothEnds` | drop the first AND the last number. |
| 7 | Hard | `Hard_07_SkipLastIsDeferred` | build SkipLast(1) over `list`; after adding 4, the query must yield 1, 2, 3 (4 is now the last). |
<!-- exercises:end -->
