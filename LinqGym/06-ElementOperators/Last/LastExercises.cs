namespace LinqGym.ElementOperators;

/// <summary>
/// Last - the last element (optionally the last that matches). Throws when there is none.
/// </summary>
public class LastExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_LastNumber()
    {
        // Task: the last value in Data.Numbers.
        int result = TODO;

        Assert.Equal(10, result);
    }

    [Fact]
    public void Easy_02_LastStudent()
    {
        // Task: the last student.
        Student result = TODO;

        Assert.Equal("Terrence", result.FirstName);
    }

    [Fact]
    public void Easy_03_LastNumberBelowFive()
    {
        // Task: the last number that is less than 5.
        int result = TODO;

        Assert.Equal(3, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_LastInactiveStudent()
    {
        // Task: the last inactive student.
        Student result = TODO;

        Assert.Equal("Quincy", result.FirstName);
    }

    [Fact]
    public void Medium_05_LastOnEmptyThrows()
    {
        // Task: Last() on Data.Empty throws InvalidOperationException.
        Assert.Throws<InvalidOperationException>(() =>
        {
            int result = TODO;
        });
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_LastFiveLetterWord()
    {
        // Task: the last word with exactly 5 characters.
        string result = TODO;

        Assert.Equal("grape", result);
    }

    [Fact]
    public void Hard_07_YoungestStudentViaOrderByAndLast()
    {
        // Task: the youngest student (order by Birthday ascending, then Last).
        Student result = TODO;

        Assert.Equal("Carrie", result.FirstName);
    }
}
