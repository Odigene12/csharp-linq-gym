# Last

| | |
|---|---|
| Category | 06 - Element operators |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Last on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.last) |

## What it does

`Last()` returns the final element; `Last(predicate)` the final matching one. Throws
`InvalidOperationException` when there is none.

## Signatures

```csharp
T Last<T>(this IEnumerable<T> source);
T Last<T>(this IEnumerable<T> source, Func<T, bool> predicate);
```

## How it behaves

- **Immediate.** On lists and arrays it indexes the end directly; on other sources it must enumerate everything.
- `OrderBy(k).Last()` = the maximum by key (`MaxBy` does it in one pass).

## Watch out for

- On a lazy pipeline `Last` is O(n) - and with a predicate it cannot stop early.
- Not translatable by some query providers without an `OrderBy`.

## Compare with

- `LastOrDefault` - default instead of throwing.
- `First` - from the front.
- `TakeLast(1)` - as a sequence rather than a value.
- `ElementAt(^1)` - index-from-end alternative.

## Query syntax

None.

## Exercises

Open `LastExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~LastExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_LastNumber` | the last value in Data.Numbers. |
| 2 | Easy | `Easy_02_LastStudent` | the last student. |
| 3 | Easy | `Easy_03_LastNumberBelowFive` | the last number that is less than 5. |
| 4 | Medium | `Medium_04_LastInactiveStudent` | the last inactive student. |
| 5 | Medium | `Medium_05_LastOnEmptyThrows` | Last() on Data.Empty throws InvalidOperationException. |
| 6 | Hard | `Hard_06_LastFiveLetterWord` | the last word with exactly 5 characters. |
| 7 | Hard | `Hard_07_YoungestStudentViaOrderByAndLast` | the youngest student (order by Birthday ascending, then Last). |
<!-- exercises:end -->
