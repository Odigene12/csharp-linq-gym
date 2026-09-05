# Cast

| | |
|---|---|
| Category | 13 - Conversion |
| Available since | .NET Framework 3.5 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Cast on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.cast) |

## What it does

`Cast<TResult>` treats every element of a (possibly non-generic) `IEnumerable` as a `TResult`. It is the
bridge from legacy collections (`ArrayList`, `DataRowCollection`, `MatchCollection`...) into LINQ.

## Signature

```csharp
IEnumerable<TResult> Cast<TResult>(this IEnumerable source);
```

## How it behaves

- **Deferred.** The cast of each element happens during enumeration, so an element of the wrong type throws `InvalidCastException` only when reached.
- If the source already is an `IEnumerable<TResult>`, `Cast` returns it unchanged.
- It performs a *reference/unboxing* cast, not a *conversion*: a boxed `long` cannot be cast to `int`. Use `Select(x => (int)x)` for numeric conversions.

## Watch out for

- `Cast` asserts, `OfType` filters. Pick deliberately.
- Because of deferral, `Count()` over an array-backed `Cast` may answer from the array length without ever casting - the exception appears later, at `ToList()`.
- Upcasting (`Student` -> `Person`) is usually unnecessary: `IEnumerable<T>` is covariant.

## Compare with

- `OfType` - skips non-matching elements.
- `Select` with a cast - conversions and custom logic.
- `AsEnumerable` - changes the static type without touching elements.

## Query syntax

Declaring a typed range variable inserts a `Cast`: `from int n in legacyList select n`.

## Exercises

Open `CastExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~CastExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_CastALegacyArrayList` | the non-generic ArrayList as an IEnumerable<int>. |
| 2 | Easy | `Easy_02_CastToObject` | Data.Numbers as IEnumerable<object> (each int gets boxed). |
| 3 | Easy | `Easy_03_CastObjectsToStrings` | an object[] that happens to hold strings, as IEnumerable<string>. |
| 4 | Medium | `Medium_04_MixedTypesThrowOnEnumeration` | Cast<int> over Data.MixedBag; building the query is fine, ToList throws at the first string. |
| 5 | Medium | `Medium_05_CastDoesNotConvertBetweenNumericTypes` | a boxed long is NOT an int, so Cast<int> throws; Select with an explicit (int) conversion works. |
| 6 | Hard | `Hard_06_UpcastingIsUsuallyUnnecessary` | Data.Students as IEnumerable<Person>. (IEnumerable<T> is covariant, so a plain assignment would also work - Cast just makes the intent explicit.) |
| 7 | Hard | `Hard_07_FromNonGenericIEnumerableToLinq` | `untyped` only exposes the non-generic IEnumerable, which has no Where. Cast first, then filter (> 8). |
<!-- exercises:end -->
