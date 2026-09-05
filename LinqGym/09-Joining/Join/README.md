# Join

| | |
|---|---|
| Category | 09 - Joining |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Join on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.join) |

## What it does

`Join` is an **inner equi-join**: for every element of `outer` it finds the elements of `inner` whose
key is equal and calls your result selector for each pair. Elements without a partner on the other
side are dropped.

## Signature

```csharp
IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
    this IEnumerable<TOuter> outer, IEnumerable<TInner> inner,
    Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
    Func<TOuter, TInner, TResult> resultSelector,
    IEqualityComparer<TKey>? comparer = null);
```

## How it behaves

- **Deferred.** On first enumeration the *inner* sequence is read fully into a lookup; the outer is then streamed.
- **Output order:** outer order, and within one outer element, inner order.
- Keys must have the **same type** - `int?` vs `int` does not compile; cast one side (`i => (int?)i.Id`).
- Composite keys: use a tuple or anonymous type on both sides `(e.StudentId, e.CourseId)`.
- Chain joins for three or more tables; carry the pieces along in a tuple/anonymous type.
- Self-joins work (`students.Join(students, ...)`); filter `a.Id < b.Id` to get each pair once.

## Watch out for

- Inner join semantics: unmatched rows vanish silently. Use `GroupJoin`/`LeftJoin` when you need them.
- The comparer applies to the keys; `StringComparer.OrdinalIgnoreCase` makes text joins forgiving.
- Joining on a *collection-valued* relationship (cohort.Students) is usually a `SelectMany`, not a `Join`.

## Compare with

- `GroupJoin` - one result per outer with the matches grouped.
- `LeftJoin` / `RightJoin` (.NET 10) - outer joins.
- `Zip` - positional pairing, no keys.
- `Where` with `Any` - "exists" semantics without producing pairs.

## Query syntax

```csharp
var rows = from e in Data.Enrollments
           join s in Data.Students on e.StudentId equals s.Id
           join c in Data.Courses on e.CourseId equals c.Id
           select (s.FirstName, c.Code, e.Grade);
```

## Exercises

Open `JoinExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~JoinExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_EnrollmentsWithStudentNames` | join enrollments to students on StudentId == Id, producing (FirstName, CourseId). |
| 2 | Easy | `Easy_02_EnrollmentsWithCourseCodes` | join enrollments to courses, producing the course Code for each enrollment. |
| 3 | Easy | `Easy_03_CoursesWithInstructorNames` | join courses to instructors on InstructorId == Id, producing (Code, Instructor FullName). Course.InstructorId is int? while Instructor.Id is int - the key types must match, so cast one side. SE100 (no instructor) is dropped because inner joins only keep matches. |
| 4 | Medium | `Medium_04_ThreeWayJoin` | enrollment -> student -> course, producing (StudentFirstName, CourseCode, Grade). Chain two Joins. |
| 5 | Medium | `Medium_05_CompositeKeyJoin` | join enrollments to `bonuses` on BOTH StudentId and CourseId (use a tuple or anonymous type as the key), producing Grade + Bonus. |
| 6 | Medium | `Medium_06_UnmatchedOuterRowsDisappear` | join students to enrollments. Students 2, 12 and 17 have no enrollments and must not appear at all. |
| 7 | Medium | `Medium_07_JoinWithAComparer` | join Data.TagsA to Data.TagsB on the tag itself, ignoring case, producing (a, b) pairs. |
| 8 | Hard | `Hard_08_EnrollmentsPerInstructor` | (InstructorId, number of enrollments in that instructor's courses), most first, excluding courses with no instructor. |
| 9 | Hard | `Hard_09_SelfJoinStudentsSharingCohortAndBirthMonth` | pairs of students in the same cohort born in the same month (each pair once: a.Id < b.Id), as (FirstName, FirstName). |
| 10 | Hard | `Hard_10_StudentsTaughtByKateWilliams` | the distinct Ids of students enrolled in any course whose InstructorId is 1. |
<!-- exercises:end -->
