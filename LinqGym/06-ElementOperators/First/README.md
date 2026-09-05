# First

| | |
|---|---|
| Category | 06 - Element operators |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.First on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.first) |

## What it does

`First()` returns the first element; `First(predicate)` returns the first element that matches. If there
is no such element it throws `InvalidOperationException` - use it when "nothing" would be a bug.

## Signatures

```csharp
T First<T>(this IEnumerable<T> source);
T First<T>(this IEnumerable<T> source, Func<T, bool> predicate);
```

## How it behaves

- **Immediate** and **short-circuiting**: enumeration stops as soon as the element is found.
- `OrderBy(k).First()` finds the minimum by key (but sorts everything to do it - prefer `MinBy`).
- The returned value is the element itself, so you can chain member access: `First(...).LastName`.

## Watch out for

- The exception message is generic ("Sequence contains no elements" / "no matching element"). If the miss is expected, use `FirstOrDefault`.
- `First` on an `IQueryable` translates to `TOP 1`; on a `List` it is `list[0]` - either way it is cheap.

## Compare with

- `FirstOrDefault` - returns `default` instead of throwing.
- `Single` - also insists there is exactly one match.
- `Last` - from the end.
- `ElementAt(0)` - same as `First()` on a non-empty sequence.

## Query syntax

None - `(from ... select ...).First()`.

## Exercises

Open `FirstExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~FirstExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_FirstNumber` | the first value in Data.Numbers. |
| 2 | Easy | `Easy_02_FirstStudent` | the first student. |
| 3 | Easy | `Easy_03_FirstNumberAboveSeven` | the first number greater than 7. |
| 4 | Medium | `Medium_04_FirstInactiveStudent` | the first student who is not active. |
| 5 | Medium | `Medium_05_FirstOnEmptyThrows` | call First() on Data.Empty. It must throw InvalidOperationException. |
| 6 | Medium | `Medium_06_FirstWithNoMatchThrows` | call First with a predicate nobody satisfies (e.g. a student named "Zelda"). |
| 7 | Medium | `Medium_07_FirstLongWord` | the first word longer than 6 characters. |
| 8 | Hard | `Hard_08_OldestStudentViaOrderByAndFirst` | the oldest student (order by Birthday, then First). Compare with MinBy later in the course. |
| 9 | Hard | `Hard_09_FirstCohortTaughtByACSharpSpecialist` | the first cohort whose PrimaryInstructor has Specialty "C#". |
| 10 | Hard | `Hard_10_FirstShortCircuits` | pass Data.Numbers through a counting Select, then take First(n => n == 8). Only 3 elements should be evaluated. |
<!-- exercises:end -->
