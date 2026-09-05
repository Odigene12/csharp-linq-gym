# Single

| | |
|---|---|
| Category | 06 - Element operators |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Single on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.single) |

## What it does

`Single()` returns the one and only element; `Single(predicate)` the one and only match. It throws
`InvalidOperationException` when there are **zero** matches *and* when there are **two or more**. Use it
to assert a uniqueness invariant ("there is exactly one course with this code") - it turns a data
problem into an immediate, loud failure.

## Signatures

```csharp
T Single<T>(this IEnumerable<T> source);
T Single<T>(this IEnumerable<T> source, Func<T, bool> predicate);
```

## How it behaves

- **Immediate.** Unlike `First`, it cannot stop at the first match - it must look for a second one, so it reads until it finds a second match or reaches the end.
- On an `IQueryable` it becomes `TOP 2`, which is how providers detect duplicates cheaply.

## Watch out for

- The two failure modes have different messages: "Sequence contains no elements" vs "Sequence contains more than one element". Read them - they tell you which invariant broke.
- `Single` inside a `Where` over many elements is a trap: one duplicate anywhere throws for every caller.
- If a miss is normal, use `SingleOrDefault`; if duplicates are normal, use `First`.

## Compare with

- `First` - takes the first of many without complaint.
- `SingleOrDefault` - tolerates zero, still rejects many.
- `Count(p) == 1` - a non-throwing way to *test* uniqueness.

## Query syntax

None.

## Exercises

Open `SingleExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~SingleExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_StudentWithIdSeven` | the single student whose Id is 7. |
| 2 | Easy | `Easy_02_CohortWithThreeJuniorInstructors` | the only cohort that has exactly three junior instructors. |
| 3 | Easy | `Easy_03_CourseWithoutInstructor` | the only course whose InstructorId is null. |
| 4 | Medium | `Medium_04_SingleOnAOneElementSequence` | Single() without a predicate on a sequence that has exactly one element. |
| 5 | Medium | `Medium_05_MultipleMatchesThrow` | ask for the Single student from Memphis. Four match, so Single must throw. |
| 6 | Medium | `Medium_06_NoMatchThrows` | ask for the Single student named "Zelda". None match, so Single must throw. |
| 7 | Medium | `Medium_07_SingleOnManyElementsThrows` | Single() with no predicate on Data.Numbers (10 elements) must throw. |
| 8 | Hard | `Hard_08_FullTimeCohortWithAFuturisticInstructor` | the single cohort that is FullTime AND whose PrimaryInstructor was born after the year 2100. |
| 9 | Hard | `Hard_09_SingleThenMemberAccess` | the LastName of the single instructor whose Specialty is "Quantum". |
| 10 | Hard | `Hard_10_SingleVersusFirst` | four students live in Knoxville. First happily returns the first one; Single throws. |
<!-- exercises:end -->
