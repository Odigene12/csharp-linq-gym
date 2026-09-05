# TakeLast

| | |
|---|---|
| Category | 04 - Partitioning |
| Available since | .NET Core 2.0 / .NET Standard 2.1 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.TakeLast on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.takelast) |

## What it does

`TakeLast(n)` yields the last `n` elements, in their original order.

## Signature

```csharp
IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int count);
```

## How it behaves

- **Deferred, buffering.** For a plain enumerable it keeps a rolling window of `n` elements until the source ends; for lists and arrays it jumps straight to the tail.
- More than the length -> everything; zero or negative -> empty. Never throws.
- Equivalent to `Take(^n..)` on .NET 6+.
- `OrderBy(k).TakeLast(n)` = the top n, smallest of them first; add `.Reverse()` for largest first.

## Watch out for

- The result keeps original order. If you want "newest first" reverse afterwards.
- Do not use it on infinite sequences - it never finishes.

## Compare with

- `Take` - from the front.
- `SkipLast` - the complement.
- `Last` - just the final element.

## Query syntax

None.

## Exercises

Open `TakeLastExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~TakeLastExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_LastThreeNumbers` | the last three numbers. |
| 2 | Easy | `Easy_02_LastTwoStudents` | the first names of the last two students. |
| 3 | Easy | `Easy_03_TakeLastMoreThanAvailable` | TakeLast(100) yields everything. |
| 4 | Medium | `Medium_04_TakeLastZero` | TakeLast(0) is empty. |
| 5 | Medium | `Medium_05_ThreeYoungestInAscendingAgeOrder` | sort students by Birthday (oldest first) and take the last three - the youngest, oldest-of-the-three first. |
| 6 | Hard | `Hard_06_LastTwoWordsAlphabetically` | the two words that come last in ordinal order. |
| 7 | Hard | `Hard_07_TwoMostRecentEnrollmentsNewestFirst` | order enrollments by EnrolledOn, take the last two, and reverse so the newest comes first. Three enrollments share the latest date; the stable sort decides which two are "last". |
<!-- exercises:end -->
