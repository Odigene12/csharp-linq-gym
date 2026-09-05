# Common pairs

| | |
|---|---|
| Module | 16 - Combinations |
| Exercises | 24, in three files |

Most real queries are two or three operators long, and the same handful of combinations appear over
and over. This folder drills them until they are reflexes, and shows where LINQ has a **shortcut**
for a pair (`Count(pred)` for `Where(pred).Count()`, `MinBy` for `OrderBy(k).First()`, ...).

| File | Theme |
|------|-------|
| `FilterProjectSortExercises.cs` | Where + Select, predicate overloads, OrderBy + ThenBy, MinBy vs OrderBy + First, Select + Distinct vs DistinctBy |
| `GroupAggregateExercises.cs` | GroupBy + Select/Count/Average/ToDictionary, HAVING-style group filters, Sum/Max selector overloads, CountBy |
| `JoinPageSetExercises.cs` | Skip + Take paging, Join + Where + Select, GroupJoin for orphans, SelectMany + Distinct, Contains filters, Top-N, marker slicing |

## Rules of thumb you will practise

- **Filter early, project late.** `Where` before `Select` when the predicate needs the original element.
- **Use the predicate overload** when the next call is `First`, `Single`, `Any`, `All`, `Count` or `Last`.
- **Sort once, at the end.** `OrderBy` buffers everything; put it after the filters.
- **GroupBy then Select** is SQL `GROUP BY`; **GroupBy then Where(group)** is `HAVING`.
- **Skip then Take** for paging; the other order is a different window.
- **Prefer the single-pass operator**: `MinBy`/`MaxBy` over sort + first, `CountBy` over group + count.

Run the whole folder:

```bash
dotnet test --filter "FullyQualifiedName~LinqGym.Combinations.FilterProjectSort|FullyQualifiedName~GroupAggregate|FullyQualifiedName~JoinPageSet"
```

<!-- exercises:start -->
**FilterProjectSortExercises.cs**

| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Pair | `Pair_01_WhereThenSelect` | the first names of the ACTIVE students who live in Nashville. Filter first, then project. |
| 2 | Pair | `Pair_02_SelectThenWhere` | first names longer than 5 characters. Here you must project first, because the filter is on the projection. (When the filter can run on the ORIGINAL element, put Where first - it does less work.) |
| 3 | Pair | `Pair_03_WhereFirstOrDefaultHasAShortcut` | the first student from Knoxville, written twice: Where(...).FirstOrDefault() and FirstOrDefault(predicate). The predicate overload exists for First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, Any, All and Count. |
| 4 | Pair | `Pair_04_WhereCountHasAShortcut` | the number of active students, both ways. |
| 5 | Pair | `Pair_05_WhereAnyHasAShortcut` | "is there an inactive instructor?", both ways. |
| 6 | Pair | `Pair_06_OrderByThenByThenSelect` | first names of students ordered by City then by Age (ascending). |
| 7 | Pair | `Pair_07_OrderByFirstVersusMinBy` | the oldest student, as OrderBy(Birthday).First() and as MinBy(Birthday). MinBy is a single pass and does no sorting. |
| 8 | Pair | `Pair_08_SelectDistinctVersusDistinctBy` | the distinct cities, as Select(City).Distinct() and as DistinctBy(City).Select(City). Same result; DistinctBy is the one to use when you need the whole element back, not just the key. |

**GroupAggregateExercises.cs**

| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Pair | `Pair_01_GroupByCountPerKey` | (CourseId, number of enrollments) for every course that has enrollments. |
| 2 | Pair | `Pair_02_GroupByOrderByCountFirst` | the most common City among students (group, order groups by size, take the first key). |
| 3 | Pair | `Pair_03_GroupByAverageHaving` | the CourseIds whose average Grade (graded enrollments only) is at least 85 - GroupBy + Where(group) like SQL HAVING. |
| 4 | Pair | `Pair_04_GroupByToDictionary` | City -> oldest Age in that city, as a dictionary. |
| 5 | Pair | `Pair_05_SelectSumVersusSumSelector` | total course Credits, as Select(...).Sum() and as Sum(selector). |
| 6 | Pair | `Pair_06_SelectMaxVersusMaxSelector` | the longest word length, both ways. |
| 7 | Pair | `Pair_07_GroupByThenSelectManyToRegroup` | the students re-ordered so that everyone from the same city sits together (group by City, then flatten). |
| 8 | Pair | `Pair_08_CountByIsGroupByCount` | students per city, once with CountBy and once with GroupBy + Select. Same (Key, Value) pairs. |

**JoinPageSetExercises.cs**

| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Pair | `Pair_01_SkipTakePaging` | page 2 of the students when the page size is 5 (students 6-10). |
| 2 | Pair | `Pair_02_OrderOfSkipAndTakeMatters` | Take(5).Skip(2) versus Skip(2).Take(5) over Data.Numbers - different results! |
| 3 | Pair | `Pair_03_JoinWhereSelectDistinct` | the distinct first names of students who scored 90 or more in any course (join enrollments to students). |
| 4 | Pair | `Pair_04_GroupJoinToFindOrphans` | course codes that have zero enrollments (GroupJoin, then keep empty groups). |
| 5 | Pair | `Pair_05_SelectManyDistinct` | the distinct Ids of every instructor attached to any cohort (primary first, then juniors, per cohort). |
| 6 | Pair | `Pair_06_ContainsFilterThenOrder` | the students whose Id is in `wanted`, oldest first. |
| 7 | Pair | `Pair_07_TopN` | the three highest grades (OrderByDescending + Take + Select). |
| 8 | Pair | `Pair_08_SliceBetweenTwoMarkers` | the numbers strictly between the first 8 and the second 8: SkipWhile to the first 8, Skip it, TakeWhile not 8. |
<!-- exercises:end -->
