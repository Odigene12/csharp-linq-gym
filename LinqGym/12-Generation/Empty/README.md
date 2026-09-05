# Empty

| | |
|---|---|
| Category | 12 - Generation |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Empty on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.empty) |

## What it does

`Enumerable.Empty<T>()` returns an empty sequence. It is cached - every call for the same `T` returns
the same instance - so it costs nothing and is the idiomatic "no results" value.

## Signature

```csharp
static IEnumerable<T> Empty<T>();
```

## How it behaves

- Immediate, allocation-free, and `ReferenceEquals(Empty<int>(), Empty<int>())` is `true`.
- Returning it instead of `null` lets callers enumerate without null checks: `return maybeNull ?? Enumerable.Empty<T>();`.
- Works as a starting point for `Concat`, as the "else" branch of a conditional query, and with `DefaultIfEmpty` to produce a single fallback.

## Watch out for

- The instance is a shared empty array; do not cast it to `T[]` and try to write to it.
- `Array.Empty<T>()` is the equivalent when you need a `T[]`; `[]` (collection expression) works for either.

## Compare with

- `new T[0]` / `new List<T>()` - allocate.
- `DefaultIfEmpty` - turns empty into one element.

## Query syntax

None.

## Exercises

Open `EmptyExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~EmptyExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_EmptyInts` | an empty sequence of int. |
| 2 | Easy | `Easy_02_NullCoalesceToEmpty` | `maybe` might be null; produce a safe sequence with ?? and Enumerable.Empty. |
| 3 | Easy | `Easy_03_SumOfEmptyIsZero` | Sum over Enumerable.Empty<int>(). |
| 4 | Medium | `Medium_04_EmptyIsASingleton` | two calls to Enumerable.Empty<int>() return the very same object (use ReferenceEquals). |
| 5 | Medium | `Medium_05_EmptyAsAStartingPoint` | start from Empty and Concat [1, 2] onto it. |
| 6 | Hard | `Hard_06_EmptyWithDefaultIfEmpty` | Enumerable.Empty<int>() with DefaultIfEmpty(42) yields exactly [42]. |
| 7 | Hard | `Hard_07_ConditionalQuery` | when includeArchived is false, return Enumerable.Empty<Student>(); otherwise the inactive students. |
<!-- exercises:end -->
