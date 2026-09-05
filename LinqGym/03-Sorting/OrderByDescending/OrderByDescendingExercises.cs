namespace LinqGym.Sorting;

/// <summary>
/// OrderByDescending - sort descending by a key. Also stable.
/// </summary>
public class OrderByDescendingExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_NumbersDescending()
    {
        // Task: Data.Numbers from largest to smallest.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 10, 9, 8, 8, 7, 5, 3, 3, 2, 1 }, result);
    }

    [Fact]
    public void Easy_02_StudentsYoungestFirst()
    {
        // Task: students ordered by Birthday, latest birthday first.
        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { 3, 9, 20, 16 }, result.Take(4).Select(s => s.Id));
    }

    [Fact]
    public void Easy_03_PricesHighToLow()
    {
        // Task: Data.Prices from most to least expensive.
        IEnumerable<decimal> result = TODO;

        Assert.Equal(new[] { 120.00m, 42.50m, 19.99m, 5.49m, 5.49m, 0.99m }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_LongestWordsFirstIsStable()
    {
        // Task: words by Length, longest first. Equal lengths keep original order.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "Elderberry", "Banana", "cherry", "banana", "apple", "apple", "APPLE", "grape", "date", "fig" }, result);
    }

    [Fact]
    public void Medium_05_NewestCohortsFirst()
    {
        // Task: cohorts by StartDate, most recent first.
        IEnumerable<Cohort> result = TODO;

        Assert.Equal(new[] { 3, 1, 4, 2 }, result.Select(c => c.Id));
    }

    [Fact]
    public void Medium_06_NullableGradesPutNullsLast()
    {
        // Task: enrollments by Grade, highest first. Null is the smallest possible value, so in-progress
        // enrollments (Grade == null) end up at the END of a descending sort.
        IEnumerable<Enrollment> result = TODO;

        Assert.Equal(100, result.First().Grade);
        Assert.All(result.TakeLast(3), e => Assert.Null(e.Grade));
    }

    [Fact]
    public void Medium_07_CoursesByCredits()
    {
        // Task: courses by Credits, highest first (stable among equal credits).
        IEnumerable<Course> result = TODO;

        Assert.Equal(new[] { "JS201", "QC999", "CS201", "DB201", "CS101", "JS101", "DB101", "SE100" }, result.Select(c => c.Code));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_ThreeOldestStudents()
    {
        // Task: the first names of the three oldest students (highest Age first).
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "Richard", "Quincy", "Steve" }, result);
    }

    [Fact]
    public void Hard_09_DescendingCaseInsensitive()
    {
        // Task: words descending with StringComparer.OrdinalIgnoreCase (ties keep original order).
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "grape", "fig", "Elderberry", "date", "cherry", "Banana", "banana", "apple", "apple", "APPLE" }, result);
    }

    [Fact]
    public void Hard_10_CitiesByStudentCount()
    {
        // Task: city names ordered by how many students live there, most first.
        // Memphis and Knoxville tie at 4 - because the sort is stable, the group that appeared first wins.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "Nashville", "Memphis", "Knoxville", "Chattanooga" }, result);
    }
}
