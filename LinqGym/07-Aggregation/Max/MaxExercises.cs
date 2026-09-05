namespace LinqGym.Aggregation;

/// <summary>
/// Max - the largest VALUE (or the largest value produced by a selector). Same empty/null rules as Min.
/// </summary>
public class MaxExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_LargestNumber()
    {
        // Task: the largest value in Data.Numbers.
        int result = TODO;

        Assert.Equal(10, result);
    }

    [Fact]
    public void Easy_02_HighestPrice()
    {
        // Task: the largest price.
        decimal result = TODO;

        Assert.Equal(120.00m, result);
    }

    [Fact]
    public void Easy_03_LongestWordLength()
    {
        // Task: the largest word Length.
        int result = TODO;

        Assert.Equal(10, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_LatestInstructorBirthday()
    {
        // Task: the latest Birthday among instructors.
        DateOnly result = TODO;

        Assert.Equal(new DateOnly(2298, 1, 1), result);
    }

    [Fact]
    public void Medium_05_MaxOfEmptyThrows()
    {
        // Task: Max() on Data.Empty throws InvalidOperationException.
        Assert.Throws<InvalidOperationException>(() =>
        {
            int result = TODO;
        });
    }

    [Fact]
    public void Medium_06_MaxIgnoresNulls()
    {
        // Task: the largest non-null score in Data.NullableScores.
        int? result = TODO;

        Assert.Equal(100, result);
    }

    [Fact]
    public void Medium_07_HighestGrade()
    {
        // Task: the highest Grade across all enrollments.
        int? result = TODO;

        Assert.Equal(100, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_MaxWithAComparer()
    {
        // Task: the largest word ignoring case (StringComparer.OrdinalIgnoreCase).
        string? result = TODO;

        Assert.Equal("grape", result);
    }

    [Fact]
    public void Hard_09_LargestCityPopulation()
    {
        // Task: the number of students in the most populous city (group by City, then Max of the group sizes).
        int result = TODO;

        Assert.Equal(9, result);
    }

    [Fact]
    public void Hard_10_OldestAgePerCohort()
    {
        // Task: for each cohort, the highest student Age.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 54, 57, 53, 77 }, result);
    }
}
