# AggregateBy

| | |
|---|---|
| Category | 07 - Aggregation |
| Available since | .NET 9 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.AggregateBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.aggregateby) |

## What it does

`AggregateBy` runs an `Aggregate` **per key**: one accumulator for every distinct key, updated with each
element of that key, yielded as `KeyValuePair<TKey, TAccumulate>`. Sums, maxes, concatenations,
lists-per-key - all in one pass and without building `IGrouping` objects.

## Signatures

```csharp
IEnumerable<KeyValuePair<TKey, TAcc>> AggregateBy<T, TKey, TAcc>(this IEnumerable<T> source,
    Func<T, TKey> keySelector, TAcc seed, Func<TAcc, T, TAcc> func, IEqualityComparer<TKey>? comparer = null);
IEnumerable<KeyValuePair<TKey, TAcc>> AggregateBy<T, TKey, TAcc>(this IEnumerable<T> source,
    Func<T, TKey> keySelector, Func<TKey, TAcc> seedSelector, Func<TAcc, T, TAcc> func, IEqualityComparer<TKey>? comparer = null);
```

## How it behaves

- **Deferred**, whole source consumed on first enumeration, keys in first-seen order.
- **Seed value vs seed factory:** a plain `seed` is copied per key - fine for ints, strings, tuples. For *mutable* accumulators (a `List<T>`) use the `seedSelector` overload so every key gets its own instance.
- Follow with `Select` to post-process each accumulator (turn a `(sum, count)` tuple into an average).

## Watch out for

- .NET 9+ only.
- Passing one shared `new List<int>()` as the seed value means every key appends to the same list.

## Compare with

- `GroupBy(k).Select(g => g.Aggregate(...))` - the older two-step form.
- `CountBy` - the special case where the accumulator is a count.
- `ToLookup` - when you need the elements themselves.

## Query syntax

None.

## Exercises

Open `AggregateByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~AggregateByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_CreditsPerCategory` | total Credits per course Category. |
| 2 | Easy | `Easy_02_SumByParity` | the sum of odd numbers and the sum of even numbers (key = n % 2). |
| 3 | Easy | `Easy_03_BestGradePerCourse` | the highest Grade per CourseId, considering graded enrollments only. |
| 4 | Medium | `Medium_04_FirstNamesPerCity` | a comma-separated string of first names per city ("Gary, Matt, Richard" for Chattanooga). |
| 5 | Medium | `Medium_05_SeedFactoryForMutableAccumulators` | the list of CourseIds per StudentId. A List is mutable, so each key needs its OWN list - use the seed-factory overload (key => new List<int>()) rather than passing one shared list. |
| 6 | Hard | `Hard_06_AggregateByWithAComparer` | count words ignoring case using AggregateBy (seed 0, add 1 per word, StringComparer.OrdinalIgnoreCase). |
| 7 | Hard | `Hard_07_AverageGradePerCourse` | (CourseId, AverageGrade) per course using a (Sum, Count) tuple accumulator over graded enrollments, then a Select to divide. Course 1 averages 79.625. |
<!-- exercises:end -->
