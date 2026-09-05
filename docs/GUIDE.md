# LINQ in one page

Read this before the first exercise; come back to it whenever a test surprises you.

## What LINQ is

**Language Integrated Query**: a set of ~75 extension methods on `IEnumerable<T>` (in `System.Linq.Enumerable`)
plus optional query-expression syntax in C#. Each method takes a sequence and returns either a new
sequence (deferred) or a single value (immediate). You chain them:

```csharp
var names = Data.Students          // IEnumerable<Student>
    .Where(s => s.Active)          // IEnumerable<Student>   - still nothing has run
    .OrderBy(s => s.Age)           // IOrderedEnumerable<Student>
    .Select(s => s.FullName)       // IEnumerable<string>
    .Take(3)                       // IEnumerable<string>
    .ToList();                     // List<string>           - NOW it runs
```

## Lambdas

`s => s.Active` is a function with one parameter `s` returning `s.Active`. Multi-statement lambdas use
braces and `return`: `n => { calls++; return n * 2; }`. Two-parameter lambdas `(n, i) => ...` appear in
the index overloads and in `Aggregate`. A method group (`int.Parse`) can stand in for a lambda.

## Deferred execution

A query is a description. It executes when enumerated and re-executes every time. Consequences:

- Changes to the source *after* building the query are visible when it runs.
- Enumerating twice does the work twice; `ToList()` once if you need the results more than once.
- Lambdas capture variables, so changing a captured variable changes later results.
- Exceptions surface at enumeration, not at construction.
- Mutating the source *during* enumeration throws.

Immediate operators: anything returning a scalar or a collection (`Count`, `First`, `Sum`, `ToList`,
`ToDictionary`, ...). See 16-Combinations/DeferredExecution.

## Streaming vs buffering

Deferred operators either stream (`Where`, `Select`, `Take`, `Skip`, `Concat`, `Zip` ...) - they yield
each element as it arrives - or buffer (`OrderBy*`, `GroupBy`, `Reverse`, `TakeLast`, `SkipLast`,
`Shuffle`, `Join`'s inner side) - they must read the whole input first. `Take(2)` after a streaming
operator touches two elements; after `OrderBy` it touches all of them.

## Equality

`Distinct`, `Contains`, `Union`, `Intersect`, `Except`, `GroupBy`, `Join`, `ToDictionary`, `SequenceEqual`
all rely on `EqualityComparer<T>.Default`:

| Type | Equality |
|------|----------|
| numbers, bool, char, DateOnly, enums | value |
| string | value, case-sensitive, ordinal |
| tuples, records | value (all members) |
| classes | **reference** unless `Equals`/`GetHashCode` are overridden |

Pass an `IEqualityComparer<T>` (`StringComparer.OrdinalIgnoreCase`, `PersonIdComparer.Instance`) or use
the `*By` methods with a key to change that.

## Ordering

Sorts are stable. `OrderBy(a).ThenBy(b)`, never `OrderBy(a).OrderBy(b)`. String ordering is
culture-sensitive by default - pass `StringComparer.Ordinal` for predictable results. `null` sorts
first ascending, last descending.

## Empty sequences

| Operator | On empty |
|----------|----------|
| `Where`, `Select`, `OrderBy`, ... | empty |
| `Count`, `Sum` | 0 |
| `Any` | false |
| `All` | **true** |
| `First`, `Last`, `Single`, `Min`, `Max`, `Average`, `Aggregate` (no seed) | **throws** `InvalidOperationException` |
| `*OrDefault`, `MinBy`/`MaxBy` on classes | default / null |
| `Min`/`Max`/`Average` on nullable types | null |
| `ElementAt` | throws `ArgumentOutOfRangeException` |
| `DefaultIfEmpty` | one default element |

## Method syntax vs query syntax

Both compile to the same calls. Query syntax reads well for joins, `let` and nested `from`; method
syntax has every operator. Mix freely: `(from n in xs where n > 2 select n).Sum()`.

## IEnumerable vs IQueryable

`IEnumerable<T>` operators take delegates and run in memory. `IQueryable<T>` operators take expression
trees that a provider (EF Core) translates - to SQL, for example. Same method names, same query
syntax, different execution. `AsQueryable()` and `AsEnumerable()` cross the boundary.

## Reading a LINQ chain

Read left to right, ask two questions at each step: *what is the element type now?* and *has anything
executed yet?* Every exercise in this repo declares the result type explicitly for exactly this reason.

## Performance rules of thumb

1. `Any()` not `Count() > 0`.
2. Filter before you sort; sort once.
3. `MinBy`/`MaxBy` instead of sort + first.
4. Build a `HashSet`/`Dictionary`/`Lookup` once instead of `Contains`/`First` inside a loop.
5. Materialize a query you will enumerate twice; do not materialize one you enumerate once.
6. Prefer the specialised operator (`Sum`, `CountBy`) over `Aggregate` when it exists.
