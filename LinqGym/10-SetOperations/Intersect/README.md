# Intersect

| | |
|---|---|
| Category | 10 - Set operations |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Intersect on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.intersect) |

## What it does

`Intersect` yields the distinct elements that appear in **both** sequences, in the order of the first.

## Signatures

```csharp
IEnumerable<T> Intersect<T>(this IEnumerable<T> first, IEnumerable<T> second);
IEnumerable<T> Intersect<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T>? comparer);
```

## How it behaves

- **Deferred.** On first enumeration the *second* sequence is loaded into a set; the first is then streamed and each element is yielded once if the set contains it.
- Result elements come from the **first** sequence (matters with case-insensitive comparers: `TagsA.Intersect(TagsB, IgnoreCase)` yields TagsA's spelling).
- Strings are sequences of chars, so `"linq".Intersect("language")` gives the common letters.

## Watch out for

- Reference equality for classes.
- The result is distinct - duplicates in the first sequence appear once.

## Compare with

- `IntersectBy` - membership by key against a sequence of keys.
- `Where(x => other.Contains(x))` - similar, but keeps duplicates and is O(n*m) without a set.
- `Except` - the elements *not* in the second.

## Query syntax

None.

## Exercises

Open `IntersectExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~IntersectExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_CommonNumbers` | the values in both Data.SetA and Data.SetB. |
| 2 | Easy | `Easy_02_IntersectWithAnArray` | the values of Data.Numbers that are also in [3, 8, 100]. |
| 3 | Easy | `Easy_03_IntersectWithEmpty` | anything intersected with Data.Empty is empty. |
| 4 | Medium | `Medium_04_IntersectIgnoringCase` | tags present in both TagsA and TagsB ignoring case (elements come from TagsA). |
| 5 | Medium | `Medium_05_SharedJuniorInstructors` | junior instructors shared by cohort 1 and cohort 3 (Ids). |
| 6 | Hard | `Hard_06_StudentsInBothCourses` | the StudentIds enrolled in course 1 AND course 2. |
| 7 | Hard | `Hard_07_CommonCharacters` | the characters that "linq" and "language" have in common. |
<!-- exercises:end -->
