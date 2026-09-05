# OrderDescending

| | |
|---|---|
| Category | 03 - Sorting |
| Available since | .NET 7 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.OrderDescending on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.orderdescending) |

## What it does

`OrderDescending` sorts comparable values descending by the values themselves - the key-less version of
`OrderByDescending(x => x)`.

## Signatures

```csharp
IOrderedEnumerable<T> OrderDescending<T>(this IEnumerable<T> source);
IOrderedEnumerable<T> OrderDescending<T>(this IEnumerable<T> source, IComparer<T>? comparer);
```

## How it behaves

- Stable, deferred, buffering, chainable with `ThenBy*`.
- `OrderDescending().Take(n)` is a compact "top N values".
- `Distinct().OrderDescending().ElementAt(k)` finds the (k+1)-th largest distinct value.

## Watch out for

- .NET 7+ only.
- Pass `StringComparer.Ordinal`/`OrdinalIgnoreCase` for text.

## Compare with

- `Order` - ascending.
- `OrderByDescending` - with a key selector.
- `Max` / `MaxBy` - when you only need the single largest.

## Query syntax

```csharp
var desc = from n in Data.Numbers orderby n descending select n;
```

## Exercises

Open `OrderDescendingExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~OrderDescendingExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_NumbersDescending` | Data.Numbers descending, without a key selector. |
| 2 | Easy | `Easy_02_WordsOrdinalDescending` | Data.Words descending using StringComparer.Ordinal. |
| 3 | Easy | `Easy_03_TemperaturesHottestFirst` | Data.Temperatures descending. |
| 4 | Medium | `Medium_04_TopThreePrices` | the three highest prices, highest first. |
| 5 | Medium | `Medium_05_CaseInsensitiveDescending` | Data.Words descending, ignoring case (ties keep original order). |
| 6 | Hard | `Hard_06_BirthdaysLatestFirst` | all student birthdays, latest first. |
| 7 | Hard | `Hard_07_ThirdLargestDistinctNumber` | the third-largest DISTINCT value in Data.Numbers (10, 9, then 8). |
<!-- exercises:end -->
