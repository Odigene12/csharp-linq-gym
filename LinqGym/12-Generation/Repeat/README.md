# Repeat

| | |
|---|---|
| Category | 12 - Generation |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Repeat on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.repeat) |

## What it does

`Enumerable.Repeat(element, count)` yields the same element `count` times.

## Signature

```csharp
static IEnumerable<T> Repeat<T>(T element, int count);
```

## How it behaves

- **Deferred**, knows its count, negative `count` throws immediately.
- **The same instance every time** for reference types - `Repeat(new List<int>(), 3)` gives three references to one list. Use `Range(0, 3).Select(_ => new List<int>())` for three lists.
- Pairs with `Select((x, i) => ...)` to number the copies, and with `string.Concat` to build padding.

## Watch out for

- The shared-instance behaviour above is the classic bug.

## Compare with

- `Range` - consecutive integers.
- `new string('-', 5)` - for a repeated character, the string constructor is simpler.

## Query syntax

None.

## Exercises

Open `RepeatExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~RepeatExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ThreeXs` | "x" three times. |
| 2 | Easy | `Easy_02_FiveZeros` | five zeros. |
| 3 | Easy | `Easy_03_ZeroTimesIsEmpty` | repeat anything zero times. |
| 4 | Medium | `Medium_04_NumberedRows` | "Row 1", "Row 2", "Row 3" - Repeat "Row" then Select with the index. |
| 5 | Medium | `Medium_05_ReferenceTypesShareOneInstance` | repeat a single new List<int> three times; every element is the very same list object. |
| 6 | Hard | `Hard_06_NegativeCountThrows` | a negative count throws ArgumentOutOfRangeException. |
| 7 | Hard | `Hard_07_BuildAStringOfDashes` | "-----" built from Repeat('-', 5) and string.Concat. |
<!-- exercises:end -->
