# AsQueryable

| | |
|---|---|
| Category | 13 - Conversion |
| Available since | .NET Framework 3.5 (System.Linq.Queryable) |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Queryable.AsQueryable on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.queryable.asqueryable) |

## What it does

`AsQueryable` wraps an in-memory sequence as an `IQueryable<T>`. From then on the LINQ operators you
call come from `System.Linq.Queryable`, take **expression trees** (`Expression<Func<...>>`) instead of
delegates, and build a description of the query that a *provider* executes. Entity Framework, for
example, translates that description to SQL. Over a plain collection the provider is `EnumerableQuery<T>`,
which compiles the expression tree and runs it in memory - so `AsQueryable` is how you unit-test code
written against `IQueryable` without a database.

## Signature

```csharp
IQueryable<T> AsQueryable<T>(this IEnumerable<T> source);   // in System.Linq.Queryable
```

## How it behaves

- `IQueryable<T>` exposes `Expression`, `ElementType` and `Provider`. Each operator returns a new `IQueryable` whose `Expression` wraps the previous one.
- Enumerating (foreach, `ToList`, `Count`) makes the provider execute the expression.
- Lambdas passed to `Queryable` operators become `Expression<Func<...>>` at compile time - the same source text, a different type.

## Watch out for

- Not every C# construct can be turned into an expression tree (statement bodies, `out` parameters, some pattern matching). Providers add their own limits on what they can translate.
- If `source` already is an `IQueryable<T>`, `AsQueryable` returns it unchanged.
- Calling `AsEnumerable()` (or `ToList()`) switches back to in-memory LINQ.

## Compare with

- `AsEnumerable` - the way back.
- `Expression<Func<T, bool>>` vs `Func<T, bool>` - data describing code vs code.

## Query syntax

Identical - query syntax compiles to `Queryable` methods when the source is an `IQueryable`.

## Exercises

Open `AsQueryableExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~AsQueryableExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ItIsAnIQueryable` | Data.Numbers as an IQueryable<int>. |
| 2 | Easy | `Easy_02_OperatorsBuildAnExpressionTree` | a queryable Where(n > 5); its Expression is a method-call node describing the Where, not a result. |
| 3 | Easy | `Easy_03_EnumeratingExecutesIt` | the same Where(n > 5) query, materialized. |
| 4 | Medium | `Medium_04_ElementType` | ElementType of a queryable over students. |
| 5 | Medium | `Medium_05_TheInMemoryProvider` | the Provider of an in-memory queryable is an EnumerableQuery<T>. |
| 6 | Hard | `Hard_06_ExpressionLambdaVersusFuncLambda` | `filter` is an Expression<Func<...>> (data describing code), not a Func. Pass it to Queryable.Where. |
| 7 | Hard | `Hard_07_ComposeAQueryStepByStep` | starting from `query`, add: Where Active, OrderBy Age, Select FirstName - then take the first. Each operator returns a new IQueryable whose Expression wraps the previous one. |
<!-- exercises:end -->
