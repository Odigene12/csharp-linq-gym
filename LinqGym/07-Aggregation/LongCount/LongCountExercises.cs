namespace LinqGym.Aggregation;

/// <summary>
/// LongCount - Count, but returns a long. Use it when a sequence could exceed int.MaxValue elements.
/// </summary>
public class LongCountExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_LongCountOfNumbers()
    {
        // Task: how many numbers, as a long.
        long result = Data.Numbers.LongCount(); //!

        Assert.Equal(10L, result);
    }

    [Fact]
    public void Easy_02_InactiveStudents()
    {
        // Task: how many students are inactive, as a long (predicate overload).
        long result = Data.Students.LongCount(s => !s.Active); //!

        Assert.Equal(4L, result);
    }

    [Fact]
    public void Easy_03_EmptyIsZero()
    {
        // Task: LongCount of Data.Empty.
        long result = Data.Empty.LongCount(); //!

        Assert.Equal(0L, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_CountAMillion()
    {
        // Task: LongCount of Enumerable.Range(1, 1_000_000).
        long result = Enumerable.Range(1, 1_000_000).LongCount(); //!

        Assert.Equal(1_000_000L, result);
    }

    [Fact]
    public void Medium_05_CellsInTheMatrix()
    {
        // Task: how many cells Data.Matrix has in total (flatten, then LongCount).
        long result = Data.Matrix.SelectMany(row => row).LongCount(); //!

        Assert.Equal(9L, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_MultiplesOfSevenBelow100001()
    {
        // Task: how many numbers in Range(1, 100000) are divisible by 7.
        long result = Enumerable.Range(1, 100_000).LongCount(n => n % 7 == 0); //!

        Assert.Equal(14_285L, result);
    }

    [Fact]
    public void Hard_07_EnrollmentsGradedEightyOrMore()
    {
        // Task: how many enrollments have a Grade of 80 or more (null grades do not count).
        long result = Data.Enrollments.LongCount(e => e.Grade >= 80); //!

        Assert.Equal(18L, result);
    }
}
