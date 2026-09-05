# Union

| | |
|---|---|
| Category | 10 - Set operations |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Union on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.union) |

## What it does

`Union` yields the distinct elements of the first sequence followed by the distinct *new* elements of
the second. It is `Concat` + `Distinct` in one deferred, streaming operator - the SQL `UNION`.

## Signatures

```csharp
IEnumerable<T> Union<T>(this IEnumerable<T> first, IEnumerable<T> second);
IEnumerable<T> Union<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T>? comparer);
```

## How it behaves

- **Deferred and streaming**; duplicates *within* either input are removed too.
- Order: first-seen order across both inputs.
- Chain for more than two: `a.Union(b).Union(c)`.

## Watch out for

- Reference equality for classes - the same person from two lists is "the same" only if it is the same object.
- If you want duplicates kept, you want `Concat`.

## Compare with

- `Concat` - keeps everything.
- `UnionBy` - distinct by key.
- `Intersect` / `Except` - the other set operations.

## Query syntax

None.

## Exercises

Open `UnionExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~UnionExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_UnionOfTwoSets` | Data.SetA union Data.SetB. |
| 2 | Easy | `Easy_02_UnionRemovesDuplicatesWithinASequence` | Data.SetA union Data.Empty - the duplicate 5 inside SetA disappears. |
| 3 | Easy | `Easy_03_UnionWithNewWords` | Data.Words union ["kiwi", "apple"] - 9 distinct words plus kiwi. |
| 4 | Medium | `Medium_04_UnionIgnoringCase` | Data.TagsA union Data.TagsB, ignoring case. |
| 5 | Medium | `Medium_05_UnionOfJuniorInstructors` | the junior instructors of cohort 1 union those of cohort 3 (Ids). |
| 6 | Hard | `Hard_06_AllInstructorsInvolvedWithAnyCohort` | every distinct instructor who is a junior OR a primary instructor of some cohort, juniors first. |
| 7 | Hard | `Hard_07_UnionEqualsConcatPlusDistinct` | write SetA union SetB, and the same thing as Concat followed by Distinct. They must match. |
<!-- exercises:end -->
