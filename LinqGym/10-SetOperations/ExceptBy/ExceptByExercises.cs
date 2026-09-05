namespace LinqGym.SetOperations;

/// <summary>
/// ExceptBy (.NET 6+) - elements of the first sequence whose KEY is not in the second sequence of KEYS. Distinct by key.
/// </summary>
public class ExceptByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_StudentsExceptSomeIds()
    {
        // Task: students whose Id is not 1, 2 or 3.
        IEnumerable<Student> result = Data.Students.ExceptBy(new[] { 1, 2, 3 }, s => s.Id); //!

        Assert.Equal(17, result.Count());
        Assert.Equal("Derek", result.First().FirstName);
    }

    [Fact]
    public void Easy_02_WordsExceptLengths()
    {
        // Task: words whose Length is neither 5 nor 6.
        IEnumerable<string> result = Data.Words.ExceptBy(new[] { 5, 6 }, w => w.Length); //!

        Assert.Equal(new[] { "date", "Elderberry", "fig" }, result);
    }

    [Fact]
    public void Easy_03_CoursesOutsideACategory()
    {
        // Task: courses whose Category is not "Backend". Remember: ExceptBy is distinct BY KEY, so only the first
        // course of each remaining category survives (Frontend, Data, Research, General).
        IEnumerable<Course> result = Data.Courses.ExceptBy(new[] { "Backend" }, c => c.Category); //!

        Assert.Equal(new[] { "JS101", "DB101", "QC999", "SE100" }, result.Select(c => c.Code));
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ExceptByWithAComparer()
    {
        // Task: words except "APPLE" and "banana" ignoring case; remember the result is distinct by key.
        IEnumerable<string> result = Data.Words.ExceptBy(new[] { "APPLE", "banana" }, w => w, StringComparer.OrdinalIgnoreCase); //!

        Assert.Equal(new[] { "cherry", "date", "Elderberry", "fig", "grape" }, result);
    }

    [Fact]
    public void Medium_05_StudentsNeverEnrolled()
    {
        // Task: students whose Id is not in the StudentIds of Data.Enrollments.
        IEnumerable<int> result = Data.Students.ExceptBy(Data.Enrollments.Select(e => e.StudentId), s => s.Id).Select(s => s.Id); //!

        Assert.Equal(new[] { 2, 12, 17 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_CoursesNobodyEnrolledIn()
    {
        // Task: courses whose Id never appears as an enrollment CourseId.
        IEnumerable<string> result = Data.Courses.ExceptBy(Data.Enrollments.Select(e => e.CourseId), c => c.Id).Select(c => c.Code); //!

        Assert.Equal(new[] { "QC999" }, result);
    }

    [Fact]
    public void Hard_07_ExceptByDeduplicates()
    {
        // Task: Data.Numbers except-by value [1] - the duplicate 8 and 3 collapse to one each.
        IEnumerable<int> result = Data.Numbers.ExceptBy(new[] { 1 }, n => n); //!

        Assert.Equal(new[] { 5, 3, 8, 9, 2, 7, 10 }, result);
    }
}
