# C# LINQ Gym

**668 test-driven exercises covering every LINQ method in .NET 10 - 7 to 10 per method, easy to hard,
each with its own study guide - plus a final module on combining methods.**

Fork it, open a test file, replace `TODO` with a LINQ expression, run the tests, repeat. When every test is
green you will have used every operator in `System.Linq.Enumerable`, seen how each one behaves on empty
input, nulls, duplicates and ties, and learned why queries are shaped the way they are.

This is the successor to [csharp_LINQ_Exercise](https://github.com/Odigene12/csharp_LINQ_Exercise), rebuilt
for .NET 10, xUnit and the full method list.

## Quick start

Requirements: the [.NET 10 SDK](https://dotnet.microsoft.com/download). Any editor works (VS 2022 17.12+,
VS Code + C# Dev Kit, Rider).

```bash
git clone https://github.com/Odigene12/csharp-linq-gym.git
cd csharp-linq-gym
dotnet test --filter "FullyQualifiedName~WhereExercises"
```

Every test fails with `NotImplementedException` until you replace its `TODO`. Open
`LinqGym/01-Filtering/Where/WhereExercises.cs`, read the `// Task:` comment, write your expression:

```csharp
[Fact]
public void Easy_02_EvenNumbers()
{
    // Task: only the even values from Data.Numbers, keeping their order.
    IEnumerable<int> result = TODO;                      // <- replace TODO

    Assert.Equal(new[] { 8, 2, 8, 10 }, result);
}
```

becomes

```csharp
    IEnumerable<int> result = Data.Numbers.Where(n => n % 2 == 0);
```

Run the filter again; the test passes. Move to the next one.

## How the repo is organised

```
LinqGym/
  01-Filtering/        Where, OfType
  02-Projection/       Select, SelectMany, Zip
  03-Sorting/          OrderBy, OrderByDescending, ThenBy, ThenByDescending, Order, OrderDescending, Reverse
  04-Partitioning/     Take, Skip, TakeWhile, SkipWhile, TakeLast, SkipLast, Chunk
  05-Quantifiers/      Any, All, Contains
  06-ElementOperators/ First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, ElementAt, ElementAtOrDefault, DefaultIfEmpty
  07-Aggregation/      Count, LongCount, Sum, Average, Min, Max, MinBy, MaxBy, Aggregate, CountBy, AggregateBy
  08-Grouping/         GroupBy, ToLookup
  09-Joining/          Join, GroupJoin, LeftJoin, RightJoin
  10-SetOperations/    Distinct, DistinctBy, Union, UnionBy, Intersect, IntersectBy, Except, ExceptBy
  11-Concatenation/    Concat, Append, Prepend
  12-Generation/       Range, Repeat, Empty, Sequence, InfiniteSequence
  13-Conversion/       ToList, ToArray, ToDictionary, ToHashSet, Cast, AsEnumerable, AsQueryable
  14-Equality/         SequenceEqual
  15-Utilities/        Index, TryGetNonEnumeratedCount, Shuffle
  16-Combinations/     CommonPairs, DeferredExecution, QuerySyntax, Capstone
  Data/                the shared dataset (students, instructors, cohorts, courses, enrollments, numbers, words...)
  Support/             the TODO placeholder, comparers, assertion helpers
docs/                  GUIDE (LINQ concepts), DATASET (reference tables), LEARNING-PATH (suggested order)
tools/                 reset scripts and the generators used by maintainers
```

Every method folder contains:

- **`README.md`** - what the method does, its signatures, how it behaves (deferred? streaming? what happens on
  empty input?), what to watch out for, which methods to compare it with, the query-syntax form, a link to
  Microsoft Learn, and a table of the exercises.
- **`<Method>Exercises.cs`** - the exercises. `Easy_01..03` teach the basic call, `Medium_04..` add overloads,
  comparers and combinations, `Hard_..` cover edge cases, laziness and real-world shapes. Heavily used methods
  (Where, Select, OrderBy, GroupBy, Join, First, Count, Sum, ToDictionary, ...) have 10 exercises; the rest have 7.

Each category folder has a short README that maps the methods in it, and `docs/LEARNING-PATH.md` proposes an
order that builds skills progressively.

## Working through it

- Run one method: `dotnet test --filter "FullyQualifiedName~GroupByExercises"`.
- Run one category: `dotnet test --filter "FullyQualifiedName~LinqGym.Sorting"`.
- Run everything: `dotnet test` (expect a long red list until you are done).
- In Visual Studio / Rider, Test Explorer groups by namespace and sorts `Easy_` before `Hard_`.

The dataset is small enough to reason about by hand - 20 students, 6 instructors, 4 cohorts, 8 courses, 32
enrollments, ten numbers, ten words. `docs/DATASET.md` prints it all. A fresh copy is created for every test,
so you cannot corrupt it.

`TODO` is a placeholder property that throws `NotImplementedException`; it is typed `dynamic` only so the file
compiles whatever the expected type. The declared type on the left of each `TODO` (`IEnumerable<Student>`,
`int?`, `ILookup<string, Student>`) tells you what your expression must produce.

## Solutions

The `solutions` branch holds a reference answer for every exercise; CI proves that all 668 pass. To peek at
one method without spoiling the rest:

```bash
git diff main origin/solutions -- LinqGym/08-Grouping/GroupBy
```

A fresh clone has no local `solutions` branch, which is why that command says `origin/solutions`. Run
`git switch solutions` if you would rather read the whole branch. The `//!` you will see at the end of each
answer is the marker the generator uses to strip solutions out of `main`; ignore it.

Try for ten minutes first. The reference answers are one good way, not the only way.

## Doing it again

Repetition is the point. Reset one method or everything:

```bash
tools/reset-exercises.sh              # all 82 exercise files
tools/reset-exercises.sh Aggregate    # just the Aggregate exercises
tools/reset-exercises.sh 07-Agg       # everything under 07-Aggregation
```

On Windows: `powershell -File tools/Reset-Exercises.ps1 -Only Aggregate`. Both scripts touch only
`*Exercises.cs`, so notes you write into a README survive a reset. Or keep each attempt on its own branch -
`git switch -c attempt-2 main` - and diff attempts against each other later.

## What you will be able to do afterwards

- Read any LINQ chain and say what type flows out of each step and when it executes.
- Pick the right operator without a search: `Any` vs `Count`, `First` vs `Single`, `Min` vs `MinBy`,
  `Distinct` vs `DistinctBy`, `Join` vs `GroupJoin` vs `LeftJoin`, `GroupBy` vs `ToLookup`, `Concat` vs `Union`.
- Predict behaviour on empty sequences, nulls, duplicates, ties and reference-typed elements.
- Write grouping, joining and paging queries in both method and query syntax.
- Use the .NET 6-10 additions (`*By` methods, `Chunk`, `Index`, `CountBy`, `AggregateBy`, `Order`, `LeftJoin`,
  `RightJoin`, `Sequence`, `Shuffle`) where they simplify code.

## Coverage

All 74 public methods of `System.Linq.Enumerable` in .NET 10 have exercises, plus `Queryable.AsQueryable`.
`FullJoin` is coming in .NET 11 and will be added when it ships. See the method index in each category
README, or run `dotnet test --list-tests` for the full 668.

## References

- [Enumerable class - Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable) - the authoritative list and per-method docs.
- [LINQ overview - Microsoft Learn](https://learn.microsoft.com/dotnet/csharp/linq/) - concepts and query syntax.
- [Standard query operators - Microsoft Learn](https://learn.microsoft.com/dotnet/csharp/linq/standard-query-operators/) - the operators grouped by purpose.
- [LINQ Methods in C# - C# Corner](https://www.c-sharpcorner.com/article/linq-methods) - a compact walkthrough with method and query syntax side by side.
- [What's new in .NET 9](https://learn.microsoft.com/dotnet/core/whats-new/dotnet-9/libraries#linq) and [.NET 10](https://learn.microsoft.com/dotnet/core/whats-new/dotnet-10/libraries) - `CountBy`, `AggregateBy`, `Index`, `LeftJoin`, `RightJoin`, `Sequence`, `InfiniteSequence`, `Shuffle`.

## Contributing

Corrections, clearer wording and new exercises are welcome - see `CONTRIBUTING.md` for the branch model
(exercises are authored on `solutions`; `main` is generated from it).

## License

MIT.
