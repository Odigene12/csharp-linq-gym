# Prepend

| | |
|---|---|
| Category | 11 - Concatenation |
| Available since | .NET Core 1.0 / .NET Framework 4.7.1 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Prepend on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.prepend) |

## What it does

`Prepend(element)` returns a new sequence with one extra element at the **start**. Source untouched.

## Signature

```csharp
IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T element);
```

## How it behaves

- **Deferred**; the prepended element is yielded first, then the (live) source.
- Handy for headers, "primary first, then the rest" (`juniors.Prepend(primary)`), or seeding a sequence with a default.
- Mixes with `Append`: `xs.Prepend(0).Append(11)`.

## Watch out for

- Not `Insert(0, x)` - no mutation.

## Compare with

- `Append` - at the end.
- `new[] { x }.Concat(xs)` - the old way.

## Query syntax

None.

## Exercises

Open `PrependExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~PrependExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_PrependZero` | Data.Numbers with 0 in front. |
| 2 | Easy | `Easy_02_PrependToEmpty` | Data.Empty with 1 prepended. |
| 3 | Easy | `Easy_03_PrependDoesNotMutateTheSource` | prepend 99; Data.Numbers itself still starts with 5. |
| 4 | Medium | `Medium_04_HeaderRow` | Data.Words with a "FRUITS" header in front. |
| 5 | Medium | `Medium_05_PrependAndAppend` | 0 in front of Data.Numbers and 11 at the end. |
| 6 | Hard | `Hard_06_PrependIsDeferred` | build list.Prepend(0); an element added to the list later still shows up (at the end). |
| 7 | Hard | `Hard_07_PrimaryInstructorFirst` | cohort 3's instructors with the PrimaryInstructor first, then the juniors (Ids). |
<!-- exercises:end -->
