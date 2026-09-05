# Query syntax

| | |
|---|---|
| Module | 16 - Combinations |
| Exercises | 12 |

C# has two ways to write LINQ. **Method syntax** is what the rest of this repo uses. **Query syntax**
(`from ... where ... select`) is sugar that the compiler rewrites into the same method calls - there is
no runtime difference. It is worth knowing because it reads well for joins, `let`, and multiple `from`
clauses, and because you will meet it in other people's code.

| Query syntax | Compiles to |
|--------------|-------------|
| `from x in xs where p select x` | `xs.Where(p)` |
| `from x in xs select f(x)` | `xs.Select(f)` |
| `orderby a, b descending` | `OrderBy(a).ThenByDescending(b)` |
| `let y = f(x)` | `Select(x => new { x, y = f(x) })` and unpacking afterwards |
| `group x by k` | `GroupBy(k)` |
| `group x by k into g` | `GroupBy(k)` followed by a continuation over `g` |
| `join y in ys on a equals b` | `Join(ys, x => a, y => b, ...)` |
| `join y in ys on a equals b into g` | `GroupJoin(...)` |
| `join ... into g` + `from y in g.DefaultIfEmpty()` | left outer join |
| `from x in xs from y in f(x)` | `SelectMany(x => f(x), (x, y) => ...)` |
| `select v into w ...` | continuation: the rest of the query operates on `w` |

Rules: a query must start with `from` and end with `select` or `group`; `Count()`, `Sum()`, `First()`
and friends have no keyword - wrap the query in parentheses and call the method.

The tests cannot detect which syntax you used. Solve this file in query syntax anyway; that is the point.

```bash
dotnet test --filter "FullyQualifiedName~QuerySyntaxExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Query syntax | `Query_01_FromWhereSelect` | the even numbers, with from / where / select. |
| 2 | Query syntax | `Query_02_OrderByDescending` | numbers descending, with `orderby n descending`. |
| 3 | Query syntax | `Query_03_OrderByMultipleKeys` | students by City then LastName - `orderby s.City, s.LastName` (a comma list = ThenBy). |
| 4 | Query syntax | `Query_04_LetIntroducesAVariable` | (word, length) pairs for words longer than 5 characters, computing the length once with `let`. |
| 5 | Query syntax | `Query_05_GroupBy` | students grouped by City - `group s by s.City`. |
| 6 | Query syntax | `Query_06_GroupIntoWithProjection` | (City, count) - `group s by s.City into g select (g.Key, g.Count())`. |
| 7 | Query syntax | `Query_07_Join` | the FirstName for each enrollment - `join s in Data.Students on e.StudentId equals s.Id`. |
| 8 | Query syntax | `Query_08_JoinInto` | (Code, enrollment count) per course - `join ... into es` is a GroupJoin. |
| 9 | Query syntax | `Query_09_LeftJoin` | the classic query-syntax left join: `join ... into es from e in es.DefaultIfEmpty() select (c.Code, (int?)e?.Id)`. |
| 10 | Query syntax | `Query_10_MultipleFromIsSelectMany` | (CohortName, StudentFirstName) for every inactive student - `from c in ... from s in c.Students where ...`. |
| 11 | Query syntax | `Query_11_SelectIntoContinuation` | ages over 60 - project to Age, then continue with `into age where age > 60 select age`. |
| 12 | Query syntax | `Query_12_MixQuerySyntaxWithMethodCalls` | the sum of the even numbers - wrap a query expression in parentheses and call .Sum() on it. |
<!-- exercises:end -->
