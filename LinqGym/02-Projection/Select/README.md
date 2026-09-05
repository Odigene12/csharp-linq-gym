# Select

| | |
|---|---|
| Category | 02 - Projection |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Select on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.select) |

## What it does

`Select` transforms every element into something else: one element in, one element out. The output
type can be anything - a property, a computed value, a tuple, a record, an anonymous object. This is
the `map` of other languages and the `SELECT` list of SQL.

## Signatures

```csharp
IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector);
IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, int, TResult> selector); // with index
```

## How it behaves

- **Deferred and streaming.** The selector runs once per element, each time the query is enumerated - so an expensive selector enumerated twice runs twice.
- **Same length.** Never adds or removes elements; the count is preserved (`TryGetNonEnumeratedCount` still works after a `Select` over a list).
- **Index overload.** `(element, index)` lets you number or weight elements by position.
- A method group is a valid selector: `strings.Select(int.Parse)`.

## Watch out for

- Selecting a *collection* per element gives you a sequence of sequences. If you wanted one flat list, you wanted `SelectMany`.
- Anonymous types cannot leave the method they were created in. Use tuples or records for results you need to return.
- Projecting to a class and then comparing results with `Distinct`/`Contains` uses reference equality; records and tuples compare by value.
- `Select` inside a hot loop with side effects is a code smell; use `foreach` for side effects.

## Compare with

- `SelectMany` - projects each element to a *sequence* and flattens.
- `Zip` - combines elements of two sequences positionally.
- `Cast<T>` - changes the compile-time type without transforming values.

## Query syntax

```csharp
var names = from s in Data.Students
            select new StudentSummary(s.FullName, s.City, s.Age);
```

## Exercises

Open `SelectExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~SelectExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_FirstNames` | the FirstName of every student, in order. |
| 2 | Easy | `Easy_02_Squares` | the square of every number in Data.Numbers. |
| 3 | Easy | `Easy_03_WordLengths` | the length of every word. Select can change the element type (string -> int). |
| 4 | Medium | `Medium_04_FullNamesWithInterpolation` | "FirstName LastName" for each instructor (build the string yourself, do not use FullName). |
| 5 | Medium | `Medium_05_ProjectToTuple` | project each student to a named tuple (Name, Age) using FullName and Age. |
| 6 | Medium | `Medium_06_ProjectToRecord` | project each student to a StudentSummary(FullName, City, Age). Records compare by value, so the assertion can compare against a freshly constructed instance. |
| 7 | Medium | `Medium_07_SelectWithIndex` | Select has an overload whose selector receives (element, index). Multiply each number by its index. |
| 8 | Hard | `Hard_08_NestedAggregateInsideSelect` | for each cohort, a tuple of (Name, number of ACTIVE students in that cohort). |
| 9 | Hard | `Hard_09_SelectIsLazyAndRunsPerElement` | project Data.Numbers to n * 2, incrementing `calls` inside the selector each time it runs. Nothing should run until the query is enumerated, and Take(2) should only run the selector twice. |
| 10 | Hard | `Hard_10_MethodGroupAsSelector` | parse each string to an int. Pass the method group int.Parse directly instead of writing a lambda. |
<!-- exercises:end -->
