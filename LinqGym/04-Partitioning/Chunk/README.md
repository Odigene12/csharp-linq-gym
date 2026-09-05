# Chunk

| | |
|---|---|
| Category | 04 - Partitioning |
| Available since | .NET 6 |
| Exercises | 7 (3 easy, 2 medium, 2 hard) |
| Docs | [Enumerable.Chunk on Microsoft Learn](https://learn.microsoft.com/dotnet/api/system.linq.enumerable.chunk) |

## What it does

`Chunk(size)` splits a sequence into consecutive arrays of at most `size` elements. The last chunk holds
whatever is left over. It is the standard way to batch work: "send 100 rows per request", "render 4 cards per row".

## Signature

```csharp
IEnumerable<T[]> Chunk<T>(this IEnumerable<T> source, int size);
```

## How it behaves

- **Deferred**, but each chunk is a fully materialized array by the time it is yielded.
- A size larger than the sequence produces one chunk containing everything; an empty source produces no chunks.
- `size < 1` throws `ArgumentOutOfRangeException` **immediately** (argument validation is eager, unlike the enumeration).
- Chunks are `T[]`, so `chunk.Length`, `chunk.Sum()`, `chunk[0]` all work.

## Watch out for

- Every chunk allocates an array; for huge streams consider processing elements directly.
- Chunk does not overlap or slide; for sliding windows zip the sequence with `Skip`.

## Compare with

- `Skip`/`Take` - one window at a time.
- `GroupBy` - groups by key, not by position.

## Query syntax

None.

## Exercises

Open `ChunkExercises.cs`, replace each `TODO` and run:

```bash
dotnet test --filter "FullyQualifiedName~ChunkExercises"
```

<!-- exercises:start -->
| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Easy | `Easy_01_ChunksOfThree` | Data.Numbers in chunks of 3. |
| 2 | Easy | `Easy_02_TwoChunksOfFive` | Data.Words in chunks of 5. |
| 3 | Easy | `Easy_03_ChunkLargerThanSequence` | a chunk size bigger than the sequence gives a single chunk with everything. |
| 4 | Medium | `Medium_04_ChunkSizeMustBePositive` | Chunk(0) throws ArgumentOutOfRangeException immediately (argument checks are eager, not deferred). |
| 5 | Medium | `Medium_05_SumOfEachChunk` | the sum of each chunk of 3. |
| 6 | Hard | `Hard_06_StudentsInGroupsOfFour` | students in groups of 4; the third group must contain students 9-12. |
| 7 | Hard | `Hard_07_ChunkSizes` | the size of each chunk when Data.Numbers is split into chunks of 4. |
<!-- exercises:end -->
