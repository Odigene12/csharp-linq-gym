# Count

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Count on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.count) |

## What it does

`Count()` returns how many elements there are; `Count(predicate)` how many match. SQL's `COUNT(*)` and
`COUNT(*) ... WHERE`.

## Signatures

```csharp
int Count<T>(this IEnumerable<T> source);
int Count<T>(this IEnumerable<T> source, Func<T, bool> predicate);
```

## How it behaves

- **Immediate.** The parameterless overload uses `ICollection.Count` when the source is a collection; otherwise it enumerates everything. The predicate overload always enumerates everything.
- `Distinct().Count()` counts unique values; `GroupBy(k).Count()` counts groups.
- Overflows `int` for more than 2^31 elements - that is what `LongCount` is for.

## Watch out for

- `List<T>.Count` (property, O(1)) vs `.Count()` (method). Both work on a list; the method is a tiny bit slower and reads like a query.
- `Count() > 0` to test emptiness enumerates the whole sequence for non-collections - use `Any()`.
- `Where(p).Count()` = `Count(p)`.

## Compare with

- `Any` - "is there at least one?" without counting.
- `LongCount` - 64-bit result.
- `CountBy` (.NET 9) - counts per key in one pass.
- `TryGetNonEnumeratedCount` - count only if it is free.

## Query syntax

None - `(from ... select ...).Count()`.

## Exercises

Open `CountExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~CountExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_HowManyNumbers` | the number of elements in Data.Numbers, using the LINQ method. |
| 2 | Easy | `Easy_02_HowManyActiveStudents` | how many students are Active (use the predicate overload, not Where + Count). |
| 3 | Easy | `Easy_03_CountOfEmpty` | Count() of Data.Empty. |
| 4 | Medium | `Medium_04_InProgressEnrollments` | how many enrollments have no Grade yet. |
| 5 | Medium | `Medium_05_StudentsInNashville` | how many students live in Nashville. |
| 6 | Medium | `Medium_06_DistinctNumbers` | how many DIFFERENT values Data.Numbers contains. |
| 7 | Medium | `Medium_07_CoursesTaughtByInstructorOne` | how many courses have InstructorId 1. |
| 8 | Hard | `Hard_08_TotalCharactersAcrossAllWords` | the total number of characters in all of Data.Words (flatten, then count). |
| 9 | Hard | `Hard_09_ActiveStudentsPerCohort` | (CohortName, ActiveStudentCount) for every cohort. |
| 10 | Hard | `Hard_10_CountEnumeratesEverything` | pass Data.Numbers through a counting Select and then Count(n => n > 0). Unlike Any, Count must look at every element - all 10 flow through the selector. |
<!-- exercises:end -->
