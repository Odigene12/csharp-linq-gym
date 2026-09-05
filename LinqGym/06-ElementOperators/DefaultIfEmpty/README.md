# DefaultIfEmpty

| | |
|---|---|
| Category | 06 - Element operators |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.DefaultIfEmpty on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.defaultifempty) |

## What it does

`DefaultIfEmpty()` passes a non-empty sequence through untouched; for an *empty* sequence it yields a
single `default(T)` (or the value you supply). It guarantees "at least one element", which is what
makes left outer joins and safe aggregates possible.

## Signatures

```csharp
IEnumerable<T?> DefaultIfEmpty<T>(this IEnumerable<T> source);
IEnumerable<T>  DefaultIfEmpty<T>(this IEnumerable<T> source, T defaultValue);
```

## How it behaves

- **Deferred.** The decision is made when enumeration starts.
- **Left outer join recipe:** `outer.GroupJoin(inner, ...).SelectMany(x => x.Inners.DefaultIfEmpty(), (x, i) => ...)` - the `null` inner for unmatched outers is exactly this method's doing. In query syntax: `join ... into g from i in g.DefaultIfEmpty()`.
- **Safe aggregates:** `xs.DefaultIfEmpty().Max()` returns `0` instead of throwing on empty; `DefaultIfEmpty(fallback).First()` is a pre-.NET-6 `FirstOrDefault(fallback)`.

## Watch out for

- The default element is `null` for classes - your result selector must handle it (`e?.Id`).
- It changes the element type to `T?` under nullable reference types.
- On .NET 10, `LeftJoin`/`RightJoin` express outer joins directly; `DefaultIfEmpty` remains the portable way.

## Compare with

- `FirstOrDefault(defaultValue)` - for single values.
- `LeftJoin` (.NET 10) - the join case without the recipe.
- `Enumerable.Empty<T>()` - the opposite intent: an explicitly empty sequence.

## Query syntax

```csharp
var rows = from c in Data.Courses
           join e in Data.Enrollments on c.Id equals e.CourseId into es
           from e in es.DefaultIfEmpty()
           select (c.Code, e?.Id);
```

## Exercises

Open `DefaultIfEmptyExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~DefaultIfEmptyExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_EmptyBecomesSingleDefault` | Data.Empty with DefaultIfEmpty() yields exactly one element: 0. |
| 2 | Easy | `Easy_02_NonEmptyIsUnchanged` | Data.Numbers with DefaultIfEmpty() is just Data.Numbers. |
| 3 | Easy | `Easy_03_CustomDefault` | Data.Empty with a default of -1. |
| 4 | Medium | `Medium_04_EmptyQueryOverClassesYieldsOneNull` | students from "Paris" (none) with DefaultIfEmpty - one element, and it is null. |
| 5 | Medium | `Medium_05_SafeMaxOfAPossiblyEmptySequence` | Max() on an empty sequence throws. Use DefaultIfEmpty so the max of Data.Empty is 0 instead. |
| 6 | Hard | `Hard_06_LeftOuterJoinWithGroupJoinAndDefaultIfEmpty` | one row per (Course, Enrollment) pair, but courses with NO enrollments must still appear once with a null enrollment id. The classic recipe: GroupJoin -> SelectMany(group.DefaultIfEmpty()). |
| 7 | Hard | `Hard_07_AverageOfAPossiblyEmptyGroup` | the average grade of course 7 (which has no enrollments) as 0.0 rather than an exception. Treat null grades as 0 and use DefaultIfEmpty before Average. |
<!-- exercises:end -->
