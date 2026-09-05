# SelectMany

| | |
|---|---|
| Category | 02 - Projection |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.SelectMany on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.selectmany) |

## What it does

`SelectMany` maps each element to a *sequence* and concatenates all those sequences into one flat
result. Think "flatten": cohorts -> all students, matrix rows -> all cells, sentences -> all words.
It is the `flatMap` / `bind` of other languages and the engine behind multiple `from` clauses in query syntax.

## Signatures

```csharp
IEnumerable<TResult> SelectMany<T, TResult>(this IEnumerable<T> source, Func<T, IEnumerable<TResult>> selector);
IEnumerable<TResult> SelectMany<T, TResult>(this IEnumerable<T> source, Func<T, int, IEnumerable<TResult>> selector);
IEnumerable<TResult> SelectMany<T, TCollection, TResult>(this IEnumerable<T> source,
    Func<T, IEnumerable<TCollection>> collectionSelector,
    Func<T, TCollection, TResult> resultSelector); // keep the parent alongside each child
```

## How it behaves

- **Deferred and streaming.** Inner sequences are enumerated lazily, one after another.
- **Order:** all children of element 1, then all children of element 2, and so on.
- **No de-duplication** - the same object reached through two parents appears twice.
- The result-selector overload gives you `(parent, child)` pairs, which is how query syntax implements `from c in cohorts from s in c.Students select (c, s)`.
- A string is an `IEnumerable<char>`, so `words.SelectMany(w => w)` yields every character.

## Watch out for

- `Select(x => x.Items)` returns `IEnumerable<List<T>>`; if you then need `.Count()` of everything, you wanted `SelectMany`.
- Cartesian products are easy to write (`a.SelectMany(_ => b)`) and easy to make enormous.
- `SelectMany` after `GroupBy` "ungroups" - a common way to regroup elements.

## Compare with

- `Select` - one in, one out.
- `Concat` - flattens exactly two sequences.
- `Zip` - pairs elements positionally rather than combining every child.

## Query syntax

```csharp
var pairs = from c in Data.Cohorts
            from s in c.Students
            where !s.Active
            select (c.Name, s.FirstName);
```

## Exercises

Open `SelectManyExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~SelectManyExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_FlattenTheMatrix` | all values of Data.Matrix as one flat sequence. |
| 2 | Easy | `Easy_02_AllStudentsFromAllCohorts` | every student of every cohort, in cohort order. |
| 3 | Easy | `Easy_03_AllJuniorInstructorsWithDuplicates` | every junior instructor of every cohort. SelectMany does NOT remove duplicates. |
| 4 | Medium | `Medium_04_FlattenStringsIntoCharacters` | every character of every word (a string is an IEnumerable<char>). |
| 5 | Medium | `Medium_05_ResultSelectorPairsParentWithChild` | use the SelectMany overload with a result selector to produce (CohortName, StudentFirstName) pairs. |
| 6 | Medium | `Medium_06_PrimaryPlusJuniorsPerCohort` | for every cohort, its PrimaryInstructor followed by its JuniorInstructors, all flattened. Hint: Prepend or Concat inside the collection selector. |
| 7 | Medium | `Medium_07_SelectManyWithIndex` | multiply every value in a row by that row's index (row 0 -> x0, row 1 -> x1, row 2 -> x2), flattened. |
| 8 | Hard | `Hard_08_CartesianProduct` | every combination of a number and a letter as "1a", "1b", "2a", "2b" (numbers outer, letters inner). |
| 9 | Hard | `Hard_09_SplitSentencesIntoWords` | all words from all sentences (split on a single space). |
| 10 | Hard | `Hard_10_FlattenThenFilter` | (CohortName, StudentFirstName) for every INACTIVE student, walking through Data.Cohorts. |
<!-- exercises:end -->
