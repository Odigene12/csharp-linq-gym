# ToList

| | |
|---|---|
| Category | 13 - Conversion |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.ToList on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.tolist) |

## What it does

`ToList` runs the query right now and copies every result into a brand-new `List<T>`. It is how you
end deferred execution: take a snapshot, pay the cost once, get a mutable, indexable collection.

## Signature

```csharp
List<T> ToList<T>(this IEnumerable<T> source);
```

## How it behaves

- **Immediate.** Always a *new* list, even when the source already is a `List<T>` (a cheap defensive copy).
- The list does not track later changes to the source.
- Any exception hiding in the pipeline (`InvalidCastException`, a throwing selector) surfaces here.
- Never returns `null`; an empty query gives an empty list.

## Watch out for

- `ToList()` in the middle of a pipeline throws away laziness: `xs.ToList().Where(...)` materializes everything before filtering. Put it at the end - or leave it out when the consumer only enumerates once.
- Calling it repeatedly on the same query re-runs the query each time.
- A `List<T>` exposes `Count` (property) and in-place `Sort`/`Reverse` that are not LINQ - handy, but they mutate.

## Compare with

- `ToArray` - fixed-size array.
- `ToDictionary` / `ToHashSet` / `ToLookup` - keyed collections.
- `AsEnumerable` - no materialization; only changes the static type.

## Query syntax

None - `(from ... select ...).ToList()`.

## Exercises

Open `ToListExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ToListExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_EvenNumbersAsAList` | the even numbers as a List<int>. |
| 2 | Easy | `Easy_02_ActiveStudentNames` | the first names of active students as a list (then use the Count PROPERTY). |
| 3 | Easy | `Easy_03_EmptyQueryGivesAnEmptyListNotNull` | students from "Paris" as a list - empty, never null. |
| 4 | Medium | `Medium_04_ToListIsASnapshot` | materialize "greater than 1" from `source`. Elements added afterwards must NOT appear in the snapshot. |
| 5 | Medium | `Medium_05_ToListAlwaysCopies` | ToList on a list that already IS a List<int> still returns a NEW list with equal contents. |
| 6 | Medium | `Medium_06_ListsCanBeIndexedAndMutated` | the distinct words as a list; then the test adds "kiwi" to it. |
| 7 | Medium | `Medium_07_MaterializeOnceToAvoidReEnumeration` | an "expensive" projection is used twice below (Count and Sum). Materialize it with ToList so the selector runs exactly 10 times, not 20. |
| 8 | Hard | `Hard_08_ListOfLists` | Data.Matrix as a List<List<int>>. |
| 9 | Hard | `Hard_09_ListOfTuples` | (FirstName, Age) pairs for all students, as a list. |
| 10 | Hard | `Hard_10_ToListSurfacesErrorsImmediately` | Cast<int> over Data.MixedBag is fine to BUILD (deferred), but ToList runs it and hits the string "one". |
<!-- exercises:end -->
