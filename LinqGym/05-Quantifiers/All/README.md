# All

| | |
|---|---|
| Category | 05 - Quantifiers |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.All on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.all) |

## What it does

`All(predicate)` answers "does every element match?". It stops at the first element that does not.

## Signature

```csharp
bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate);
```

## How it behaves

- **Immediate** and **short-circuiting** on the first failure.
- **Empty sequence -> `true`.** This is "vacuous truth": there is no element that fails. It surprises people constantly ("every course with no enrollments has all grades above 70").
- Nested inside `Where`, it expresses "parents whose children all match".
- `All(p)` is equivalent to `!Any(!p)`.

## Watch out for

- The empty-is-true rule: when the sequence might be empty and you need "at least one AND all", write `xs.Any() && xs.All(p)`.
- There is no `All()` without a predicate.

## Compare with

- `Any` - at least one; false for empty.
- `Contains` - membership of one value.

## Query syntax

None.

## Exercises

Open `AllExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~AllExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_AllNumbersPositive` | are all numbers greater than zero? |
| 2 | Easy | `Easy_02_NotAllStudentsActive` | are all students active? |
| 3 | Easy | `Easy_03_AllOnAnEmptySequenceIsTrue` | All over Data.Empty - there is no element that fails the predicate, so the answer is true. |
| 4 | Medium | `Medium_04_AllInstructorsBornBefore2000` | were all instructors born before the year 2000? (Check Zachary...) |
| 5 | Medium | `Medium_05_AllWordsNonEmpty` | does every word have at least one character? |
| 6 | Medium | `Medium_06_EveryCohortHasFiveStudents` | does every cohort have exactly five students? |
| 7 | Medium | `Medium_07_CohortsWhereAllStudentsAreActive` | the cohorts in which every student is active (All inside a Where). |
| 8 | Hard | `Hard_08_AllShortCircuits` | pass Data.Numbers through a counting Select, then ask All(n => n < 8). The first failure (8) is at index 2, so exactly three elements are evaluated. |
| 9 | Hard | `Hard_09_CoursesWhereEveryGradeIsAtLeastSeventy` | courses where every GRADED enrollment (Grade not null) is >= 70. QC999 has no enrollments at all - All over an empty set is true, so it is included. |
| 10 | Hard | `Hard_10_AllIsTheSameAsNotAny` | "every student is an adult" written both ways: with All, and as the negation of Any. |
<!-- exercises:end -->
