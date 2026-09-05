namespace LinqGym.Partitioning;

/// <summary>
/// Chunk (.NET 6+) - split a sequence into arrays of at most N elements. The last chunk may be smaller.
/// </summary>
public class ChunkExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ChunksOfThree()
    {
        // Task: Data.Numbers in chunks of 3.
        IEnumerable<int[]> result = Data.Numbers.Chunk(3); //!

        Assert.Equal(4, result.Count());
        Assert.Equal(new[] { 5, 3, 8 }, result.First());
        Assert.Equal(new[] { 10 }, result.Last());
    }

    [Fact]
    public void Easy_02_TwoChunksOfFive()
    {
        // Task: Data.Words in chunks of 5.
        IEnumerable<string[]> result = Data.Words.Chunk(5); //!

        Assert.Equal(2, result.Count());
        Assert.All(result, chunk => Assert.Equal(5, chunk.Length));
    }

    [Fact]
    public void Easy_03_ChunkLargerThanSequence()
    {
        // Task: a chunk size bigger than the sequence gives a single chunk with everything.
        IEnumerable<int[]> result = Data.Numbers.Chunk(20); //!

        Assert.Single(result);
        Assert.Equal(10, result.First().Length);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ChunkSizeMustBePositive()
    {
        // Task: Chunk(0) throws ArgumentOutOfRangeException immediately (argument checks are eager, not deferred).
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            IEnumerable<int[]> result = Data.Numbers.Chunk(0); //!
        });
    }

    [Fact]
    public void Medium_05_SumOfEachChunk()
    {
        // Task: the sum of each chunk of 3.
        IEnumerable<int> result = Data.Numbers.Chunk(3).Select(chunk => chunk.Sum()); //!

        Assert.Equal(new[] { 16, 12, 18, 10 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_StudentsInGroupsOfFour()
    {
        // Task: students in groups of 4; the third group must contain students 9-12.
        IEnumerable<Student[]> result = Data.Students.Chunk(4); //!

        Assert.Equal(5, result.Count());
        Assert.Equal(new[] { 9, 10, 11, 12 }, result.ElementAt(2).Select(s => s.Id));
    }

    [Fact]
    public void Hard_07_ChunkSizes()
    {
        // Task: the size of each chunk when Data.Numbers is split into chunks of 4.
        IEnumerable<int> result = Data.Numbers.Chunk(4).Select(chunk => chunk.Length); //!

        Assert.Equal(new[] { 4, 4, 2 }, result);
    }
}
