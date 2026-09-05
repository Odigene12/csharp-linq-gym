# AsEnumerable

| | |
|---|---|
| Category | 13 - Conversion |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.AsEnumerable on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.asenumerable) |

## What it does

`AsEnumerable` returns its argument unchanged, typed as `IEnumerable<T>`. It does nothing at runtime;
its whole job is to change which methods the **compiler** binds to next.

## Signature

```csharp
IEnumerable<T> AsEnumerable<T>(this IEnumerable<T> source);
```

## How it behaves

- `ReferenceEquals(list, list.AsEnumerable())` is `true`. No copy, no enumeration.
- **Use case 1 - hide a collection's own method:** `List<T>.Reverse()` is void; `list.AsEnumerable().Reverse()` is LINQ's.
- **Use case 2 - leave IQueryable:** `dbQuery.Where(translatable).AsEnumerable().Select(clientSideCode)` - everything after `AsEnumerable` runs in memory instead of being sent to the query provider.
- **Use case 3 - stop the compiler picking a more specific overload** (e.g. a type's own `Where`).

## Watch out for

- It is not `ToList`: nothing is materialized and deferred execution continues.
- On an `IQueryable`, placing `AsEnumerable` too early pulls the whole table to the client.

## Compare with

- `AsQueryable` - the opposite direction.
- `ToList` / `ToArray` - actually materialize.
- `Cast<T>` - changes element type.

## Query syntax

None.

## Exercises

Open `AsEnumerableExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~AsEnumerableExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ItIsTheSameObject` | AsEnumerable on Data.Numbers; the result is reference-equal to Data.Numbers. |
| 2 | Easy | `Easy_02_PickLinqReverseOverListReverse` | List<T>.Reverse() is void and mutates. Use AsEnumerable so that .Reverse() resolves to LINQ's. |
| 3 | Easy | `Easy_03_RuntimeTypeIsUnchanged` | the compile-time type becomes IEnumerable<int>, but the runtime object is still a List<int>. |
| 4 | Medium | `Medium_04_LinqStillWorksAfterwards` | count the active students after AsEnumerable. |
| 5 | Medium | `Medium_05_StringsAreSequencesOfChars` | the number of distinct characters in "hello" (AsEnumerable makes the char sequence explicit). |
| 6 | Hard | `Hard_06_SwitchFromQueryableToEnumerable` | start from Data.Students.AsQueryable(), filter Active with Queryable.Where, then call AsEnumerable and project to FullName. Everything after AsEnumerable runs as ordinary in-memory LINQ, not as an IQueryable. |
| 7 | Hard | `Hard_07_HideACollectionsOwnMethod` | HashSet<T> has its own Contains; after AsEnumerable, Contains resolves to Enumerable.Contains. Return whether the set of numbers contains 7, going through AsEnumerable. |
<!-- exercises:end -->
