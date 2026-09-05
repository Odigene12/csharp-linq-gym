namespace LinqGym.Partitioning;

/// <summary>
/// SkipWhile - skip elements from the start as long as the predicate is true, then yield EVERYTHING that follows.
/// </summary>
public class SkipWhileExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_SkipWhileLessThanEight()
    {
        // Task: skip the leading numbers that are less than 8, keep the rest (including later small values).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 8, 1, 9, 2, 8, 7, 3, 10 }, result);
    }

    [Fact]
    public void Easy_02_SkipWhileLongerThanFour()
    {
        // Task: skip the leading words longer than 4 characters.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "date", "banana", "Elderberry", "fig", "APPLE", "grape" }, result);
    }

    [Fact]
    public void Easy_03_SkipUntilNine()
    {
        // Task: skip everything before the first 9 (the 9 itself is kept).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 9, 2, 8, 7, 3, 10 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_SkipLeadingActiveStudents()
    {
        // Task: skip students while they are Active. The first inactive student (Bobbie) and everyone after remain.
        IEnumerable<Student> result = TODO;

        Assert.Equal(19, result.Count());
        Assert.Equal("Bobbie", result.First().FirstName);
    }

    [Fact]
    public void Medium_05_SkipWhileWithIndex()
    {
        // Task: use the (element, index) overload to skip the first seven positions.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 7, 3, 10 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_StripLeadingZeros()
    {
        // Task: remove the zeros at the start only.
        var digits = new[] { 0, 0, 0, 4, 0, 5 };

        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 4, 0, 5 }, result);
    }

    [Fact]
    public void Hard_07_EnrollmentsFromTheFirst2025One()
    {
        // Task: order enrollments by EnrolledOn, then skip while the year is before 2025.
        IEnumerable<Enrollment> result = TODO;

        Assert.Equal(15, result.Count());
        Assert.Equal(1, result.First().Id);
    }
}
