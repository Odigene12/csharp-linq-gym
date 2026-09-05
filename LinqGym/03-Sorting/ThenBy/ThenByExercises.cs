namespace LinqGym.Sorting;

/// <summary>
/// ThenBy - a secondary ascending sort key, applied within groups of equal primary keys.
/// Only available on an IOrderedEnumerable (i.e. right after OrderBy/OrderByDescending/ThenBy...).
/// </summary>
public class ThenByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ByCityThenLastName()
    {
        // Task: students by City, then by LastName within each city.
        IEnumerable<Student> result = Data.Students.OrderBy(s => s.City).ThenBy(s => s.LastName); //!

        Assert.Equal(new[] { 7, 13, 18, 5, 9, 15, 20, 3, 6, 11, 16, 1, 2, 4, 8, 10, 12, 14, 17, 19 }, result.Select(s => s.Id));
    }

    [Fact]
    public void Easy_02_ByLengthThenOrdinal()
    {
        // Task: words by Length, then alphabetically using StringComparer.Ordinal.
        IEnumerable<string> result = Data.Words.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.Ordinal); //!

        Assert.Equal(new[] { "fig", "date", "APPLE", "apple", "apple", "grape", "Banana", "banana", "cherry", "Elderberry" }, result);
    }

    [Fact]
    public void Easy_03_ByCategoryThenCredits()
    {
        // Task: courses by Category, then by Credits (ascending).
        IEnumerable<Course> result = Data.Courses.OrderBy(c => c.Category).ThenBy(c => c.Credits); //!

        Assert.Equal(new[] { "CS101", "CS201", "DB101", "DB201", "JS101", "JS201", "SE100", "QC999" }, result.Select(c => c.Code));
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_InactiveFirstThenByBirthday()
    {
        // Task: instructors ordered by Active (false first) then by Birthday.
        IEnumerable<Instructor> result = Data.Instructors.OrderBy(i => i.Active).ThenBy(i => i.Birthday); //!

        Assert.Equal(new[] { 4, 2, 5, 1, 3, 6 }, result.Select(i => i.Id));
    }

    [Fact]
    public void Medium_05_ByStudentThenCourse()
    {
        // Task: enrollments by StudentId then CourseId. Student 10 enrolled in course 5 before course 1,
        // so the secondary key must reorder those two rows.
        IEnumerable<Enrollment> result = Data.Enrollments.OrderBy(e => e.StudentId).ThenBy(e => e.CourseId); //!

        Assert.Equal(new[] { 32, 18 }, result.Where(e => e.StudentId == 10).Select(e => e.Id));
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, result.Take(5).Select(e => e.Id));
    }

    [Fact]
    public void Medium_06_ThreeLevels()
    {
        // Task: students by City, then Active (inactive first), then FirstName.
        IEnumerable<Student> result = Data.Students.OrderBy(s => s.City).ThenBy(s => s.Active).ThenBy(s => s.FirstName); //!

        Assert.Equal(new[]
        {
            "Gary", "Matt", "Richard",
            "Ethel", "Ingrid", "Ophelia", "Terrence",
            "Kate", "Carrie", "Francis", "Paul",
            "Bobbie", "Louis", "Quincy", "Anne", "Derek", "Howard", "Jacob", "Nancy", "Steve",
        }, result.Select(s => s.FirstName));
    }

    [Fact]
    public void Medium_07_ByRemainderThenValue()
    {
        // Task: numbers grouped by remainder when divided by 3 (0, 1, 2), and ascending within each remainder.
        IEnumerable<int> result = Data.Numbers.OrderBy(n => n % 3).ThenBy(n => n); //!

        Assert.Equal(new[] { 3, 3, 9, 1, 7, 10, 2, 5, 8, 8 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_ThenByAfterDescending()
    {
        // Task: cohorts with Active ones first (descending bool), then by Name.
        IEnumerable<Cohort> result = Data.Cohorts.OrderByDescending(c => c.Active).ThenBy(c => c.Name); //!

        Assert.Equal(new[] { 1, 3, 2, 4 }, result.Select(c => c.Id));
    }

    [Fact]
    public void Hard_09_ThenByVersusASecondOrderBy()
    {
        // Task: write both queries. `correct` sorts by City then LastName.
        // `overwritten` chains OrderBy(City).OrderBy(LastName) - the second OrderBy REPLACES the first,
        // so the result is simply sorted by LastName (which for our data is Id order).
        IEnumerable<Student> correct = Data.Students.OrderBy(s => s.City).ThenBy(s => s.LastName); //!
        IEnumerable<Student> overwritten = Data.Students.OrderBy(s => s.City).OrderBy(s => s.LastName); //!

        Assert.Equal(7, correct.First().Id);
        Assert.Equal(Enumerable.Range(1, 20), overwritten.Select(s => s.Id));
    }

    [Fact]
    public void Hard_10_OrderGroupsByCountThenKey()
    {
        // Task: city names ordered by student count (most first), ties broken alphabetically by city name.
        IEnumerable<string> result = Data.Students.GroupBy(s => s.City).OrderByDescending(g => g.Count()).ThenBy(g => g.Key).Select(g => g.Key); //!

        Assert.Equal(new[] { "Nashville", "Knoxville", "Memphis", "Chattanooga" }, result);
    }
}
