# GroupBy

| | |
|---|---|
| Category | 08 - Grouping |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.GroupBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.groupby) |

## What it does

`GroupBy` buckets elements by a key. The result is a sequence of `IGrouping<TKey, TElement>` - each
grouping is itself a sequence of the elements that share `Key`. It is SQL's `GROUP BY`, but the
groups keep their elements, so you can do far more than aggregate.

## Signatures (the useful subset)

```csharp
IEnumerable<IGrouping<TKey, T>> GroupBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector);
IEnumerable<IGrouping<TKey, TElem>> GroupBy<T, TKey, TElem>(this IEnumerable<T> source, Func<T, TKey> keySelector, Func<T, TElem> elementSelector);
IEnumerable<TResult> GroupBy<T, TKey, TResult>(this IEnumerable<T> source, Func<T, TKey> keySelector, Func<TKey, IEnumerable<T>, TResult> resultSelector);
// ... every combination, each with an optional IEqualityComparer<TKey>
```

## How it behaves

- **Deferred**, but the *entire* source is consumed on the first `MoveNext` - grouping cannot stream.
- Groups come out in the order their keys were **first seen**; elements inside a group keep source order.
- Keys can be anything with equality: strings, numbers, bools, tuples `(Year, CourseId)`, anonymous types, records. Classes group by reference unless you pass a comparer.
- `elementSelector` shrinks what is stored per group; `resultSelector` projects each group straight to a result.
- `null` is a valid key.

## Watch out for

- Filtering groups (`Where(g => g.Count() > 3)`) is SQL's `HAVING`; filtering elements *before* grouping is `WHERE`. They answer different questions.
- Re-enumerating a `GroupBy` re-runs the whole grouping. Materialize (`ToList()`/`ToLookup`) if you use it more than once.
- `g.Count()` on an `IGrouping` is O(n) per call - fine, but do not call it in a tight loop over big groups.

## Compare with

- `ToLookup` - the same buckets, immediate, indexable by key.
- `CountBy` / `AggregateBy` (.NET 9) - when you only need a number per key.
- `GroupJoin` - group *another* sequence by keys of this one.
- `Chunk` - groups by position, not key.

## Query syntax

```csharp
var byCity = from s in Data.Students
             group s by s.City into g
             where g.Count() > 3
             select (g.Key, g.Count());
```

## Exercises

Open `GroupByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~GroupByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_StudentsByCity` | group students by City. |
| 2 | Easy | `Easy_02_NumbersByParity` | group numbers by whether they are even (key = bool). |
| 3 | Easy | `Easy_03_WordsByLength` | group words by Length. |
| 4 | Medium | `Medium_04_CountPerGroup` | (City, StudentCount) pairs - GroupBy followed by Select. |
| 5 | Medium | `Medium_05_ElementSelector` | group by City but keep only FirstName as the element (use the elementSelector overload). |
| 6 | Medium | `Medium_06_ResultSelector` | use the resultSelector overload (key, elements) => ... to get (CourseId, AverageGrade) per course. |
| 7 | Medium | `Medium_07_GroupByWithAComparer` | group words ignoring case; "apple", "apple" and "APPLE" end up in one group. |
| 8 | Hard | `Hard_08_CompositeKey` | group enrollments by (Year of EnrolledOn, CourseId) using a tuple or anonymous type as the key. |
| 9 | Hard | `Hard_09_OldestStudentPerCity` | for each city (in first-seen order), the FirstName of its oldest student. |
| 10 | Hard | `Hard_10_FilterGroupsLikeSqlHaving` | the cities that have MORE than three students (filter the groups, then project the keys). |
<!-- exercises:end -->
