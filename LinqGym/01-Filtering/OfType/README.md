# OfType

| | |
|---|---|
| Category | 01 - Filtering |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.OfType on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.oftype) |

## What it does

`OfType<TResult>` walks a sequence and yields only the elements that *are* a `TResult` (the same test as
the `is` operator), typed as `TResult`. Elements of other types - and `null` - are silently skipped.
It is defined on the non-generic `IEnumerable`, so it also works on legacy collections such as `ArrayList`.

## Signature

```csharp
IEnumerable<TResult> OfType<TResult>(this IEnumerable source);
```

## How it behaves

- **Deferred and streaming**, like `Where`.
- Works with classes, interfaces, structs and enums. `OfType<IComparable>()` keeps ints and strings alike.
- Boxed value types must match exactly: a boxed `int` is not a `long`, so `OfType<long>()` skips it.
- `OfType<object>()` is a handy "drop the nulls" filter for `object?[]`.

## Watch out for

- `OfType` filters; `Cast` asserts. If you expect every element to be a `T`, `Cast<T>()` fails loudly instead of quietly dropping data.
- On an `IEnumerable<T>` where every element already is a `T`, `OfType<T>()` is just a slow no-op.

## Compare with

- `Cast<T>` - same shape, but throws `InvalidCastException` on the first element that is not a `T`.
- `Where(x => x is T).Select(x => (T)x)` - what `OfType` does for you.

## Query syntax

No dedicated keyword. Filter first, then query: `from p in people.OfType<Instructor>() select p.FullName`.

## Exercises

Open `OfTypeExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~OfTypeExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_OnlyIntegers` | the int values inside Data.MixedBag, in order. |
| 2 | Easy | `Easy_02_OnlyStrings` | the string values inside Data.MixedBag. |
| 3 | Easy | `Easy_03_NullsAreDropped` | OfType<object>() keeps everything that is an object - which is everything except null. |
| 4 | Medium | `Medium_04_TypeMustMatchExactlyForValueTypes` | the long values. Note that the ints 1, 3, 5 are NOT longs - boxed value types do not convert. |
| 5 | Medium | `Medium_05_InterfacesWork` | every element that implements IComparable (int, string, double, long and bool all do). |
| 6 | Hard | `Hard_06_FilterAHeterogeneousListOfPeople` | `people` mixes Students and Instructors (both derive from Person). Return just the Instructors. |
| 7 | Hard | `Hard_07_SumOnlyTheNumericValues` | from Data.MixedBag, add up every int AND every long as a single long total (1 + 3 + 4 + 5 = 13). Hint: two OfType calls, Concat (or Select to long), then Sum. |
<!-- exercises:end -->
