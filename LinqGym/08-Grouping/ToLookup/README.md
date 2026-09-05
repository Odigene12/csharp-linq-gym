# ToLookup

| | |
|---|---|
| Category | 08 - Grouping |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.ToLookup on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.tolookup) |

## What it does

`ToLookup` builds an `ILookup<TKey, TElement>`: a read-only, one-to-many dictionary. `lookup[key]`
returns every element with that key - or an **empty sequence** for an unknown key, never an exception.

## Signatures

```csharp
ILookup<TKey, T> ToLookup<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector);
ILookup<TKey, TElem> ToLookup<T, TKey, TElem>(this IEnumerable<T> source, Func<T, TKey> keySelector, Func<T, TElem> elementSelector);
// ... each with an optional IEqualityComparer<TKey>
```

## How it behaves

- **Immediate** - a snapshot; later changes to the source are not reflected.
- `lookup.Count` = number of keys; `lookup.Contains(key)`; enumerating a lookup yields `IGrouping`s.
- Built once, queried many times: the right tool when you would otherwise call `Where(e => e.Key == x)` inside a loop.

## Watch out for

- Immutable - you cannot add to a lookup after creation.
- Unlike `Dictionary`, duplicate keys are the whole point.
- Memory: it holds every element; for a single pass `GroupBy` is enough.

## Compare with

- `GroupBy` - deferred, sequential, not indexable.
- `ToDictionary` - one value per key, throws on duplicates and on missing keys.
- `GroupJoin` - correlate two sequences by key without an intermediate lookup.

## Query syntax

None.

## Exercises

Open `ToLookupExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ToLookupExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_StudentsByCity` | a lookup of students keyed by City. |
| 2 | Easy | `Easy_02_UnknownKeyIsEmptyNotAnError` | build the same lookup; indexing with a city nobody lives in yields an empty sequence. |
| 3 | Easy | `Easy_03_EnrollmentsByStudent` | enrollments keyed by StudentId. |
| 4 | Medium | `Medium_04_ElementSelector` | course Titles keyed by Category (use the elementSelector overload). |
| 5 | Medium | `Medium_05_ContainsKey` | build the city lookup and test key membership with Contains. |
| 6 | Hard | `Hard_06_ToLookupIsASnapshot` | build a lookup of `list` by parity, then add an element to `list`. The lookup must NOT see it (ToLookup executes immediately, unlike GroupBy). |
| 7 | Hard | `Hard_07_LookupAvoidsRepeatedScans` | build a lookup of enrollments by CourseId ONCE, then use it to get the enrollment count of every course (including 0 for QC999). Without the lookup you would rescan Data.Enrollments for every course. |
<!-- exercises:end -->
