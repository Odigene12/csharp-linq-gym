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

## Your workflow

If the repo is not yours, fork it so you have somewhere to push, then clone your fork. If you own it, or
you just cloned it directly, no fork is needed.

Either way, **work on a branch, never on `main` itself**:

```bash
git switch -c practice/attempt-1 main
```

`main` has to stay entirely unsolved. It is regenerated from `solutions`, so answers committed to `main` are
published to everyone who clones the repo and are then destroyed by the next sync. CI rejects any push to
`main` that contains a solved exercise, so a slip is caught rather than shipped.

A branch per attempt also lets you start over cleanly and diff attempts against each other later. If you
want to practise and maintain at the same time without switching branches, give the practice branch its own
directory:

```bash
git worktree add ../linq-practice -b practice/attempt-2 main
```

**Per method.** Work one folder at a time.

1. Pick the next method. `docs/LEARNING-PATH.md` sequences all 75 so each one builds on the last; plain
   numeric folder order works too.
2. **Read that folder's `README.md` before writing anything.** It explains the behaviour the tests then
   check: deferred or immediate, what happens on an empty sequence, which operator to reach for instead.
3. Open `<Method>Exercises.cs` and work top to bottom. `Easy_` teaches the basic call, `Medium_` adds
   overloads and comparers, `Hard_` covers edge cases, laziness and real-world shapes.
4. Run just that file, and keep going until it is green:
   ```bash
   dotnet test --filter "FullyQualifiedName~GroupByExercises"
   ```
5. Commit. That makes your answers diffable against a later attempt.

**Per exercise.**

- Read the `// Task:` comment, then read the assertions. The assertions are the specification - where the
  wording and the assertion disagree, the assertion wins.
- Look at the declared type to the left of `TODO` (`IEnumerable<Student>`, `int?`,
  `ILookup<string, Student>`). That is what your expression has to produce, and it is the strongest hint in
  the file. `TODO` itself is a placeholder that throws `NotImplementedException`, typed `dynamic` only so any
  expected type compiles; your answer should never contain `dynamic`.
- Replace `TODO` and run. On a failure, read xUnit's expected-versus-actual before changing anything. The
  difference usually names the misconception.
- Once it passes, check the README's "Compare with" list. If a shorter or single-pass operator exists,
  rewrite it that way. Recognising `MinBy` where you first wrote `OrderBy(...).First()` is the actual skill.

The dataset is small enough to reason about by hand - 20 students, 6 instructors, 4 cohorts, 8 courses, 32
enrollments, ten numbers, ten words. `docs/DATASET.md` prints all of it. A fresh copy is built for every
test, so you cannot corrupt it for the next one.

Stuck for more than ten minutes, see [Solutions](#solutions). Want to run a method again later, see
[Doing it again](#doing-it-again).

**Changing the repo rather than working through it?** Exercises are authored on the `solutions` branch and
`main` is generated from it, so an edit to an exercise on `main` is overwritten by the next sync.
`CONTRIBUTING.md` has the flow; `CLAUDE.md` states the same rules for coding agents.

## Running tests

- Run one method: `dotnet test --filter "FullyQualifiedName~GroupByExercises"`.
- Run one category: `dotnet test --filter "FullyQualifiedName~LinqGym.Sorting"`.
- Run one exercise: `dotnet test --filter "FullyQualifiedName~GroupByExercises.Easy_01"`.
- Run everything: `dotnet test` (expect a long red list until you are done).
- In Visual Studio / Rider, Test Explorer groups by namespace and sorts `Easy_` before `Hard_`.

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
