# IntersectBy

| | |
|---|---|
| Category | 10 - Set operations |
| Available since | .NET 6 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.IntersectBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.intersectby) |

## What it does

`IntersectBy(keys, keySelector)` yields the elements of the first sequence whose **key** is in the second
sequence - and the second sequence is a sequence of **keys**, not of elements. "Students whose Id is in
this list of Ids", "courses whose category is one of these".

## Signatures

```csharp
IEnumerable<T> IntersectBy<T, TKey>(this IEnumerable<T> first, IEnumerable<TKey> second, Func<T, TKey> keySelector);
IEnumerable<T> IntersectBy<T, TKey>(this IEnumerable<T> first, IEnumerable<TKey> second, Func<T, TKey> keySelector, IEqualityComparer<TKey>? comparer);
```

## How it behaves

- **Deferred**; the keys are loaded into a set, the first sequence is streamed.
- **Distinct by key:** only the *first* element for each matching key is yielded. `Words.IntersectBy([5], w => w.Length)` returns just `"apple"`, not all four five-letter words.
- Key types must match exactly (`int?` vs `int`).

## Watch out for

- The asymmetric signature trips people up: second argument = keys.
- If you want *every* element whose key matches (duplicates included), use `Where(x => keySet.Contains(k(x)))`.

## Compare with

- `Intersect` - whole-element equality between two element sequences.
- `Where` + `Contains` - keeps duplicates.
- `ExceptBy` - the complement.

## Query syntax

None.

## Exercises

Open `IntersectByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~IntersectByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_StudentsWithGivenIds` | students whose Id is in [3, 5, 99]. |
| 2 | Easy | `Easy_02_ResultIsDistinctByKey` | words whose Length is 5. Four words qualify, but IntersectBy yields only the FIRST per key. |
| 3 | Easy | `Easy_03_FirstCoursePerWantedCategory` | courses whose Category is Backend or Data (first per category). |
| 4 | Medium | `Medium_04_IntersectByWithAComparer` | words matching ["BANANA", "grape"] ignoring case. |
| 5 | Medium | `Medium_05_EnrollmentsOfInactiveStudents` | enrollments whose StudentId belongs to an inactive student (only Kate, id 11, has one). |
| 6 | Hard | `Hard_06_StudentsWhoHaveAnyEnrollment` | the students whose Id appears in Data.Enrollments. |
| 7 | Hard | `Hard_07_CoursesTaughtByActiveInstructors` | courses whose InstructorId is the Id of an ACTIVE instructor. Key types must match (int? vs int). |
<!-- exercises:end -->
