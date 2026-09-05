# Where

| | |
|---|---|
| Category | 01 - Filtering |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Where on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.where) |

## What it does

`Where` keeps the elements for which a predicate returns `true` and drops the rest. It never changes
the element type, never reorders anything, and never throws because of "no matches" - it simply yields
nothing. It is the LINQ equivalent of SQL's `WHERE` clause and the single most used LINQ operator.

## Signatures

```csharp
IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate);
IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, int, bool> predicate); // predicate also receives the index
```

## How it behaves

- **Deferred.** Nothing runs until you enumerate the result (foreach, ToList, Count, ...). Every enumeration re-runs the predicate over the source.
- **Streaming.** Elements are tested one at a time as they are requested; `Where(...).First()` stops at the first match.
- **Order-preserving.** Survivors come out in the order they went in.
- **Index overload.** The two-argument predicate `(element, index)` lets you filter by position.
- Chained `Where` calls are equivalent to one `Where` with `&&` - the runtime even merges them.

## Watch out for

- Comparing strings with `==` is case-sensitive and ordinal. Use `string.Equals(a, b, StringComparison.OrdinalIgnoreCase)` when case must not matter.
- A predicate that touches a nullable member (`s.Email.Length`) can throw; test for null first (`s.Email is { Length: > 0 }`).
- Prefer `Count(pred)`, `Any(pred)`, `First(pred)` over `Where(pred).Count()` etc. They mean the same and read better.
- Capturing a loop variable or a field in the predicate captures the *variable*, not its value at the time the query was built (see 16-Combinations/DeferredExecution).

## Compare with

- `OfType<T>` - filters by runtime type instead of by predicate.
- `TakeWhile` / `SkipWhile` - stop testing after the first failure / success; `Where` tests every element.
- `Distinct` / `Except` - remove elements by *value*, not by predicate.

## Query syntax

```csharp
var actives = from s in Data.Students
              where s.Active && s.City == "Nashville"
              select s;
```

## Exercises

Open `WhereExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~WhereExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ActiveStudents` | all students whose Active flag is true, in their original order. |
| 2 | Easy | `Easy_02_EvenNumbers` | only the even values from Data.Numbers, keeping their order. |
| 3 | Easy | `Easy_03_StudentsFromNashville` | students whose City is exactly "Nashville". |
| 4 | Medium | `Medium_04_ActiveStudentsFromMemphis` | students who are Active AND live in Memphis. Use a single Where with && (not two Where calls). |
| 5 | Medium | `Medium_05_BornInThe1980s` | students born from 1980-01-01 up to and including 1989-12-31. |
| 6 | Medium | `Medium_06_StudentsWithoutEmail` | students whose Email is null. Nulls are ordinary values to Where - no special handling needed. |
| 7 | Medium | `Medium_07_WordsStartingWithLowercaseVowel` | words that start with a lowercase vowel (a, e, i, o, u). Case matters: "APPLE" must NOT be included. |
| 8 | Hard | `Hard_08_EveryOtherNumberUsingIndex` | Where has an overload whose predicate receives the element AND its zero-based index. Return the elements at even positions (index 0, 2, 4, ...). |
| 9 | Hard | `Hard_09_CohortsWhereAllInstructorsAreActive` | cohorts where the PrimaryInstructor is active AND every JuniorInstructor is active. Hint: a Where predicate can itself contain a LINQ call (All). |
| 10 | Hard | `Hard_10_WhereIsDeferred` | build a query over `numbers` that keeps values greater than 2. Do NOT call ToList/ToArray. A Where query is not executed when it is created; it runs when it is enumerated. The Assert below adds an element AFTER the query is built and expects the query to see it. |
<!-- exercises:end -->
