# Except

| | |
|---|---|
| Category | 10 - Set operations |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Except on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.except) |

## What it does

`Except` yields the distinct elements of the first sequence that do **not** appear in the second - the
set difference, SQL's `EXCEPT`.

## Signatures

```csharp
IEnumerable<T> Except<T>(this IEnumerable<T> first, IEnumerable<T> second);
IEnumerable<T> Except<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T>? comparer);
```

## How it behaves

- **Deferred**; second loaded into a set, first streamed, each survivor yielded once.
- **Not symmetric:** `A.Except(B)` and `B.Except(A)` differ.
- Also removes duplicates from the first sequence.
- "Students with no enrollments" = `students.Except(enrolledStudents)` when both hold the same object instances.

## Watch out for

- Reference equality for classes: build the "to remove" set from the same instances (`Data.Student(id)`), or use `ExceptBy`.
- If you need duplicates preserved, use `Where(x => !set.Contains(x))`.

## Compare with

- `ExceptBy` - by key.
- `Intersect` - the elements *in* the second.
- `Where` + `!Contains` - non-distinct alternative.

## Query syntax

None.

## Exercises

Open `ExceptExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ExceptExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_AMinusB` | the values in Data.SetA that are not in Data.SetB. |
| 2 | Easy | `Easy_02_BMinusA` | the values in Data.SetB that are not in Data.SetA. |
| 3 | Easy | `Easy_03_RemoveSpecificValues` | Data.Numbers without any 8 or 3 (and, being a set operation, without other duplicates too). |
| 4 | Medium | `Medium_04_ExceptIgnoringCase` | tags in TagsA that are not in TagsB, ignoring case. |
| 5 | Medium | `Medium_05_StudentsWithNoEnrollments` | students not present in the enrolled set. Build the enrolled students with Data.Student(e.StudentId) so the objects are the same references that live in Data.Students. |
| 6 | Hard | `Hard_06_InstructorsWhoAreNeverPrimary` | instructors who are not the PrimaryInstructor of any cohort (Ids). |
| 7 | Hard | `Hard_07_ExceptAlsoDeduplicatesTheFirstSequence` | [1, 1, 2, 2, 3] except [3] - notice the duplicates of 1 and 2 collapse. |
<!-- exercises:end -->
