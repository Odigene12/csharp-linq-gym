# Learning path

There are 668 exercises. Nobody should do them in one sitting. Here is a schedule that builds skills in
the order they depend on each other; each block is roughly one focused hour.

| Block | Folders | Why now |
|-------|---------|---------|
| 1 | 01 Where, 02 Select | Filtering and projecting are 80% of real queries |
| 2 | 03 OrderBy, OrderByDescending, ThenBy, ThenByDescending | Sorting plus the ThenBy trap |
| 3 | 06 First, FirstOrDefault, Single, SingleOrDefault | Choosing the right "get one" operator |
| 4 | 07 Count, Sum, Average, Min, Max | Basic aggregates and their empty-sequence rules |
| 5 | 05 Any, All, Contains | Yes/no questions, short-circuiting, equality |
| 6 | 04 Take, Skip, TakeWhile, SkipWhile, TakeLast, SkipLast, Chunk | Paging and slicing |
| 7 | 02 SelectMany, 03 Order, OrderDescending, Reverse | Flattening; the List.Reverse trap |
| 8 | 16 DeferredExecution | Stop here until it clicks - everything after assumes it |
| 9 | 13 ToList, ToArray, ToDictionary, ToHashSet | Materializing on purpose |
| 10 | 08 GroupBy, ToLookup | Grouping, HAVING-style filtering |
| 11 | 07 MinBy, MaxBy, Aggregate, CountBy, AggregateBy, LongCount | Advanced aggregates |
| 12 | 10 Distinct, DistinctBy, Union, UnionBy, Intersect, IntersectBy, Except, ExceptBy | Set semantics and the *By family |
| 13 | 09 Join, GroupJoin, LeftJoin, RightJoin, 06 DefaultIfEmpty | Joins, inner vs outer |
| 14 | 11 Concat, Append, Prepend, 12 Range, Repeat, Empty, Sequence, InfiniteSequence, 02 Zip | Building sequences |
| 15 | 06 Last, LastOrDefault, ElementAt, ElementAtOrDefault, 14 SequenceEqual, 15 Index, TryGetNonEnumeratedCount, Shuffle | The long tail |
| 16 | 13 Cast, 01 OfType, 13 AsEnumerable, AsQueryable | Types, boundaries, expression trees |
| 17 | 16 CommonPairs, QuerySyntax | Fluency |
| 18 | 16 Capstone | Proof |

## How to work an exercise

1. Read the folder README top to bottom once.
2. Read the `// Task:` comment and the assertions. The assertions *are* the specification.
3. Replace `TODO`. Run only that class: `dotnet test --filter "FullyQualifiedName~WhereExercises"`.
4. When it passes, ask: is there a shorter or clearer operator for this? (The README's "Compare with" section hints.)
5. When it fails, read the failure message. xUnit shows expected vs actual; the difference usually names the misconception.
6. Stuck for more than ten minutes: `git diff main solutions -- LinqGym/01-Filtering/Where` shows the reference answer for that one folder. Read it, close it, write your own.

## Repeating

Skills fade. To go again:

```bash
tools/reset-exercises.sh            # everything
tools/reset-exercises.sh Aggregate  # one method
tools/reset-exercises.sh 07-Agg     # one category
```

or on Windows `powershell -File tools/Reset-Exercises.ps1 -Only Aggregate`. Only `*Exercises.cs` is
restored, so any notes you added to a README stay put. Better still, work on a branch per attempt
(`git switch -c attempt-2 main`) so you can diff attempts against each other.

## What "done" looks like

- You can explain deferred execution to someone else with an example.
- You reach for `Any`, `MinBy`, `Count(pred)`, `DistinctBy`, `ToLookup` without thinking.
- You know which operators throw on empty sequences and which do not.
- You can write a join, a group-with-aggregate, and a left join from memory in both syntaxes.
- The capstone exercises take you minutes, not hours.
