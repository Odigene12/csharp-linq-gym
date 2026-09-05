namespace LinqGym.SetOperations;

/// <summary>
/// IntersectBy (.NET 6+) - elements of the first sequence whose KEY appears in the second sequence of KEYS.
/// Note the asymmetry: the second argument is a sequence of keys, not elements. Result is distinct by key.
/// </summary>
public class IntersectByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_StudentsWithGivenIds()
    {
        // Task: students whose Id is in [3, 5, 99].
        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { 3, 5 }, result.Select(s => s.Id));
    }

    [Fact]
    public void Easy_02_ResultIsDistinctByKey()
    {
        // Task: words whose Length is 5. Four words qualify, but IntersectBy yields only the FIRST per key.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "apple" }, result);
    }

    [Fact]
    public void Easy_03_FirstCoursePerWantedCategory()
    {
        // Task: courses whose Category is Backend or Data (first per category).
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "CS101", "DB101" }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_IntersectByWithAComparer()
    {
        // Task: words matching ["BANANA", "grape"] ignoring case.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "Banana", "grape" }, result);
    }

    [Fact]
    public void Medium_05_EnrollmentsOfInactiveStudents()
    {
        // Task: enrollments whose StudentId belongs to an inactive student (only Kate, id 11, has one).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 19 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_StudentsWhoHaveAnyEnrollment()
    {
        // Task: the students whose Id appears in Data.Enrollments.
        IEnumerable<Student> result = TODO;

        Assert.Equal(17, result.Count());
    }

    [Fact]
    public void Hard_07_CoursesTaughtByActiveInstructors()
    {
        // Task: courses whose InstructorId is the Id of an ACTIVE instructor. Key types must match (int? vs int).
        IEnumerable<Course> result = TODO;

        Assert.Equal(new[] { "CS101", "CS201", "JS101", "DB101", "QC999" }, result.Select(c => c.Code));
    }
}
