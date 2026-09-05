namespace LinqGym.ElementOperators;

/// <summary>
/// LastOrDefault - like Last, but returns default(T) (or a value you supply) instead of throwing.
/// </summary>
public class LastOrDefaultExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_NoMatchGivesZero()
    {
        // Task: the last number greater than 100 (there is none).
        int result = Data.Numbers.LastOrDefault(n => n > 100); //!

        Assert.Equal(0, result);
    }

    [Fact]
    public void Easy_02_NoMatchGivesNull()
    {
        // Task: the last student living in "Paris" (there is none).
        Student? result = Data.Students.LastOrDefault(s => s.City == "Paris"); //!

        Assert.Null(result);
    }

    [Fact]
    public void Easy_03_EmptyGivesDefault()
    {
        // Task: LastOrDefault() on Data.Empty.
        int result = Data.Empty.LastOrDefault(); //!

        Assert.Equal(0, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ExplicitDefaultValue()
    {
        // Task: -1 when no number is greater than 100 (use the overload with a default value).
        int result = Data.Numbers.LastOrDefault(n => n > 100, -1); //!

        Assert.Equal(-1, result);
    }

    [Fact]
    public void Medium_05_LastEnrollmentOfStudentNine()
    {
        // Task: the last enrollment (in list order) belonging to student 9.
        Enrollment? result = Data.Enrollments.LastOrDefault(e => e.StudentId == 9); //!

        Assert.Equal(17, result?.Id);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_LastEnrollmentOf2024ByDate()
    {
        // Task: order enrollments by EnrolledOn and return the last one from 2024.
        // Four enrollments share the last 2024 date; the stable sort keeps them in list order.
        Enrollment? result = Data.Enrollments.OrderBy(e => e.EnrolledOn).LastOrDefault(e => e.EnrolledOn.Year == 2024); //!

        Assert.Equal(31, result?.Id);
    }

    [Fact]
    public void Hard_07_NullConditionalChain()
    {
        // Task: the FirstName of the last student without an email, using ?. after LastOrDefault.
        string? result = Data.Students.LastOrDefault(s => s.Email is null)?.FirstName; //!

        Assert.Equal("Quincy", result);
    }
}
