# TryGetNonEnumeratedCount

| | |
|---|---|
| Category | 15 - Utilities |
| Available since | .NET 6 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.TryGetNonEnumeratedCount on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.trygetnonenumeratedcount) |

## What it does

`TryGetNonEnumeratedCount(out int count)` asks a sequence whether it can report its length **without
enumerating**. Collections say yes; so do LINQ iterators whose length is derivable (`Select`, `Skip`,
`Take`, `Range`, `Repeat`, `Reverse`, `Concat`, `Append` over collections). Filters (`Where`, `Distinct`,
`OfType`) say no. Library code uses it to pre-size buffers without accidentally running an expensive
query twice.

## Signature

```csharp
bool TryGetNonEnumeratedCount<T>(this IEnumerable<T> source, out int count);
```

## How it behaves

- Never enumerates. Returns `false` and `count = 0` when the answer is unknown.
- After `ToList()`/`ToArray()` the count is always known.

## Watch out for

- The set of iterators that answer `true` is an implementation detail and has grown over releases; do not depend on a specific `false`.
- It is an `out` parameter - declare the variable or use `out var`.

## Compare with

- `Count()` - always gives an answer, possibly by enumerating everything.
- `ICollection<T>.Count` - the property this method consults first.

## Query syntax

None.

## Exercises

Open `TryGetNonEnumeratedCountExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~TryGetNonEnumeratedCountExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ListKnowsItsCount` | call TryGetNonEnumeratedCount on Data.Numbers, capturing the count into `count`. |
| 2 | Easy | `Easy_02_WhereDoesNot` | a Where query cannot know its count without running. |
| 3 | Easy | `Easy_03_ArraysKnowTheirCount` | an array reports its length. |
| 4 | Medium | `Medium_04_SelectOverAListKeepsTheCount` | Select does not change the number of elements, so its count is known cheaply. |
| 5 | Medium | `Medium_05_RangeKnowsItsCount` | Enumerable.Range(1, 5). |
| 6 | Hard | `Hard_06_MaterializingMakesTheCountKnown` | the same Where query, but materialized with ToList first - now the count is known. |
| 7 | Hard | `Hard_07_SkipAndTakeStillKnow` | Skip(2) over a list - the runtime can compute 10 - 2 without enumerating. |
<!-- exercises:end -->
