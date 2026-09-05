# SingleOrDefault

| | |
|---|---|
| Category | 06 - Element operators |
| Available since | .NET Framework 3.5 (default-value overloads: .NET 6) |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.SingleOrDefault on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.singleordefault) |

## What it does

`Single` that returns `default(T)` (or a supplied default) when there are **no** matches. It still throws
when there is more than one - the "OrDefault" only covers the empty case.

## Signatures

```csharp
T? SingleOrDefault<T>(this IEnumerable<T> source);
T? SingleOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate);
T  SingleOrDefault<T>(this IEnumerable<T> source, T defaultValue);
T  SingleOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue);
```

## How it behaves

- **Immediate**; scans for a second match like `Single`.
- The natural choice for "look up by unique key, may not exist": `courses.SingleOrDefault(c => c.Code == code)?.Title`.

## Watch out for

- People reach for it as an "exists exactly once?" check inside `Where`. The moment any element has two matches, it throws. Use `Count(p) == 1` for that question.
- Same value-type default ambiguity as the other `*OrDefault` methods.

## Compare with

- `Single` - throws on zero too.
- `FirstOrDefault` - never complains about duplicates.
- `ToDictionary` - if you keep looking things up by a unique key, build a dictionary once.

## Query syntax

None.

## Exercises

Open `SingleOrDefaultExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~SingleOrDefaultExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_NoMatchGivesNull` | the student with Id 99 (none). |
| 2 | Easy | `Easy_02_ExactlyOneMatch` | the student with Id 5. |
| 3 | Easy | `Easy_03_EmptySequenceGivesDefault` | SingleOrDefault() on Data.Empty. |
| 4 | Medium | `Medium_04_ExplicitDefaultValue` | -1 when no number is greater than 100 (overload with a default value). |
| 5 | Medium | `Medium_05_MultipleMatchesStillThrow` | SingleOrDefault for active students - 16 match, so it throws even though it is the "OrDefault" variant. |
| 6 | Medium | `Medium_06_CourseCodeLookupMiss` | the course with Code "XX999" (none). |
| 7 | Medium | `Medium_07_OnlyEnrollmentOfStudentSeven` | student 7 has exactly one enrollment - return it. |
| 8 | Hard | `Hard_08_NoCohortTaughtByZelda` | the cohort whose PrimaryInstructor's FirstName is "Zelda" (none). |
| 9 | Hard | `Hard_09_NullConditionalChain` | the Title of the course with Code "QC999", via SingleOrDefault(...)?.Title. |
| 10 | Hard | `Hard_10_DoNotUseSingleOrDefaultAsAnExistsCheck` | "students with exactly one enrollment". A naive SingleOrDefault inside Where THROWS as soon as it meets a student with two enrollments. Write the naive version inside Assert.Throws, then the correct version using Count(...) == 1. |
<!-- exercises:end -->
