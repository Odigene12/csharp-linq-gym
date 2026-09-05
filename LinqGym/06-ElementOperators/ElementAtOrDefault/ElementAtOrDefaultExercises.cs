namespace LinqGym.ElementOperators;

/// <summary>
/// ElementAtOrDefault - like ElementAt, but returns default(T) instead of throwing when the position is out of range.
/// </summary>
public class ElementAtOrDefaultExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_OutOfRangeGivesZero()
    {
        // Task: index 20 on a 10-element list.
        int result = TODO;

        Assert.Equal(0, result);
    }

    [Fact]
    public void Easy_02_OutOfRangeGivesNull()
    {
        // Task: student at index 50.
        Student? result = TODO;

        Assert.Null(result);
    }

    [Fact]
    public void Easy_03_InRangeWorksNormally()
    {
        // Task: the element at index 0.
        int result = TODO;

        Assert.Equal(5, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_NegativeIndexGivesDefault()
    {
        // Task: a negative index does not throw - it yields default.
        int result = TODO;

        Assert.Equal(0, result);
    }

    [Fact]
    public void Medium_05_IndexFromEndOutOfRange()
    {
        // Task: ^20 on a 10-element list is out of range - default again.
        int result = TODO;

        Assert.Equal(0, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_SafeLookupThenNullConditional()
    {
        // Task: the FirstName of the student at index 99, or null.
        string? result = TODO;

        Assert.Null(result);
    }

    [Fact]
    public void Hard_07_SeventhWord()
    {
        // Task: the word at index 6.
        string? result = TODO;

        Assert.Equal("Elderberry", result);
    }
}
