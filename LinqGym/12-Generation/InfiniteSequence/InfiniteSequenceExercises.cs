namespace LinqGym.Generation;

/// <summary>
/// Enumerable.InfiniteSequence(start, step) (.NET 10+) - an endless arithmetic progression.
/// ALWAYS pair it with something that stops: Take, TakeWhile, First(predicate), Zip with a finite sequence...
/// Never call Count(), ToList() or foreach without a break on it.
/// </summary>
public class InfiniteSequenceExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_FirstFiveNaturals()
    {
        // Task: 1, 2, 3, 4, 5 from an infinite sequence starting at 1 with step 1.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, result);
    }

    [Fact]
    public void Easy_02_FirstFourEvens()
    {
        // Task: 0, 2, 4, 6.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 0, 2, 4, 6 }, result);
    }

    [Fact]
    public void Easy_03_CountingDownForever()
    {
        // Task: 10, 9, 8 (negative step, then Take 3).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 10, 9, 8 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_StopWithTakeWhile()
    {
        // Task: the naturals whose square is below 50 (1..7).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7 }, result);
    }

    [Fact]
    public void Medium_05_SkipIntoAnInfiniteSequence()
    {
        // Task: the 101st natural number (Skip 100, then First).
        int result = TODO;

        Assert.Equal(101, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_NumberWordsWithZip()
    {
        // Task: "1. apple", "2. Banana", ... - Zip the infinite counter with Data.Words (Zip stops at the shorter one).
        IEnumerable<string> result = TODO;

        Assert.Equal(10, result.Count());
        Assert.Equal("10. grape", result.Last());
    }

    [Fact]
    public void Hard_07_FirstSquareAboveOneThousand()
    {
        // Task: the first natural number whose square exceeds 1000 (First with a predicate stops the infinite sequence).
        int result = TODO;

        Assert.Equal(32, result);
    }
}
