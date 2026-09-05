namespace LinqGym.Aggregation;

/// <summary>
/// Sum - add up numbers (int, long, float, double, decimal and their nullable versions). Nulls are skipped.
/// An empty sequence sums to 0. Integer sums are CHECKED - overflow throws.
/// </summary>
public class SumExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_SumOfNumbers()
    {
        // Task: the total of Data.Numbers.
        int result = Data.Numbers.Sum(); //!

        Assert.Equal(56, result);
    }

    [Fact]
    public void Easy_02_SumOfPrices()
    {
        // Task: the total of Data.Prices (decimal).
        decimal result = Data.Prices.Sum(); //!

        Assert.Equal(194.46m, result);
    }

    [Fact]
    public void Easy_03_SumWithASelector()
    {
        // Task: the total number of characters in Data.Words, using Sum with a selector.
        int result = Data.Words.Sum(w => w.Length); //!

        Assert.Equal(55, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_NullsAreIgnored()
    {
        // Task: the sum of Data.NullableScores. The result type is int? and null entries are skipped.
        int? result = Data.NullableScores.Sum(); //!

        Assert.Equal(345, result);
    }

    [Fact]
    public void Medium_05_SumOfEmptyIsZero()
    {
        // Task: Sum of Data.Empty.
        int result = Data.Empty.Sum(); //!

        Assert.Equal(0, result);
    }

    [Fact]
    public void Medium_06_TotalBackendCredits()
    {
        // Task: the total Credits of all courses in the "Backend" category.
        int result = Data.Courses.Where(c => c.Category == "Backend").Sum(c => c.Credits); //!

        Assert.Equal(7, result);
    }

    [Fact]
    public void Medium_07_SumOfAllGrades()
    {
        // Task: the sum of every Grade across all enrollments (selector returns int?, nulls skipped).
        int? result = Data.Enrollments.Sum(e => e.Grade); //!

        Assert.Equal(2375, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_SumOfDoubles()
    {
        // Task: the sum of Data.Temperatures. Floating point, so the assertion allows a tiny tolerance.
        double result = Data.Temperatures.Sum(); //!

        Assert.Equal(512.4, result, 6);
    }

    [Fact]
    public void Hard_09_CreditsEnrolledByStudentOne()
    {
        // Task: the total Credits of all courses student 1 is enrolled in (look up each course with Data.Course(id)).
        int result = Data.Enrollments.Where(e => e.StudentId == 1).Sum(e => Data.Course(e.CourseId).Credits); //!

        Assert.Equal(10, result);
    }

    [Fact]
    public void Hard_10_OverflowThrowsUnlessYouWiden()
    {
        // Task: summing int.MaxValue + 1 as ints throws OverflowException. Summing them as longs (selector cast) works.
        var big = new[] { int.MaxValue, 1 };

        Assert.Throws<OverflowException>(() =>
        {
            int overflow = big.Sum(); //!
        });

        long widened = big.Sum(n => (long)n); //!

        Assert.Equal(2_147_483_648L, widened);
    }
}
