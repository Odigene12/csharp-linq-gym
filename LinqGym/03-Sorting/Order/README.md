# Order

| | |
|---|---|
| Category | 03 - Sorting |
| Available since | .NET 7 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Order on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.order) |

## What it does

`Order` sorts a sequence of *comparable values* ascending by the values themselves - `numbers.Order()`
instead of `numbers.OrderBy(n => n)`. It exists purely so you do not have to write the identity lambda.

## Signatures

```csharp
IOrderedEnumerable<T> Order<T>(this IEnumerable<T> source);
IOrderedEnumerable<T> Order<T>(this IEnumerable<T> source, IComparer<T>? comparer);
```

## How it behaves

- Identical semantics to `OrderBy(x => x)`: stable, deferred, buffering, returns `IOrderedEnumerable<T>` so `ThenBy` still works.
- Elements must be comparable (implement `IComparable<T>`/`IComparable`) or you must pass a comparer; otherwise enumeration throws `InvalidOperationException`.
- Works on strings, numbers, chars, dates, tuples...

## Watch out for

- It is a .NET 7+ API - it will not compile on older targets.
- The same culture-sensitivity caveat for strings: `words.Order(StringComparer.Ordinal)`.

## Compare with

- `OrderBy` - when you need a key selector.
- `OrderDescending` - the descending twin.
- `List<T>.Sort()` - in-place, mutating, not LINQ.

## Query syntax

Query syntax has no `Order` keyword, but `orderby` accepts any expression - including the range variable itself, which is the same thing:

```csharp
var sorted = from n in Data.Numbers orderby n select n;   // compiles to OrderBy(n => n)
```

## Exercises

Open `OrderExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~OrderExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_NumbersAscending` | Data.Numbers ascending, without writing a key selector. |
| 2 | Easy | `Easy_02_WordsOrdinal` | Data.Words ordered with StringComparer.Ordinal. |
| 3 | Easy | `Easy_03_CharactersOfAString` | the characters of "linq" in ascending order (a string is an IEnumerable<char>). |
| 4 | Medium | `Medium_04_PricesAscending` | Data.Prices ascending. |
| 5 | Medium | `Medium_05_CustomComparer` | use Order with a comparer built by Comparer<int>.Create so that numbers come out DESCENDING. |
| 6 | Hard | `Hard_06_SortedDistinctAges` | the distinct ages of all students, ascending. |
| 7 | Hard | `Hard_07_MedianOfNumbers` | the median of Data.Numbers (10 values -> average of the 5th and 6th sorted values = (5 + 7) / 2 = 6.0). Hint: Order, then Skip/Take to reach the middle two. |
<!-- exercises:end -->
