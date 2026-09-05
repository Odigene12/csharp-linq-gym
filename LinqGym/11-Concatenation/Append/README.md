# Append

| | |
|---|---|
| Category | 11 - Concatenation |
| Available since | .NET Core 1.0 / .NET Framework 4.7.1 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Append on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.append) |

## What it does

`Append(element)` returns a new sequence: the source followed by one extra element. The source is not
modified - unlike `List<T>.Add`.

## Signature

```csharp
IEnumerable<T> Append<T>(this IEnumerable<T> source, T element);
```

## How it behaves

- **Deferred**: the source is enumerated when the result is, so elements added to the source list later appear *before* the appended element.
- Chain `Append` calls freely; the runtime keeps them in one lightweight node.
- Typical uses: a sentinel or total row at the end, adding a value without allocating an array for `Concat`.

## Watch out for

- It is not `Add`. `list.Append(x);` on its own does nothing observable.
- Element type must match the sequence type.

## Compare with

- `Prepend` - at the start.
- `Concat(new[] { x })` - the old way.
- `List<T>.Add` - mutation.

## Query syntax

None.

## Exercises

Open `AppendExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~AppendExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_AppendEleven` | Data.Numbers with 11 added at the end. |
| 2 | Easy | `Easy_02_AppendToEmpty` | Data.Empty with 1 appended. |
| 3 | Easy | `Easy_03_AppendDoesNotMutateTheSource` | append 99 to Data.Numbers; the original list still has 10 elements. |
| 4 | Medium | `Medium_04_AppendAStudent` | Data.Students with Data.Student(1) appended again (21 elements, Anne last). |
| 5 | Medium | `Medium_05_ChainTwoAppends` | Data.Numbers followed by 0 and then -1. |
| 6 | Hard | `Hard_06_AppendIsDeferred` | build list.Append(4); the 5 added to the list afterwards appears BEFORE the appended 4. |
| 7 | Hard | `Hard_07_TotalRow` | Data.Prices followed by their sum as a final "total" element. |
<!-- exercises:end -->
