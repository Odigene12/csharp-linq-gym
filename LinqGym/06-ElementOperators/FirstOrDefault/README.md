# FirstOrDefault

| | |
|---|---|
| Category | 06 - Element operators |
| Available since | .NET Framework 3.5 (default-value overloads: .NET 6) |
| Exercises | 10 (3 easy, 4 medium, 3 hard) |
| Docs | [Enumerable.FirstOrDefault on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.firstordefault) |

## What it does

Like `First`, but when nothing is found it returns `default(T)` - `null` for classes, `0` for ints,
`false` for bools - or, since .NET 6, a default value you pass in.

## Signatures

```csharp
T? FirstOrDefault<T>(this IEnumerable<T> source);
T? FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate);
T  FirstOrDefault<T>(this IEnumerable<T> source, T defaultValue);
T  FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue);
```

## How it behaves

- **Immediate**, short-circuiting.
- Combine with `?.` to reach into the result safely: `students.FirstOrDefault(p)?.FirstName`.
- The `defaultValue` overloads let you supply a sentinel (`-1`) or a fallback object.

## Watch out for

- For value types, `default` may be a *legitimate* value: `ints.FirstOrDefault(n => n < 1)` returns `0` both when it found a 0 and when it found nothing. Project to a nullable (`Cast<int?>()` / `Select(n => (int?)n)`) when you must tell the two apart.
- Enable nullable reference types: the return type is `T?` and the compiler will remind you to check.
- `FirstOrDefault` hides bugs when the element *should* exist; `First` fails fast.

## Compare with

- `First` - throws on miss.
- `SingleOrDefault` - also throws when there is more than one.
- `LastOrDefault` / `ElementAtOrDefault` - same idea, different position.
- `DefaultIfEmpty(x).First()` - the pre-.NET-6 way to get a custom default.

## Query syntax

None.

## Exercises

Open `FirstOrDefaultExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~FirstOrDefaultExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_NoMatchGivesZeroForInts` | the first number greater than 100 - there is none, so the result is default(int) = 0. |
| 2 | Easy | `Easy_02_NoMatchGivesNullForClasses` | the first student named "Zelda" - none exists, so the result is null. |
| 3 | Easy | `Easy_03_EmptySequenceGivesDefault` | FirstOrDefault() on Data.Empty. |
| 4 | Medium | `Medium_04_ExplicitDefaultValue` | use the .NET 6 overload that takes a fallback: return -1 when no number is greater than 100. |
| 5 | Medium | `Medium_05_MatchIsReturnedNormally` | the first student from Knoxville. |
| 6 | Medium | `Medium_06_ZeroIsAmbiguousForValueTypes` | `nums` really contains 0, so FirstOrDefault cannot tell "found 0" from "found nothing". Make the "nothing" case return null by turning the elements into int? first (Cast<int?> or Select). |
| 7 | Medium | `Medium_07_NullConditionalAfterFirstOrDefault` | the FirstName of the first student in "Paris", or null if there is none. Use ?. after FirstOrDefault. |
| 8 | Hard | `Hard_08_StudentWithNoEnrollments` | the first enrollment of student 12 - there is none. |
| 9 | Hard | `Hard_09_HighestGradedEnrollment` | the enrollment with the highest Grade (order descending, then FirstOrDefault). |
| 10 | Hard | `Hard_10_FallbackObject` | the first student from "Paris", falling back to Data.Student(1) using the default-value overload. |
<!-- exercises:end -->
