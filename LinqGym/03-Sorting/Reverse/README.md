# Reverse

| | |
|---|---|
| Category | 03 - Sorting |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Reverse on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.reverse) |

## What it does

`Reverse` yields the elements in the opposite order. No comparison, no keys - the last element comes
first, full stop.

## Signature

```csharp
IEnumerable<T> Reverse<T>(this IEnumerable<T> source);
```

## How it behaves

- **Deferred, but buffering.** It has to read the whole source before it can yield the last element first.
- Reversing a sorted sequence is *not* the same as sorting descending: ties come out in flipped order rather than original order.
- Strings are `IEnumerable<char>`, so `"linq".Reverse()` reverses the characters (turn it back into a string with `new string(chars.ToArray())` or `string.Concat`).

## Watch out for

- **`List<T>.Reverse()` is a different method.** It is an instance method that reverses the list *in place* and returns `void`. Calling `.Reverse()` directly on a `List<T>` picks that one, so `IEnumerable<int> r = list.Reverse();` does not compile. Write `list.AsEnumerable().Reverse()` or `Enumerable.Reverse(list)`.
- Arrays are safe on .NET 10 (`array.Reverse()` binds to LINQ), but `Array.Reverse(array)` - the static one - is in-place.

## Compare with

- `OrderByDescending` - sorts; `Reverse` only flips.
- `TakeLast(n).Reverse()` - "the n most recent, newest first".

## Query syntax

None.

## Exercises

Open `ReverseExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ReverseExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_NumbersReversed` | Data.Numbers in reverse order. Data.Numbers is a List<int> - see the class comment above! |
| 2 | Easy | `Easy_02_ReverseAString` | the string "linq" reversed. A string is an IEnumerable<char>; turn the result back into a string. |
| 3 | Easy | `Easy_03_StudentsLastToFirst` | students in reverse order. |
| 4 | Medium | `Medium_04_ReversingASortIsNotADescendingSort` | `reversed` = words ordered by Length, then reversed. `descending` = words ordered by Length descending. They differ! Reversing flips the order of equal-length words too, while OrderByDescending keeps them stable. |
| 5 | Medium | `Medium_05_ReverseRowsAndCells` | reverse the order of the rows in Data.Matrix AND reverse each row, then flatten. |
| 6 | Hard | `Hard_06_ReverseIsDeferred` | build a reversed query over `list` (do not materialize). The element added later must appear first. |
| 7 | Hard | `Hard_07_MostRecentThreeFirst` | the last three numbers, most recent (last) first: 10, 3, 7. |
<!-- exercises:end -->
