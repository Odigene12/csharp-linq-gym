# LastOrDefault

| | |
|---|---|
| Category | 06 - Element operators |
| Available since | .NET Framework 3.5 (default-value overloads: .NET 6) |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.LastOrDefault on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.lastordefault) |

## What it does

`Last` that returns `default(T)` (or a supplied default) instead of throwing when nothing is found.

## Signatures

```csharp
T? LastOrDefault<T>(this IEnumerable<T> source);
T? LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate);
T  LastOrDefault<T>(this IEnumerable<T> source, T defaultValue);
T  LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue);
```

## How it behaves

- **Immediate**; reads to the end for non-indexable sources.
- With a predicate over a sorted sequence it is "the latest that still satisfies X".
- Chain `?.` for safe member access.

## Watch out for

- Same value-type ambiguity as `FirstOrDefault`: `0`/`false` may be real data.

## Compare with

- `Last` - throws on miss.
- `FirstOrDefault` - from the front.
- `MaxBy` - when "last" really means "largest key".

## Query syntax

None.

## Exercises

Open `LastOrDefaultExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~LastOrDefaultExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_NoMatchGivesZero` | the last number greater than 100 (there is none). |
| 2 | Easy | `Easy_02_NoMatchGivesNull` | the last student living in "Paris" (there is none). |
| 3 | Easy | `Easy_03_EmptyGivesDefault` | LastOrDefault() on Data.Empty. |
| 4 | Medium | `Medium_04_ExplicitDefaultValue` | -1 when no number is greater than 100 (use the overload with a default value). |
| 5 | Medium | `Medium_05_LastEnrollmentOfStudentNine` | the last enrollment (in list order) belonging to student 9. |
| 6 | Hard | `Hard_06_LastEnrollmentOf2024ByDate` | order enrollments by EnrolledOn and return the last one from 2024. Four enrollments share the last 2024 date; the stable sort keeps them in list order. |
| 7 | Hard | `Hard_07_NullConditionalChain` | the FirstName of the last student without an email, using ?. after LastOrDefault. |
<!-- exercises:end -->
