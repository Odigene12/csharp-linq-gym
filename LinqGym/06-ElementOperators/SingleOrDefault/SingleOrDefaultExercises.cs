namespace LinqGym.ElementOperators;

/// <summary>
/// SingleOrDefault - the one matching element, or default(T) when there are NONE.
/// Still throws when there is MORE than one - "OrDefault" only covers the empty case.
/// </summary>
public class SingleOrDefaultExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_NoMatchGivesNull()
    {
        // Task: the student with Id 99 (none).
        Student? result = TODO;

        Assert.Null(result);
    }

    [Fact]
    public void Easy_02_ExactlyOneMatch()
    {
        // Task: the student with Id 5.
        Student? result = TODO;

        Assert.Equal("Ethel", result?.FirstName);
    }

    [Fact]
    public void Easy_03_EmptySequenceGivesDefault()
    {
        // Task: SingleOrDefault() on Data.Empty.
        int result = TODO;

        Assert.Equal(0, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ExplicitDefaultValue()
    {
        // Task: -1 when no number is greater than 100 (overload with a default value).
        int result = TODO;

        Assert.Equal(-1, result);
    }

    [Fact]
    public void Medium_05_MultipleMatchesStillThrow()
    {
        // Task: SingleOrDefault for active students - 16 match, so it throws even though it is the "OrDefault" variant.
        Assert.Throws<InvalidOperationException>(() =>
        {
            Student? result = TODO;
        });
    }

    [Fact]
    public void Medium_06_CourseCodeLookupMiss()
    {
        // Task: the course with Code "XX999" (none).
        Course? result = TODO;

        Assert.Null(result);
    }

    [Fact]
    public void Medium_07_OnlyEnrollmentOfStudentSeven()
    {
        // Task: student 7 has exactly one enrollment - return it.
        Enrollment? result = TODO;

        Assert.Equal(12, result?.Id);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_NoCohortTaughtByZelda()
    {
        // Task: the cohort whose PrimaryInstructor's FirstName is "Zelda" (none).
        Cohort? result = TODO;

        Assert.Null(result);
    }

    [Fact]
    public void Hard_09_NullConditionalChain()
    {
        // Task: the Title of the course with Code "QC999", via SingleOrDefault(...)?.Title.
        string? result = TODO;

        Assert.Equal("Quantum Computing", result);
    }

    [Fact]
    public void Hard_10_DoNotUseSingleOrDefaultAsAnExistsCheck()
    {
        // Task: "students with exactly one enrollment". A naive SingleOrDefault inside Where THROWS as soon as it
        // meets a student with two enrollments. Write the naive version inside Assert.Throws, then the correct
        // version using Count(...) == 1.
        Assert.Throws<InvalidOperationException>(() =>
        {
            List<Student> naive = TODO;
        });

        IEnumerable<Student> correct = TODO;

        Assert.Equal(new[] { 7, 11, 15, 18 }, correct.Select(s => s.Id));
    }
}
