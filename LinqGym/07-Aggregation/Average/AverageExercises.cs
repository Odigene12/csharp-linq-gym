namespace LinqGym.Aggregation;

/// <summary>
/// Average - the arithmetic mean. int/long sources give a double; decimal gives decimal.
/// Throws on an empty NON-nullable sequence; returns null for an empty NULLABLE sequence.
/// </summary>
public class AverageExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_AverageOfNumbers()
    {
        // Task: the mean of Data.Numbers (56 / 10).
        double result = Data.Numbers.Average(); //!

        Assert.Equal(5.6, result);
    }

    [Fact]
    public void Easy_02_AverageTemperature()
    {
        // Task: the mean of Data.Temperatures.
        double result = Data.Temperatures.Average(); //!

        Assert.Equal(73.2, result, 6);
    }

    [Fact]
    public void Easy_03_AveragePrice()
    {
        // Task: the mean of Data.Prices (decimal in, decimal out).
        decimal result = Data.Prices.Average(); //!

        Assert.Equal(32.41m, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_AverageOfEmptyThrows()
    {
        // Task: Average() over Data.Empty throws InvalidOperationException.
        Assert.Throws<InvalidOperationException>(() =>
        {
            double result = Data.Empty.Average(); //!
        });
    }

    [Fact]
    public void Medium_05_NullsAreIgnored()
    {
        // Task: the average of Data.NullableScores. Nulls are skipped: (90 + 85 + 70 + 100) / 4.
        double? result = Data.NullableScores.Average(); //!

        Assert.Equal(86.25, result);
    }

    [Fact]
    public void Medium_06_AverageStudentAge()
    {
        // Task: the average Age of all students.
        double result = Data.Students.Average(s => s.Age); //!

        Assert.Equal(46.9, result, 6);
    }

    [Fact]
    public void Medium_07_AverageWordLength()
    {
        // Task: the average Length of Data.Words.
        double result = Data.Words.Average(w => w.Length); //!

        Assert.Equal(5.5, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_AverageGradeAcrossAllGradedEnrollments()
    {
        // Task: the average Grade of all enrollments (selector returns int?; nulls skipped; result is double?).
        double? result = Data.Enrollments.Average(e => e.Grade); //!

        Assert.Equal(81.8966, result!.Value, 4);
    }

    [Fact]
    public void Hard_09_AverageOfEmptyNullableIsNull()
    {
        // Task: make the average of Data.Empty come back as null instead of throwing, by projecting to int? first.
        double? result = Data.Empty.Select(n => (int?)n).Average(); //!

        Assert.Null(result);
    }

    [Fact]
    public void Hard_10_AverageGradeForCourseOne()
    {
        // Task: the average Grade of enrollments in course 1.
        double? result = Data.Enrollments.Where(e => e.CourseId == 1).Average(e => e.Grade); //!

        Assert.Equal(79.625, result);
    }
}
