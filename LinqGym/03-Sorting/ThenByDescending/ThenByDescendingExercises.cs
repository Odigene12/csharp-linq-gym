namespace LinqGym.Sorting;

/// <summary>
/// ThenByDescending - a secondary DESCENDING sort key.
/// </summary>
public class ThenByDescendingExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ByCityThenOldestFirst()
    {
        // Task: students by City, then by Age descending within each city.
        IEnumerable<Student> result = Data.Students.OrderBy(s => s.City).ThenByDescending(s => s.Age); //!

        Assert.Equal(new[] { 18, 7, 13, 5, 15, 20, 9, 6, 11, 16, 3, 17, 19, 8, 14, 1, 12, 4, 10, 2 }, result.Select(s => s.Id));
    }

    [Fact]
    public void Easy_02_ByCategoryThenMostCredits()
    {
        // Task: courses by Category, then by Credits descending.
        IEnumerable<Course> result = Data.Courses.OrderBy(c => c.Category).ThenByDescending(c => c.Credits); //!

        Assert.Equal(new[] { "CS201", "CS101", "DB201", "DB101", "JS201", "JS101", "SE100", "QC999" }, result.Select(c => c.Code));
    }

    [Fact]
    public void Easy_03_EvensThenOddsEachDescending()
    {
        // Task: even numbers first (largest first), then odd numbers (largest first).
        IEnumerable<int> result = Data.Numbers.OrderBy(n => n % 2).ThenByDescending(n => n); //!

        Assert.Equal(new[] { 10, 8, 8, 2, 9, 7, 5, 3, 3, 1 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ByCourseThenBestGradeFirst()
    {
        // Task: enrollments by CourseId, then Grade descending (in-progress/null grades last within a course).
        IEnumerable<Enrollment> result = Data.Enrollments.OrderBy(e => e.CourseId).ThenByDescending(e => e.Grade); //!

        Assert.Equal(new[] { 26, 20, 2, 7 }, result.Where(e => e.CourseId == 2).Select(e => e.Id));
    }

    [Fact]
    public void Medium_05_ByLengthThenReverseAlphabetical()
    {
        // Task: words by Length ascending, then ordinal descending within a length.
        IEnumerable<string> result = Data.Words.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.Ordinal); //!

        Assert.Equal(new[] { "fig", "date", "grape", "apple", "apple", "APPLE", "cherry", "banana", "Banana", "Elderberry" }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_MixAscendingAndDescendingLevels()
    {
        // Task: instructors by Specialty (asc), then Active (true first), then Birthday (asc).
        IEnumerable<Instructor> result = Data.Instructors.OrderBy(i => i.Specialty).ThenByDescending(i => i.Active).ThenBy(i => i.Birthday); //!

        Assert.Equal(new[] { 1, 3, 5, 4, 2, 6 }, result.Select(i => i.Id));
    }

    [Fact]
    public void Hard_07_CitiesByCountThenNameDescending()
    {
        // Task: city names by student count (most first); ties broken by name DESCENDING.
        IEnumerable<string> result = Data.Students.GroupBy(s => s.City).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).Select(g => g.Key); //!

        Assert.Equal(new[] { "Nashville", "Memphis", "Knoxville", "Chattanooga" }, result);
    }
}
