namespace LinqGym.Utilities;

/// <summary>
/// Index (.NET 9+) - pair every element with its position as (int Index, T Item) tuples.
/// Handy in foreach: foreach (var (i, item) in list.Index()) { ... }
/// </summary>
public class IndexExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_IndexedWords()
    {
        // Task: Data.Words with their indexes.
        IEnumerable<(int Index, string Item)> result = TODO;

        Assert.Equal((0, "apple"), result.First());
        Assert.Equal(10, result.Count());
    }

    [Fact]
    public void Easy_02_PositionOfFig()
    {
        // Task: the index of "fig" (Index, then First with a predicate, then .Index).
        int result = TODO;

        Assert.Equal(7, result);
    }

    [Fact]
    public void Easy_03_AllPositionsOfEight()
    {
        // Task: every index at which the value 8 appears in Data.Numbers.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 2, 6 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_FormatWithIndex()
    {
        // Task: "0:apple", "1:Banana", ...
        IEnumerable<string> result = TODO;

        Assert.Equal("0:apple", result.First());
        Assert.Equal("9:grape", result.Last());
    }

    [Fact]
    public void Medium_05_WeightedSum()
    {
        // Task: the sum of (index * word length) over Data.Words.
        int result = TODO;

        Assert.Equal(245, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_PositionOfTheMaximum()
    {
        // Task: the index of the largest number (Index + MaxBy).
        int result = TODO;

        Assert.Equal(9, result);
    }

    [Fact]
    public void Hard_07_ValuesEqualToTheirOneBasedPosition()
    {
        // Task: the numbers whose value equals their 1-based position in Data.Numbers.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 10 }, result);
    }
}
