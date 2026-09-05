# Deferred execution

| | |
|---|---|
| Module | 16 - Combinations |
| Exercises | 8 |

A LINQ query is a **recipe**, not a result. Building `numbers.Where(n => n > 2)` executes nothing; the
predicate runs when something *enumerates* the query - and runs again every time something enumerates
it. This one idea explains most LINQ surprises:

| You observe | Because |
|-------------|---------|
| The query "sees" elements added after it was built | It reads the source when enumerated, not when defined |
| An expensive `Select` runs twice | The query was enumerated twice (`Count()` then `ToList()`, or two `foreach`) |
| Changing a captured variable changes the results | Lambdas capture variables, not values |
| `InvalidOperationException: Collection was modified` | You mutated the source list while a deferred query over it was mid-enumeration |
| `Cast<int>()` did not throw, `ToList()` did | Exceptions are raised when elements are produced |
| `OrderBy(...).First()` touched every element | Sorting must see the whole input before yielding anything |

## Deferred vs immediate

**Deferred (return a sequence):** `Where`, `Select`, `SelectMany`, `OrderBy*`, `ThenBy*`, `GroupBy`, `Join`,
`GroupJoin`, `Distinct*`, `Union*`, `Intersect*`, `Except*`, `Skip*`, `Take*`, `Chunk`, `Zip`, `Concat`,
`Append`, `Prepend`, `Reverse`, `Cast`, `OfType`, `DefaultIfEmpty`, `Index`, `Shuffle`, `Range`, `Repeat`,
`Sequence`, `InfiniteSequence`.

**Immediate (return a value or a collection):** `ToList`, `ToArray`, `ToDictionary`, `ToHashSet`,
`ToLookup`, `Count`, `LongCount`, `Sum`, `Average`, `Min`, `Max`, `MinBy`, `MaxBy`, `Aggregate`, `Any`,
`All`, `Contains`, `First*`, `Last*`, `Single*`, `ElementAt*`, `SequenceEqual`.

Some deferred operators are **streaming** (yield as they go: `Where`, `Select`, `Take`) and some are
**buffering** (must read everything first: `OrderBy`, `GroupBy`, `Reverse`, `TakeLast`, `Shuffle`).

## When to materialize

Call `ToList()`/`ToArray()` when you will enumerate more than once, when the source may change, when you
need indexing, or when you want errors to surface *now*. Do not call it inside a pipeline "just in case".

```bash
dotnet test --filter "FullyQualifiedName~DeferredExecutionExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Concept | `Deferred_01_QueriesRunEveryTimeTheyAreEnumerated` | a Select that counts its calls. Enumerating the query twice runs the selector 20 times. |
| 2 | Concept | `Deferred_02_MaterializeToRunOnce` | the same counting Select, but materialized once with ToList. Using the list twice costs nothing extra. |
| 3 | Concept | `Deferred_03_LambdasCaptureVariablesNotValues` | filter Data.Numbers to values greater than `threshold`. The test changes `threshold` AFTER building the query; because the lambda captured the VARIABLE, the query uses the new value when it finally runs. |
| 4 | Concept | `Deferred_04_ModifyingTheSourceWhileEnumeratingThrows` | a query over `list` (values > 0). Adding to `list` inside the foreach invalidates the enumerator. |
| 5 | Concept | `Deferred_05_ImmediateOperatorsRunRightAway` | Count() over a counting Select. By the time the next line runs, all 10 selectors have executed. |
| 6 | Concept | `Deferred_06_ExceptionsAreDeferredToo` | Cast<int> over Data.MixedBag. Building the query does not throw; ToList() does, because it must enumerate. (Beware: Count() would NOT throw here - over an array, Cast can answer Count from the array length without looking at elements.) |
| 7 | Concept | `Deferred_07_PipelinesAreLazyEndToEnd` | Where(n > 3) -> counting Select -> Take(2). Because every stage is lazy, the selector runs only twice even though Where inspects three elements (5, 3, 8) to find two matches. |
| 8 | Concept | `Deferred_08_SortingMustBufferEverything` | counting Select -> OrderBy -> First(). Even though only one element is requested, sorting needs to see all ten, so the selector runs ten times. (MinBy would have done the same job in one pass without sorting.) |
<!-- exercises:end -->
