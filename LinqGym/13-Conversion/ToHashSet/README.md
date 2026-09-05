# ToHashSet

| | |
|---|---|
| Category | 13 - Conversion |
| Available since | .NET Core 2.0 / .NET Framework 4.7.2 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.ToHashSet on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.tohashset) |

## What it does

`ToHashSet` materializes the distinct elements into a `HashSet<T>` - unordered, duplicate-free, with
O(1) `Contains`. The standard fix for `list.Contains(x)` inside a `Where` over a big list.

## Signatures

```csharp
HashSet<T> ToHashSet<T>(this IEnumerable<T> source);
HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T>? comparer);
```

## How it behaves

- **Immediate**, new set each call.
- `Count` = number of distinct elements. Set algebra: `SetEquals`, `IsSubsetOf`, `Overlaps`, `UnionWith`, ...
- `ToHashSet(StringComparer.OrdinalIgnoreCase)` gives case-insensitive membership.

## Watch out for

- No order guarantee when enumerating a `HashSet`.
- Classes: reference equality unless a comparer or `Equals`/`GetHashCode` override.

## Compare with

- `Distinct` - deferred, ordered, not indexable.
- `ToDictionary` - keys with values.
- `Contains` - the membership test you will call on the set.

## Query syntax

None.

## Exercises

Open `ToHashSetExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ToHashSetExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_DistinctNumbersAsASet` | Data.Numbers as a HashSet<int>. |
| 2 | Easy | `Easy_02_SetOfCities` | the set of cities students live in. |
| 3 | Easy | `Easy_03_CaseInsensitiveSet` | Data.Words as a case-insensitive set (StringComparer.OrdinalIgnoreCase). |
| 4 | Medium | `Medium_04_FastMembershipInsideWhere` | build a set of enrolled StudentIds, then the students NOT in it. |
| 5 | Medium | `Medium_05_SetEquals` | Data.SetA as a HashSet; SetEquals ignores order and duplicates. |
| 6 | Hard | `Hard_06_ToHashSetAlwaysCopies` | two ToHashSet calls give two different set objects. |
| 7 | Hard | `Hard_07_DistinctLettersAcrossAllWords` | how many distinct letters (ignoring case) appear across all of Data.Words. |
<!-- exercises:end -->
