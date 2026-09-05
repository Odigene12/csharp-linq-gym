# TakeWhile

| | |
|---|---|
| Category | 04 - Partitioning |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.TakeWhile on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.takewhile) |

## What it does

`TakeWhile` yields elements from the start *as long as* the predicate holds. At the first element that
fails, it stops for good - later elements are never examined, even if they would pass.

## Signatures

```csharp
IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate);
IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, int, bool> predicate); // with index
```

## How it behaves

- **Deferred and streaming**; the source is read only up to and including the first failing element.
- Meaningful on *ordered* data: "grades >= 90 from a descending list", "dates before the cutoff from a sorted log".
- The index overload lets you mix position and value: `TakeWhile((n, i) => n > i)`.

## Watch out for

- `TakeWhile(p)` and `Where(p)` give different results whenever a failing element is followed by passing ones. If you meant "all that match", use `Where`.
- On unsorted data it usually returns less than you expect.

## Compare with

- `Where` - tests every element.
- `SkipWhile` - the complement: drops the leading run, keeps the rest.
- `Take` - stop after a count instead of a condition.

## Query syntax

None.

## Exercises

Open `TakeWhileExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~TakeWhileExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_WhileLessThanEight` | numbers from the start while they are less than 8. |
| 2 | Easy | `Easy_02_WhileLongerThanFourLetters` | words from the start while their Length is greater than 4. |
| 3 | Easy | `Easy_03_TakeWhileVersusWhere` | write both. `takeWhile` stops at the first 9; `where` skips only the 9 and keeps going. |
| 4 | Medium | `Medium_04_LeadingActiveStudents` | students from the start while they are Active. Bobbie (2nd) is inactive, so only Anne qualifies. |
| 5 | Medium | `Medium_05_TakeWhileWithIndex` | use the (element, index) overload: take numbers while each number is greater than its index. |
| 6 | Hard | `Hard_06_TopGradesFromASortedSequence` | enrollments sorted by Grade descending, then take while Grade >= 90. TakeWhile only makes sense on sorted data - here it avoids scanning the whole list. |
| 7 | Hard | `Hard_07_LeadingRunOfEqualValues` | the run of elements at the start that equal the first element. |
<!-- exercises:end -->
