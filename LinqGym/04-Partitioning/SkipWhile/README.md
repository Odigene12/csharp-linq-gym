# SkipWhile

| | |
|---|---|
| Category | 04 - Partitioning |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.SkipWhile on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.skipwhile) |

## What it does

`SkipWhile` drops elements from the start *as long as* the predicate holds, then yields everything
that follows - including later elements that would have satisfied the predicate.

## Signatures

```csharp
IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate);
IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, int, bool> predicate); // with index
```

## How it behaves

- **Deferred and streaming.** The predicate stops being evaluated after its first `false`.
- Classic uses: strip leading zeros / blank lines, "everything from the first 2025 entry onward" in a sorted log, "everything after marker X" (`SkipWhile(x => x != marker).Skip(1)`).
- `TakeWhile(p)` followed by `SkipWhile(p)` on the same source partition it into "leading run" and "the rest".

## Watch out for

- Not a filter: `SkipWhile(n => n < 8)` keeps the 1 and 2 that appear after the first 8.
- Like `TakeWhile`, it is only meaningful when the data has an order you can reason about.

## Compare with

- `Where` - filters everywhere.
- `TakeWhile` - the complement.
- `Skip` - count-based.

## Query syntax

None.

## Exercises

Open `SkipWhileExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~SkipWhileExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_SkipWhileLessThanEight` | skip the leading numbers that are less than 8, keep the rest (including later small values). |
| 2 | Easy | `Easy_02_SkipWhileLongerThanFour` | skip the leading words longer than 4 characters. |
| 3 | Easy | `Easy_03_SkipUntilNine` | skip everything before the first 9 (the 9 itself is kept). |
| 4 | Medium | `Medium_04_SkipLeadingActiveStudents` | skip students while they are Active. The first inactive student (Bobbie) and everyone after remain. |
| 5 | Medium | `Medium_05_SkipWhileWithIndex` | use the (element, index) overload to skip the first seven positions. |
| 6 | Hard | `Hard_06_StripLeadingZeros` | remove the zeros at the start only. |
| 7 | Hard | `Hard_07_EnrollmentsFromTheFirst2025One` | order enrollments by EnrolledOn, then skip while the year is before 2025. |
<!-- exercises:end -->
