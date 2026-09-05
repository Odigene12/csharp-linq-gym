# CountBy

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET 9 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.CountBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.countby) |

## What it does

`CountBy(keySelector)` counts how many elements share each key and yields
`KeyValuePair<TKey, int>` results, in the order keys were first seen. It replaces
`GroupBy(k).Select(g => (g.Key, g.Count()))` without materializing the groups.

## Signatures

```csharp
IEnumerable<KeyValuePair<TKey, int>> CountBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector);
IEnumerable<KeyValuePair<TKey, int>> CountBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey>? comparer);
```

## How it behaves

- **Deferred**, but the whole source is consumed on the first `MoveNext` (it needs every element to know the counts).
- The reported key for a group is the first key value encountered (with a case-insensitive comparer, "apple" - not "APPLE").
- `.ToDictionary()` (the .NET 8 `KeyValuePair` overload) turns the result into a lookup; `.MaxBy(kv => kv.Value)` finds the mode.

## Watch out for

- .NET 9+ only.
- Results are pairs, not groups - if you need the elements too, use `GroupBy` or `ToLookup`.

## Compare with

- `GroupBy(k).Select(g => g.Count())` - the pre-.NET-9 spelling.
- `AggregateBy` - any accumulator per key, not just a count.
- `Count(predicate)` - a single count.

## Query syntax

None.

## Exercises

Open `CountByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~CountByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_StudentsPerCity` | how many students live in each city. |
| 2 | Easy | `Easy_02_OccurrencesOfEachNumber` | how many times each value appears in Data.Numbers. |
| 3 | Easy | `Easy_03_WordsPerLength` | how many words have each Length. |
| 4 | Medium | `Medium_04_CountByWithAComparer` | count words ignoring case. The key that is reported is the first spelling seen ("apple", "Banana"). |
| 5 | Medium | `Medium_05_ActiveVersusInactive` | how many students are active vs inactive (key = Active). |
| 6 | Hard | `Hard_06_MostPopularCourse` | the (CourseId, count) pair with the most enrollments. |
| 7 | Hard | `Hard_07_StudentsPerBirthDecade` | count students per birth decade (1940, 1950, ...); convert to a Dictionary for the assertions. |
<!-- exercises:end -->
