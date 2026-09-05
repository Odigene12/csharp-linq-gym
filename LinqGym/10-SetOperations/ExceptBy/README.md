# ExceptBy

| | |
|---|---|
| Category | 10 - Set operations |
| Available since | .NET 6 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.ExceptBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.exceptby) |

## What it does

`ExceptBy(keys, keySelector)` yields the elements of the first sequence whose **key** is *not* in the
given sequence of keys. "Students not in this Id list", "courses nobody enrolled in".

## Signatures

```csharp
IEnumerable<T> ExceptBy<T, TKey>(this IEnumerable<T> first, IEnumerable<TKey> second, Func<T, TKey> keySelector);
IEnumerable<T> ExceptBy<T, TKey>(this IEnumerable<T> first, IEnumerable<TKey> second, Func<T, TKey> keySelector, IEqualityComparer<TKey>? comparer);
```

## How it behaves

- **Deferred**; keys loaded into a set, first streamed.
- **Distinct by key** - once a key has been yielded (or excluded) it is never yielded again. `Courses.ExceptBy(["Backend"], c => c.Category)` returns *one course per remaining category*, not every non-Backend course.
- Second argument is a sequence of **keys**.

## Watch out for

- The distinct-by-key rule surprises people who expect a plain filter. For "all elements whose key is not in the set" use `Where(x => !keySet.Contains(k(x)))`.
- Key types must match (`int?` vs `int`).

## Compare with

- `Except` - whole-element equality.
- `IntersectBy` - the complement.
- `Where` + `!Contains` - filter semantics without de-duplication.

## Query syntax

None.

## Exercises

Open `ExceptByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ExceptByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_StudentsExceptSomeIds` | students whose Id is not 1, 2 or 3. |
| 2 | Easy | `Easy_02_WordsExceptLengths` | words whose Length is neither 5 nor 6. |
| 3 | Easy | `Easy_03_CoursesOutsideACategory` | courses whose Category is not "Backend". Remember: ExceptBy is distinct BY KEY, so only the first course of each remaining category survives (Frontend, Data, Research, General). |
| 4 | Medium | `Medium_04_ExceptByWithAComparer` | words except "APPLE" and "banana" ignoring case; remember the result is distinct by key. |
| 5 | Medium | `Medium_05_StudentsNeverEnrolled` | students whose Id is not in the StudentIds of Data.Enrollments. |
| 6 | Hard | `Hard_06_CoursesNobodyEnrolledIn` | courses whose Id never appears as an enrollment CourseId. |
| 7 | Hard | `Hard_07_ExceptByDeduplicates` | Data.Numbers except-by value [1] - the duplicate 8 and 3 collapse to one each. |
<!-- exercises:end -->
