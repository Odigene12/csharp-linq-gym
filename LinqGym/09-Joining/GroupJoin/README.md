# GroupJoin

| | |
|---|---|
| Category | 09 - Joining |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.GroupJoin on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.groupjoin) |

## What it does

`GroupJoin` produces **one result per outer element**, handing your selector the outer element plus the
*collection* of inner elements that match it (possibly empty). It is a hierarchical join: "each course
with its enrollments", "each instructor with their courses".

## Signature

```csharp
IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
    this IEnumerable<TOuter> outer, IEnumerable<TInner> inner,
    Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
    Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
    IEqualityComparer<TKey>? comparer = null);
```

## How it behaves

- **Deferred**; inner is read into a lookup on first enumeration, outer is streamed.
- Every outer element appears exactly once, even with zero matches - that makes it the basis of the classic **left outer join**: `GroupJoin(...).SelectMany(x => x.Inners.DefaultIfEmpty(), ...)`.
- Aggregating the inner group (`es.Count()`, `es.Average(...)`) gives per-outer statistics; empty groups give `0` / `null` naturally.

## Watch out for

- The inner group is an `IEnumerable<TInner>`; calling `.Count()` and `.Average()` on it enumerates it twice - fine for small data, `ToList()` it otherwise.
- Same key-type rule as `Join` (`int?` vs `int`).

## Compare with

- `Join` - flat pairs, unmatched outers dropped.
- `LeftJoin` (.NET 10) - flat pairs, unmatched outers kept with `null`.
- `ToLookup` + `Select` - the same result built by hand.

## Query syntax

```csharp
var counts = from c in Data.Courses
             join e in Data.Enrollments on c.Id equals e.CourseId into es
             select (c.Code, es.Count());
```

## Exercises

Open `GroupJoinExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~GroupJoinExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_EnrollmentCountPerCourse` | (Code, number of enrollments) for every course - including QC999 with 0. |
| 2 | Easy | `Easy_02_StudentsWithNoEnrollments` | the Ids of students whose group of enrollments is empty. |
| 3 | Easy | `Easy_03_StudentsPerCohortViaGroupJoin` | join cohorts to students on Cohort.Id == Student.CohortId and count each cohort's students. |
| 4 | Medium | `Medium_04_CoursesPerInstructor` | (Instructor FirstName, list of course Codes). Mind the int vs int? key types. |
| 5 | Medium | `Medium_05_AverageGradePerCourseWithNullForEmpty` | (Code, average Grade) per course. Averaging an empty sequence of int? gives null rather than throwing, so QC999 comes out as null naturally. |
| 6 | Hard | `Hard_06_FlattenToALeftOuterJoin` | flatten the GroupJoin with SelectMany + DefaultIfEmpty so that every course appears at least once: (Code, EnrollmentId or null). 32 real rows plus one null row for QC999 = 33. |
| 7 | Hard | `Hard_07_GroupJoinWithAComparer` | for each tag in TagsA, the tags in TagsB that match ignoring case. |
<!-- exercises:end -->
