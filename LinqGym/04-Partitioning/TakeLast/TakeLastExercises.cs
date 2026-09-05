namespace LinqGym.Partitioning;

/// <summary>
/// TakeLast - the last N elements, in their original order.
/// </summary>
public class TakeLastExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_LastThreeNumbers()
    {
        // Task: the last three numbers.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 7, 3, 10 }, result);
    }

    [Fact]
    public void Easy_02_LastTwoStudents()
    {
        // Task: the first names of the last two students.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "Steve", "Terrence" }, result);
    }

    [Fact]
    public void Easy_03_TakeLastMoreThanAvailable()
    {
        // Task: TakeLast(100) yields everything.
        IEnumerable<int> result = TODO;

        Assert.Equal(10, result.Count());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_TakeLastZero()
    {
        // Task: TakeLast(0) is empty.
        IEnumerable<int> result = TODO;

        LinqAssert.IsEmpty(result);
    }

    [Fact]
    public void Medium_05_ThreeYoungestInAscendingAgeOrder()
    {
        // Task: sort students by Birthday (oldest first) and take the last three - the youngest, oldest-of-the-three first.
        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { 20, 9, 3 }, result.Select(s => s.Id));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_LastTwoWordsAlphabetically()
    {
        // Task: the two words that come last in ordinal order.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "fig", "grape" }, result);
    }

    [Fact]
    public void Hard_07_TwoMostRecentEnrollmentsNewestFirst()
    {
        // Task: order enrollments by EnrolledOn, take the last two, and reverse so the newest comes first.
        // Three enrollments share the latest date; the stable sort decides which two are "last".
        IEnumerable<Enrollment> result = TODO;

        Assert.Equal(new[] { 23, 21 }, result.Select(e => e.Id));
    }
}
