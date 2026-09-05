# SequenceEqual

| | |
|---|---|
| Category | 14 - Equality |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.SequenceEqual on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.sequenceequal) |

## What it does

`SequenceEqual` returns `true` when two sequences have the same length and pairwise-equal elements in
the same order. `==` on two lists compares references; `SequenceEqual` compares contents.

## Signatures

```csharp
bool SequenceEqual<T>(this IEnumerable<T> first, IEnumerable<T> second);
bool SequenceEqual<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T>? comparer);
```

## How it behaves

- **Immediate**, stops at the first difference. If both are `ICollection<T>` with different counts it answers `false` without enumerating.
- Element equality: value for primitives/strings/tuples/records, reference for classes unless you pass a comparer.
- `xs.SequenceEqual(xs.Order())` = "is it sorted?".

## Watch out for

- Order matters. For "same items in any order" sort both first, or compare `ToHashSet`s / use a multiset comparison (see `LinqAssert.SameItems`).
- Nested collections compare by reference: `new[] { new[] { 1 } }.SequenceEqual(new[] { new[] { 1 } })` is `false`.

## Compare with

- `Enumerable.Equals` / `==` - reference identity.
- `HashSet<T>.SetEquals` - order-insensitive, duplicate-insensitive.
- `Zip` + `All` - what `SequenceEqual` does, minus the length check.

## Query syntax

None.

## Exercises

Open `SequenceEqualExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~SequenceEqualExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_SameElementsSameOrder` | are [1, 2, 3] and [1, 2, 3] sequence-equal? |
| 2 | Easy | `Easy_02_OrderMatters` | [1, 2, 3] versus [3, 2, 1]. |
| 3 | Easy | `Easy_03_DifferentInstancesSameContent` | Data.Numbers compared with a fresh copy (ToList) of itself. |
| 4 | Medium | `Medium_04_DifferentLengths` | [1, 2] versus [1, 2, 3]. |
| 5 | Medium | `Medium_05_WithAComparer` | ["a", "B"] versus ["A", "b"] ignoring case. |
| 6 | Hard | `Hard_06_ValueTypesVersusReferenceTypes` | two lists of equal-valued RECORDS are sequence-equal; two lists of equal-valued CLASS instances are not. |
| 7 | Hard | `Hard_07_IsItSorted` | "is Data.Numbers already sorted?" = does it SequenceEqual its own sorted version? (No.) |
<!-- exercises:end -->
