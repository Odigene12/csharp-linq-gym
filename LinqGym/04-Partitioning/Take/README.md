# Take

| | |
|---|---|
| Category | 04 - Partitioning |
| Available since | .NET Framework 3.5 (Range overload: .NET 6) |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Take on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.take) |

## What it does

`Take(n)` yields the first `n` elements and stops. Since .NET 6 it also accepts a `Range`, so
`Take(2..5)` and `Take(^3..)` slice a sequence the way `array[2..5]` slices an array.

## Signatures

```csharp
IEnumerable<T> Take<T>(this IEnumerable<T> source, int count);
IEnumerable<T> Take<T>(this IEnumerable<T> source, Range range);
```

## How it behaves

- **Deferred and streaming.** Only `n` elements are ever pulled from the source - a `Select` before `Take(2)` runs twice, not ten times.
- Asking for more than exists returns what exists. `Take(0)` and negative counts return empty. It never throws for the count.
- With a `Range`: `Take(2..5)` = positions 2, 3, 4; `Take(^3..)` = last three; `Take(..3)` = first three.
- `Skip(a).Take(b)` is the paging idiom; the order matters (`Take(b).Skip(a)` is different).

## Watch out for

- `Take` on an unsorted sequence gives you "some" elements, not the "top" ones. Sort first for top-N.
- `TakeLast` needs to buffer; `Take` does not.

## Compare with

- `Skip` - the complement.
- `TakeWhile` - stop based on a condition instead of a count.
- `TakeLast` - from the end.
- `Chunk` - many consecutive `Take`s at once.

## Query syntax

None - wrap the query: `(from n in xs select n).Take(3)`.

## Exercises

Open `TakeExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~TakeExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_FirstThreeNumbers` | the first three values of Data.Numbers. |
| 2 | Easy | `Easy_02_FirstFiveStudentNames` | the first names of the first five students. |
| 3 | Easy | `Easy_03_TakeMoreThanAvailable` | ask for 100 numbers. Take never throws - you just get everything there is. |
| 4 | Medium | `Medium_04_TakeZero` | Take(0) yields nothing. |
| 5 | Medium | `Medium_05_TakeARange` | Take accepts a Range (.NET 6+). Return elements at positions 2, 3 and 4 with a single Take call. |
| 6 | Medium | `Medium_06_TakeFromTheEndWithARange` | the last three numbers using Take with a range that starts from the end (^3..). |
| 7 | Medium | `Medium_07_ThreeOldestStudents` | the three oldest students (order by Birthday, then Take). |
| 8 | Hard | `Hard_08_NegativeCountIsEmpty` | Take(-1) is treated like Take(0): empty, no exception. |
| 9 | Hard | `Hard_09_SecondPageOfThree` | paging - the second page when the page size is 3 (elements at positions 3, 4, 5). |
| 10 | Hard | `Hard_10_TakeOnlyPullsWhatItNeeds` | project every number through a selector that increments `evaluated`, then Take(2). Because everything is lazy, only two elements should ever flow through the selector. |
<!-- exercises:end -->
