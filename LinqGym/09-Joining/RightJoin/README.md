# RightJoin

| | |
|---|---|
| Category | 09 - Joining |
| Available since | .NET 10 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.RightJoin on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.rightjoin) |

## What it does

`RightJoin` keeps every **inner** element: matched inners produce one row per match, unmatched inners
produce one row with a `default` outer. It is `LeftJoin` with the roles swapped - useful when the
sequence you are iterating "from" is the one that may lack partners.

## Signature

```csharp
IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(
    this IEnumerable<TOuter> outer, IEnumerable<TInner> inner,
    Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
    Func<TOuter?, TInner, TResult> resultSelector,
    IEqualityComparer<TKey>? comparer = null);
```

## How it behaves

- **Deferred**; the *outer* is read into a lookup and the inner is streamed, so the output follows **inner** order.
- The result selector's *first* argument is the nullable one.
- `a.RightJoin(b, ...)` yields the same rows as `b.LeftJoin(a, ...)` (possibly in a different order).

## Watch out for

- .NET 10+ only.
- Easy to confuse which side is nullable - the selector signature tells you: `(TOuter? o, TInner i)`.

## Compare with

- `LeftJoin` - mirror image.
- `GroupJoin` starting from the other sequence - the pre-.NET-10 way.

## Query syntax

None.

## Exercises

Open `RightJoinExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~RightJoinExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_EveryCourseAppears` | enrollments RIGHT-joined to courses, producing (EnrollmentId?, Code). 33 rows. |
| 2 | Easy | `Easy_02_EveryStudentAppears` | enrollments right-joined to students; 32 matches + 3 students without enrollments = 35 rows. |
| 3 | Easy | `Easy_03_EveryInstructorAppears` | courses right-joined to instructors on InstructorId == Id (cast the int to int?). Terry has no course. |
| 4 | Medium | `Medium_04_StudentsWithNoEnrollmentViaRightJoin` | the first names of the students whose outer (enrollment) side is null. |
| 5 | Medium | `Medium_05_RightJoinIsASwappedLeftJoin` | express "every course with its enrollments" both ways: courses.LeftJoin(enrollments) and enrollments.RightJoin(courses). Both yield 33 (Code, EnrollmentId?) rows. |
| 6 | Hard | `Hard_06_CoursesPerInstructorIncludingZero` | (Instructor FirstName, course count) for every instructor, counting only real matches. |
| 7 | Hard | `Hard_07_CoursesNobodyTook` | the Codes of courses that have no enrollments, found with a RightJoin. |
<!-- exercises:end -->
