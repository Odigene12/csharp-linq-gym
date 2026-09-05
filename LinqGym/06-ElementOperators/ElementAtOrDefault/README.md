# ElementAtOrDefault

| | |
|---|---|
| Category | 06 - Element operators |
| Available since | .NET Framework 3.5 (Index overload: .NET 6) |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.ElementAtOrDefault on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.elementatordefault) |

## What it does

`ElementAt` that returns `default(T)` for any out-of-range position - negative, too large, or an
index-from-end that reaches past the start.

## Signatures

```csharp
T? ElementAtOrDefault<T>(this IEnumerable<T> source, int index);
T? ElementAtOrDefault<T>(this IEnumerable<T> source, Index index);
```

## How it behaves

- **Immediate**; same indexing shortcuts as `ElementAt`.
- Pairs naturally with `?.`: `students.ElementAtOrDefault(99)?.FirstName`.

## Watch out for

- No `defaultValue` overload exists (unlike `FirstOrDefault`); use `?? fallback` afterwards.
- Value-type ambiguity: a `0` might be real.

## Compare with

- `ElementAt` - throws when out of range.
- `Skip(i).FirstOrDefault()` - equivalent, less direct.

## Query syntax

None.

## Exercises

Open `ElementAtOrDefaultExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ElementAtOrDefaultExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_OutOfRangeGivesZero` | index 20 on a 10-element list. |
| 2 | Easy | `Easy_02_OutOfRangeGivesNull` | student at index 50. |
| 3 | Easy | `Easy_03_InRangeWorksNormally` | the element at index 0. |
| 4 | Medium | `Medium_04_NegativeIndexGivesDefault` | a negative index does not throw - it yields default. |
| 5 | Medium | `Medium_05_IndexFromEndOutOfRange` | ^20 on a 10-element list is out of range - default again. |
| 6 | Hard | `Hard_06_SafeLookupThenNullConditional` | the FirstName of the student at index 99, or null. |
| 7 | Hard | `Hard_07_SeventhWord` | the word at index 6. |
<!-- exercises:end -->
