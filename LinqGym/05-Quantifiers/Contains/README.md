# Contains

| | |
|---|---|
| Category | 05 - Quantifiers |
| Available since | .NET Framework 3.5 |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.Contains on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.contains) |

## What it does

`Contains(value)` answers "is this value in the sequence?" using the default equality comparer, or one
you supply. Inside a `Where`, `ids.Contains(x.Id)` is the LINQ spelling of SQL's `IN (...)`.

## Signatures

```csharp
bool Contains<T>(this IEnumerable<T> source, T value);
bool Contains<T>(this IEnumerable<T> source, T value, IEqualityComparer<T>? comparer);
```

## How it behaves

- **Immediate**, stops at the first match.
- If the source is an `ICollection<T>` (List, HashSet, array...) the no-comparer overload delegates to the collection's own `Contains` - `HashSet` gives O(1).
- Equality rules: primitives, strings, tuples and records compare by **value**; classes compare by **reference** unless they override `Equals`/`GetHashCode` or you pass a comparer.
- `StringComparer.OrdinalIgnoreCase` makes text membership case-insensitive.

## Watch out for

- A "copy" of an entity with identical data is *not* contained (reference equality). Compare by Id or pass a comparer such as `PersonIdComparer`.
- `list.Contains(x)` inside a `Where` over a big list is O(n*m); turn the list into a `HashSet` first.
- `string.Contains` (substring) and `Enumerable.Contains` (element) are different methods that happen to share a name.

## Compare with

- `Any(x => x == value)` - what `Contains` does, minus the comparer conveniences.
- `IntersectBy` / `ExceptBy` - membership for whole sequences at once.

## Query syntax

None - typically appears inside a `where` clause: `where ids.Contains(s.Id)`.

## Exercises

Open `ContainsExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ContainsExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ContainsNine` | does Data.Numbers contain 9? |
| 2 | Easy | `Easy_02_DoesNotContainFour` | does Data.Numbers contain 4? |
| 3 | Easy | `Easy_03_ContainsApple` | does Data.Words contain "apple"? |
| 4 | Medium | `Medium_04_ContainsIsCaseSensitiveByDefault` | "APPLE" is in the list exactly, "Apple" is not. |
| 5 | Medium | `Medium_05_ContainsWithACaseInsensitiveComparer` | does Data.Words contain "CHERRY" when case is ignored? Pass StringComparer.OrdinalIgnoreCase. |
| 6 | Medium | `Medium_06_ReferenceEqualityForClasses` | Data.Student(3) is the same object that lives in Data.Students, so Contains finds it. `copy` has identical data but is a different object, so Contains does NOT find it. |
| 7 | Medium | `Medium_07_CohortsWithAGivenJuniorInstructor` | cohorts whose JuniorInstructors contain Kate Williams (Data.Instructor(1)). |
| 8 | Hard | `Hard_08_ContainsAsAnInFilter` | the students whose Id is in `ids` (the LINQ equivalent of SQL's WHERE Id IN (...)). |
| 9 | Hard | `Hard_09_ContainsAsANotInFilter` | students whose City is NOT one of the given cities. |
| 10 | Hard | `Hard_10_ContainsWithACustomComparer` | `copy` is a different object with the same Id as student 3. Make Contains find it by passing PersonIdComparer.Instance (see Support/Comparers.cs). |
<!-- exercises:end -->
