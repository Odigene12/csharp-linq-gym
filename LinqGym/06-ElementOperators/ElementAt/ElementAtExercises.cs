namespace LinqGym.ElementOperators;

/// <summary>
/// ElementAt - the element at a zero-based position (or an Index such as ^1). Throws ArgumentOutOfRangeException if out of range.
/// </summary>
public class ElementAtExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_FifthNumber()
    {
        // Task: the element at index 4.
        int result = TODO;

        Assert.Equal(9, result);
    }

    [Fact]
    public void Easy_02_TenthStudent()
    {
        // Task: the student at index 9.
        Student result = TODO;

        Assert.Equal("Jacob", result.FirstName);
    }

    [Fact]
    public void Easy_03_LastViaIndexFromEnd()
    {
        // Task: the last number using an Index from the end (^1).
        int result = TODO;

        Assert.Equal(10, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_OutOfRangeThrows()
    {
        // Task: ElementAt(10) on a 10-element list throws ArgumentOutOfRangeException.
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            int result = TODO;
        });
    }

    [Fact]
    public void Medium_05_MiddleOfASortedSequence()
    {
        // Task: sort Data.Numbers ascending and return the element at index 4.
        int result = TODO;

        Assert.Equal(5, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_SecondToLastStudent()
    {
        // Task: the second-to-last student using an Index from the end.
        Student result = TODO;

        Assert.Equal("Steve", result.FirstName);
    }

    [Fact]
    public void Hard_07_ThirdYoungestStudent()
    {
        // Task: the third-youngest student (order by Birthday descending, then ElementAt).
        Student result = TODO;

        Assert.Equal("Terrence", result.FirstName);
    }
}
