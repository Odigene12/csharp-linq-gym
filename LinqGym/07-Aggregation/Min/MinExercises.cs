namespace LinqGym.Aggregation;

/// <summary>
/// Min - the smallest VALUE (or the smallest value produced by a selector). Throws on empty non-nullable sequences;
/// returns null for empty nullable/reference sequences. Compare with MinBy, which returns the ELEMENT.
/// </summary>
public class MinExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_SmallestNumber()
    {
        // Task: the smallest value in Data.Numbers.
        int result = TODO;

        Assert.Equal(1, result);
    }

    [Fact]
    public void Easy_02_CheapestPrice()
    {
        // Task: the smallest price.
        decimal result = TODO;

        Assert.Equal(0.99m, result);
    }

    [Fact]
    public void Easy_03_ShortestWordLength()
    {
        // Task: the smallest word Length (selector overload).
        int result = TODO;

        Assert.Equal(3, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_EarliestBirthday()
    {
        // Task: the earliest student Birthday (DateOnly is comparable, so Min works on it).
        DateOnly result = TODO;

        Assert.Equal(new DateOnly(1948, 10, 31), result);
    }

    [Fact]
    public void Medium_05_MinOfEmptyThrows()
    {
        // Task: Min() on Data.Empty throws InvalidOperationException.
        Assert.Throws<InvalidOperationException>(() =>
        {
            int result = TODO;
        });
    }

    [Fact]
    public void Medium_06_MinIgnoresNulls()
    {
        // Task: the smallest non-null score in Data.NullableScores.
        int? result = TODO;

        Assert.Equal(70, result);
    }

    [Fact]
    public void Medium_07_MinOfEmptyNullableIsNull()
    {
        // Task: Min over an empty sequence of int? is null, not an exception. Project Data.Empty to int? first.
        int? result = TODO;

        Assert.Null(result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_MinWithAComparer()
    {
        // Task: the smallest word using StringComparer.Ordinal (uppercase sorts first, so "APPLE").
        string? result = TODO;

        Assert.Equal("APPLE", result);
    }

    [Fact]
    public void Hard_09_YoungestAgeInNashville()
    {
        // Task: the smallest Age among students living in Nashville.
        int result = TODO;

        Assert.Equal(37, result);
    }

    [Fact]
    public void Hard_10_LowestGradeInCourseOne()
    {
        // Task: the lowest Grade among enrollments in course 1.
        int? result = TODO;

        Assert.Equal(59, result);
    }
}
