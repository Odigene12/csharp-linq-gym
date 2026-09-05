# ToDictionary

| | |
|---|---|
| Category | 13 - Conversion |
| Available since | .NET Framework 3.5 (KeyValuePair / tuple overloads: .NET 8) |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.ToDictionary on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.todictionary) |

## What it does

`ToDictionary` materializes a sequence into a `Dictionary<TKey, TValue>` - one value per unique key,
O(1) lookup. Build it once, then look things up by key instead of scanning with `First(x => x.Id == id)`.

## Signatures

```csharp
Dictionary<TKey, T>  ToDictionary<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey>? comparer = null);
Dictionary<TKey, TV> ToDictionary<T, TKey, TV>(this IEnumerable<T> source, Func<T, TKey> keySelector, Func<T, TV> elementSelector, IEqualityComparer<TKey>? comparer = null);
Dictionary<TKey, TV> ToDictionary<TKey, TV>(this IEnumerable<KeyValuePair<TKey, TV>> source);   // .NET 8
Dictionary<TKey, TV> ToDictionary<TKey, TV>(this IEnumerable<(TKey Key, TV Value)> source);     // .NET 8
```

## How it behaves

- **Immediate.**
- **Duplicate key -> `ArgumentException`** ("An item with the same key has already been added"). Use `GroupBy`/`ToLookup` when keys repeat, or `DistinctBy` first.
- **Null key -> `ArgumentNullException`.**
- A comparer (`StringComparer.OrdinalIgnoreCase`) controls key matching.
- From `GroupBy`: `ToDictionary(g => g.Key, g => g.Count())`; from `CountBy`/`AggregateBy`: plain `.ToDictionary()`.

## Watch out for

- Lookups on a missing key throw `KeyNotFoundException`; use `TryGetValue` or `GetValueOrDefault`.
- Rebuilding the dictionary inside a loop defeats the purpose - build once, outside.

## Compare with

- `ToLookup` - many values per key, never throws.
- `ToHashSet` - keys only.
- `GroupBy` - deferred grouping.

## Query syntax

None.

## Exercises

Open `ToDictionaryExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ToDictionaryExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_StudentsById` | a dictionary of students keyed by Id (the element itself is the value). |
| 2 | Easy | `Easy_02_CourseTitlesByCode` | Code -> Title (use the key AND value selector overload). |
| 3 | Easy | `Easy_03_SquaresOfDistinctNumbers` | n -> n * n for the distinct values of Data.Numbers. |
| 4 | Medium | `Medium_04_DuplicateKeysThrow` | Data.Numbers keyed by value has duplicates (8 and 3) - ToDictionary throws ArgumentException. |
| 5 | Medium | `Medium_05_CaseInsensitiveKeys` | courses keyed by Code with StringComparer.OrdinalIgnoreCase so that "cs101" also works. |
| 6 | Medium | `Medium_06_DictionaryFromGroups` | City -> number of students (GroupBy then ToDictionary). |
| 7 | Medium | `Medium_07_DictionaryFromKeyValuePairs` | CountBy yields KeyValuePairs; the .NET 8+ ToDictionary() overload turns them straight into a dictionary. |
| 8 | Hard | `Hard_08_DictionaryOfLists` | City -> list of first names. |
| 9 | Hard | `Hard_09_NullKeysThrow` | keying students by Email fails with ArgumentNullException because some emails are null. |
| 10 | Hard | `Hard_10_UseADictionaryForFastLookups` | build a courses-by-Id dictionary once, then total the Credits of every enrollment through it. |
<!-- exercises:end -->
