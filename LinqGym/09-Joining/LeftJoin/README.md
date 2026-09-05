# LeftJoin

| | |
|---|---|
| Category | 09 - Joining |
| Available since | .NET 10 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.LeftJoin on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.leftjoin) |

## What it does

`LeftJoin` is a **left outer join** in one call: every outer element appears at least once; when it
has matches you get one row per match, when it has none you get one row whose inner value is
`default` (`null` for classes). Before .NET 10 this took `GroupJoin` + `SelectMany` + `DefaultIfEmpty`.

## Signature

```csharp
IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(
    this IEnumerable<TOuter> outer, IEnumerable<TInner> inner,
    Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
    Func<TOuter, TInner?, TResult> resultSelector,
    IEqualityComparer<TKey>? comparer = null);
```

## How it behaves

- **Deferred**; inner read into a lookup, outer streamed, output in outer order.
- The result selector's second argument is nullable - use `?.` and `??` inside it.
- Row count = matches + unmatched outers.

## Watch out for

- .NET 10+ only. For older targets keep the `GroupJoin` recipe (the exercises show both give identical output).
- If the inner is a value type, "no match" is `default(T)` (e.g. `0`), which may collide with real data - project to a nullable first.

## Compare with

- `GroupJoin` + `DefaultIfEmpty` - the portable equivalent.
- `RightJoin` - keeps every *inner* element instead.
- `Join` - drops unmatched rows.

## Query syntax

None dedicated - use `join ... into ... from ... DefaultIfEmpty()`.

## Exercises

Open `LeftJoinExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~LeftJoinExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_CoursesWithEnrollments` | (Code, EnrollmentId?) for every course/enrollment pair, keeping courses with no enrollments. |
| 2 | Easy | `Easy_02_StudentsWithoutEnrollmentsGetANullRow` | left join students to enrollments; count the rows whose enrollment is null. |
| 3 | Easy | `Easy_03_CoursesWithInstructorOrUnassigned` | (Code, instructor FullName or "unassigned"). Course.InstructorId is int?, so cast the instructor Id. |
| 4 | Medium | `Medium_04_InstructorsWithTheirCourses` | (Instructor FirstName, Course Code or null) - Terry teaches nothing and still gets one row. |
| 5 | Medium | `Medium_05_CoalesceMissingValues` | (Code, Grade) rows where a missing enrollment OR a null grade becomes -1. |
| 6 | Hard | `Hard_06_CountPerCourseIncludingZero` | enrollment counts per course (in course order) from a LeftJoin + GroupBy, counting only non-null matches. |
| 7 | Hard | `Hard_07_LeftJoinEqualsTheClassicRecipe` | write the same left join twice - once with LeftJoin and once with GroupJoin/SelectMany/DefaultIfEmpty - and show they produce identical (Code, EnrollmentId?) rows. |
<!-- exercises:end -->
