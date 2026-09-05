namespace LinqGym.Generation;

/// <summary>
/// Enumerable.Repeat(element, count) - the same element `count` times. For reference types it is the SAME instance every time.
/// </summary>
public class RepeatExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ThreeXs()
    {
        // Task: "x" three times.
        IEnumerable<string> result = Enumerable.Repeat("x", 3); //!

        Assert.Equal(new[] { "x", "x", "x" }, result);
    }

    [Fact]
    public void Easy_02_FiveZeros()
    {
        // Task: five zeros.
        IEnumerable<int> result = Enumerable.Repeat(0, 5); //!

        Assert.Equal(new[] { 0, 0, 0, 0, 0 }, result);
    }

    [Fact]
    public void Easy_03_ZeroTimesIsEmpty()
    {
        // Task: repeat anything zero times.
        IEnumerable<string> result = Enumerable.Repeat("never", 0); //!

        LinqAssert.IsEmpty(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_NumberedRows()
    {
        // Task: "Row 1", "Row 2", "Row 3" - Repeat "Row" then Select with the index.
        IEnumerable<string> result = Enumerable.Repeat("Row", 3).Select((s, i) => $"{s} {i + 1}"); //!

        Assert.Equal(new[] { "Row 1", "Row 2", "Row 3" }, result);
    }

    [Fact]
    public void Medium_05_ReferenceTypesShareOneInstance()
    {
        // Task: repeat a single new List<int> three times; every element is the very same list object.
        List<List<int>> result = Enumerable.Repeat(new List<int>(), 3).ToList(); //!

        Assert.Same(result[0], result[1]);
        Assert.Same(result[1], result[2]);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_NegativeCountThrows()
    {
        // Task: a negative count throws ArgumentOutOfRangeException.
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            IEnumerable<int> result = Enumerable.Repeat(1, -1); //!
        });
    }

    [Fact]
    public void Hard_07_BuildAStringOfDashes()
    {
        // Task: "-----" built from Repeat('-', 5) and string.Concat.
        string result = string.Concat(Enumerable.Repeat('-', 5)); //!

        Assert.Equal("-----", result);
    }
}
