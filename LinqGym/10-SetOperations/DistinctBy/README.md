# DistinctBy

| | |
|---|---|
| Category | 10 - Set operations |
| Available since | .NET 6 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.DistinctBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.distinctby) |

## What it does

`DistinctBy(keySelector)` keeps the first element for each distinct **key** and drops the rest. It
answers "one student per city", "one enrollment per student" - things `Distinct` cannot do on classes.

## Signatures

```csharp
IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector);
IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey>? comparer);
```

## How it behaves

- **Deferred and streaming**, order preserved, first element per key wins.
- Composite keys via tuples: `DistinctBy(s => (s.City, s.Active))`.
- "Latest per key" = sort descending by date, then `DistinctBy(key)` - stability guarantees the newest survives.

## Watch out for

- .NET 6+ only.
- The comparer compares *keys*, not elements.
- If you only need the keys, `Select(k).Distinct()` is simpler.

## Compare with

- `Distinct` - whole-element equality.
- `GroupBy(k).Select(g => g.First())` - the pre-.NET-6 equivalent.
- `UnionBy` / `IntersectBy` / `ExceptBy` - the same "by key" idea across two sequences.

## Query syntax

None.

## Exercises

Open `DistinctByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~DistinctByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_FirstStudentPerCity` | one student per City - the first one seen. |
| 2 | Easy | `Easy_02_FirstWordPerLength` | one word per Length. |
| 3 | Easy | `Easy_03_OneEnrollmentPerCourse` | one enrollment per CourseId (7 courses have enrollments). |
| 4 | Medium | `Medium_04_DistinctByWithAComparer` | words distinct by themselves, ignoring case (pass StringComparer.OrdinalIgnoreCase as the key comparer). |
| 5 | Medium | `Medium_05_OneStudentPerBirthYear` | one student per birth year. |
| 6 | Hard | `Hard_06_NewestEnrollmentPerStudent` | each student's most recent enrollment: order by EnrolledOn descending, then DistinctBy StudentId. Student 1 has two enrollments on the same latest date - the stable sort keeps id 2 before id 3. |
| 7 | Hard | `Hard_07_CompositeKey` | how many distinct (City, Active) combinations exist among students. |
<!-- exercises:end -->
