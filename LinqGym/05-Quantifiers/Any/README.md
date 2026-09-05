# Any

| | |
|---|---|
| Category | 05 - Quantifiers |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Any on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.any) |

## What it does

`Any()` answers "is there at least one element?"; `Any(predicate)` answers "is there at least one element
that matches?". It returns as soon as it knows - the SQL `EXISTS`.

## Signatures

```csharp
bool Any<T>(this IEnumerable<T> source);
bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate);
```

## How it behaves

- **Immediate** (returns a `bool`) and **short-circuiting**: enumeration stops at the first match.
- On an empty sequence: `false` (with or without predicate).
- On an `ICollection<T>`, `Any()` without a predicate just checks `Count > 0` - no enumeration at all.
- Nested `Any` inside `Where` expresses "parents that have at least one matching child": `cohorts.Where(c => c.Students.Any(s => !s.Active))`.

## Watch out for

- `Count() > 0` walks the entire sequence to answer a yes/no question; `Any()` stops at the first element. Analyzer CA1827 flags it.
- The reverse holds for a *collection*: `list.Count > 0` (the property) beats `list.Any()`, because it never allocates an enumerator. Analyzer CA1860 flags `Any()` there. So: `Any()` over a query, `.Count`/`.Length` over a collection you are already holding.
- `Any(pred)` is `Where(pred).Any()` - write the short form.
- `!Any(p)` is `All(!p)`; pick whichever reads naturally.

## Compare with

- `All` - every element must match; true for empty.
- `Contains` - a specific value instead of a predicate.
- `Count` / `LongCount` - when you need the number, not the fact.

## Query syntax

None - `(from s in xs where ... select s).Any()`.

## Exercises

Open `AnyExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~AnyExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_AnyNumberAboveNine` | is there any number greater than 9? |
| 2 | Easy | `Easy_02_AnyStudentInChattanooga` | does any student live in Chattanooga? |
| 3 | Easy | `Easy_03_AnyOnAnEmptySequence` | Any() with no predicate asks "is there at least one element?". Data.Empty has none. |
| 4 | Medium | `Medium_04_AnyInactiveInstructor` | is any instructor inactive? |
| 5 | Medium | `Medium_05_NoStudentNamedZelda` | is there a student whose FirstName is "Zelda"? |
| 6 | Medium | `Medium_06_AnyWithoutPredicate` | does Data.Numbers contain at least one element? |
| 7 | Medium | `Medium_07_CohortsWithAnyInactiveStudent` | the cohorts that have at least one inactive student (Any inside a Where). |
| 8 | Hard | `Hard_08_AnyInProgressEnrollment` | is any enrollment still in progress (Grade is null)? Prefer Any(...) over Count(...) > 0. |
| 9 | Hard | `Hard_09_AnyShortCircuits` | pass Data.Numbers through a counting Select, then ask Any(n => n == 8). The first 8 is at index 2, so exactly three elements should be evaluated. |
| 10 | Hard | `Hard_10_StudentsWithAnyGradeOfNinetyOrMore` | students who have at least one enrollment graded 90 or higher (correlate via Data.Enrollments). |
<!-- exercises:end -->
