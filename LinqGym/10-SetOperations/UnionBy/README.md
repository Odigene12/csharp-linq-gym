# UnionBy

| | |
|---|---|
| Category | 10 - Set operations |
| Available since | .NET 6 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.UnionBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.unionby) |

## What it does

`UnionBy` is `Union` where "the same element" means "the same **key**". It keeps the first element for
every key across both sequences - ideal for merging lists of entities by Id or Code.

## Signatures

```csharp
IEnumerable<T> UnionBy<T, TKey>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector);
IEnumerable<T> UnionBy<T, TKey>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector, IEqualityComparer<TKey>? comparer);
```

## How it behaves

- **Deferred and streaming**, first-seen wins (so elements of `first` take precedence over `second`).
- The key can be computed: lowercase, last digit, a tuple.

## Watch out for

- .NET 6+ only.
- Both sequences must have the same element type; the key is what is compared.

## Compare with

- `Union` - whole-element equality.
- `Concat(...).DistinctBy(k)` - equivalent.

## Query syntax

None.

## Exercises

Open `UnionByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~UnionByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_FirstStudentPerCityAcrossTwoCohorts` | students of cohort 1 union-by-City students of cohort 2 (Ids of the survivors). |
| 2 | Easy | `Easy_02_UnionByLowercase` | Data.Words union-by lower-cased value with ["KIWI", "Apple"]; only KIWI is new. |
| 3 | Easy | `Easy_03_UnionByLastDigit` | Data.Numbers union-by last digit (n % 10) with [12, 22, 13] - nothing new is added. |
| 4 | Medium | `Medium_04_UnionByWithAComparer` | TagsA union-by the tag itself with TagsB, ignoring case in the key comparison. |
| 5 | Medium | `Medium_05_MergeCourseListsByCode` | Data.Courses union-by Code with `incoming` - the duplicate CS101 is ignored, ML101 is added. |
| 6 | Hard | `Hard_06_OneInstructorPerSpecialty` | primary instructors union-by Specialty with all junior instructors (Ids). |
| 7 | Hard | `Hard_07_FirstEnrollmentPerStudentAcrossYears` | 2024 enrollments union-by StudentId with 2025 enrollments - one enrollment per student, 17 in total. |
<!-- exercises:end -->
