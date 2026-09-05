namespace LinqGym.SetOperations;

/// <summary>
/// DistinctBy (.NET 6+) - remove elements whose KEY was already seen. Keeps the first element per key.
/// </summary>
public class DistinctByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_FirstStudentPerCity()
    {
        // Task: one student per City - the first one seen.
        IEnumerable<Student> result = Data.Students.DistinctBy(s => s.City); //!

        Assert.Equal(new[] { 1, 3, 5, 7 }, result.Select(s => s.Id));
    }

    [Fact]
    public void Easy_02_FirstWordPerLength()
    {
        // Task: one word per Length.
        IEnumerable<string> result = Data.Words.DistinctBy(w => w.Length); //!

        Assert.Equal(new[] { "apple", "Banana", "date", "Elderberry", "fig" }, result);
    }

    [Fact]
    public void Easy_03_OneEnrollmentPerCourse()
    {
        // Task: one enrollment per CourseId (7 courses have enrollments).
        IEnumerable<Enrollment> result = Data.Enrollments.DistinctBy(e => e.CourseId); //!

        Assert.Equal(7, result.Count());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_DistinctByWithAComparer()
    {
        // Task: words distinct by themselves, ignoring case (pass StringComparer.OrdinalIgnoreCase as the key comparer).
        IEnumerable<string> result = Data.Words.DistinctBy(w => w, StringComparer.OrdinalIgnoreCase); //!

        Assert.Equal(7, result.Count());
    }

    [Fact]
    public void Medium_05_OneStudentPerBirthYear()
    {
        // Task: one student per birth year.
        IEnumerable<Student> result = Data.Students.DistinctBy(s => s.Birthday.Year); //!

        Assert.Equal(16, result.Count());
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_NewestEnrollmentPerStudent()
    {
        // Task: each student's most recent enrollment: order by EnrolledOn descending, then DistinctBy StudentId.
        // Student 1 has two enrollments on the same latest date - the stable sort keeps id 2 before id 3.
        IEnumerable<Enrollment> result = Data.Enrollments.OrderByDescending(e => e.EnrolledOn).DistinctBy(e => e.StudentId); //!

        Assert.Equal(2, result.Single(e => e.StudentId == 1).Id);
        Assert.Equal(17, result.Single(e => e.StudentId == 9).Id);
        Assert.Equal(17, result.Count());
    }

    [Fact]
    public void Hard_07_CompositeKey()
    {
        // Task: how many distinct (City, Active) combinations exist among students.
        int result = Data.Students.DistinctBy(s => (s.City, s.Active)).Count(); //!

        Assert.Equal(6, result);
    }
}
