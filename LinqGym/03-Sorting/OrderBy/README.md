# OrderBy

| | |
|---|---|
| Category | 03 - Sorting |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.OrderBy on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.orderby) |

## What it does

`OrderBy` sorts a sequence ascending by a key you compute from each element. It returns an
`IOrderedEnumerable<T>`, which is what unlocks `ThenBy` / `ThenByDescending` for secondary keys.

## Signatures

```csharp
IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector);
IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey>? comparer);
```

## How it behaves

- **Stable.** Elements with equal keys keep their original relative order. This matters for ties and is what makes `OrderBy(...).ThenBy(...)` predictable.
- **Deferred, but buffering.** Nothing happens until enumeration; then the *whole* source is read and sorted before the first element comes out.
- Keys can be anything comparable: numbers, strings, `DateOnly`, `bool` (`false` sorts before `true`), tuples, enums.
- `null` keys sort first (they are the smallest value).
- A custom `IComparer<TKey>` (`StringComparer.OrdinalIgnoreCase`, `Comparer<T>.Create(...)`) changes what "less than" means.

## Watch out for

- **Two `OrderBy` calls in a row do not combine** - the second one re-sorts everything and wins. Use `ThenBy` for secondary keys.
- The default string comparer is culture-sensitive. For mixed-case data the result depends on the machine; be explicit with `StringComparer.Ordinal` or `OrdinalIgnoreCase`.
- Sorting to find one extreme (`OrderBy(x).First()`) does far more work than `MinBy(x)`.
- `List<T>.Sort()` sorts in place and returns `void`; `OrderBy` never touches the source.

## Compare with

- `OrderByDescending` - same, descending.
- `Order()` (.NET 7) - when the elements *are* the keys.
- `ThenBy` / `ThenByDescending` - secondary keys.
- `Reverse` - flips order without sorting; not the same as descending for ties.

## Query syntax

```csharp
var byAge = from s in Data.Students
            orderby s.Age
            select s;
```

## Exercises

Open `OrderByExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~OrderByExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_NumbersAscending` | Data.Numbers from smallest to largest. |
| 2 | Easy | `Easy_02_StudentsOldestFirst` | students ordered by Birthday (earliest birthday = oldest person first). |
| 3 | Easy | `Easy_03_WordsByLengthIsStable` | words ordered by Length. Words with the same length must stay in their original order. |
| 4 | Medium | `Medium_04_OrdinalStringOrdering` | words ordered with StringComparer.Ordinal (uppercase letters sort before lowercase). The default comparer is culture-sensitive and gives machine-dependent results for mixed case - avoid it. |
| 5 | Medium | `Medium_05_CaseInsensitiveOrdering` | words ordered with StringComparer.OrdinalIgnoreCase. Equal keys ("apple"/"APPLE") keep original order. |
| 6 | Medium | `Medium_06_OrderByComputedKey` | students ordered by Age (youngest first). Two students share age 36 - stability decides who comes first. |
| 7 | Medium | `Medium_07_OrderByBoolean` | cohorts ordered by FullTime. Booleans sort false before true, so part-time cohorts come first. |
| 8 | Hard | `Hard_08_OddsFirstThenEvensKeepingOrder` | all odd numbers first (in original order), then all even numbers (in original order). Hint: a single OrderBy with a boolean key does this - no Where/Concat needed. |
| 9 | Hard | `Hard_09_CustomPriorityOrder` | courses ordered by the position of their Category in `priority` (Backend first, General last). |
| 10 | Hard | `Hard_10_OrderByIsDeferred` | build (but do not execute) an ascending query over `list`. The element added afterwards must be sorted in. |
<!-- exercises:end -->
