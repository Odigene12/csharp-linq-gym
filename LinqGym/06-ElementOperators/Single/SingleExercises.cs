namespace LinqGym.ElementOperators;

/// <summary>
/// Single - the ONE element (optionally the one matching a predicate).
/// Throws InvalidOperationException if there are zero OR more than one. Use it to assert uniqueness.
/// </summary>
public class SingleExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_StudentWithIdSeven()
    {
        // Task: the single student whose Id is 7.
        Student result = Data.Students.Single(s => s.Id == 7); //!

        Assert.Equal("Gary", result.FirstName);
    }

    [Fact]
    public void Easy_02_CohortWithThreeJuniorInstructors()
    {
        // Task: the only cohort that has exactly three junior instructors.
        Cohort result = Data.Cohorts.Single(c => c.JuniorInstructors.Count == 3); //!

        Assert.Equal(3, result.Id);
    }

    [Fact]
    public void Easy_03_CourseWithoutInstructor()
    {
        // Task: the only course whose InstructorId is null.
        Course result = Data.Courses.Single(c => c.InstructorId is null); //!

        Assert.Equal("SE100", result.Code);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_SingleOnAOneElementSequence()
    {
        // Task: Single() without a predicate on a sequence that has exactly one element.
        var one = new[] { 42 };

        int result = one.Single(); //!

        Assert.Equal(42, result);
    }

    [Fact]
    public void Medium_05_MultipleMatchesThrow()
    {
        // Task: ask for the Single student from Memphis. Four match, so Single must throw.
        Assert.Throws<InvalidOperationException>(() =>
        {
            Student result = Data.Students.Single(s => s.City == "Memphis"); //!
        });
    }

    [Fact]
    public void Medium_06_NoMatchThrows()
    {
        // Task: ask for the Single student named "Zelda". None match, so Single must throw.
        Assert.Throws<InvalidOperationException>(() =>
        {
            Student result = Data.Students.Single(s => s.FirstName == "Zelda"); //!
        });
    }

    [Fact]
    public void Medium_07_SingleOnManyElementsThrows()
    {
        // Task: Single() with no predicate on Data.Numbers (10 elements) must throw.
        Assert.Throws<InvalidOperationException>(() =>
        {
            int result = Data.Numbers.Single(); //!
        });
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_FullTimeCohortWithAFuturisticInstructor()
    {
        // Task: the single cohort that is FullTime AND whose PrimaryInstructor was born after the year 2100.
        Cohort result = Data.Cohorts.Single(c => c.FullTime && c.PrimaryInstructor.Birthday.Year > 2100); //!

        Assert.Equal(2, result.Id);
    }

    [Fact]
    public void Hard_09_SingleThenMemberAccess()
    {
        // Task: the LastName of the single instructor whose Specialty is "Quantum".
        string result = Data.Instructors.Single(i => i.Specialty == "Quantum").LastName; //!

        Assert.Equal("Zohan", result);
    }

    [Fact]
    public void Hard_10_SingleVersusFirst()
    {
        // Task: four students live in Knoxville. First happily returns the first one; Single throws.
        Student first = Data.Students.First(s => s.City == "Knoxville"); //!
        Assert.Equal("Ethel", first.FirstName);

        Assert.Throws<InvalidOperationException>(() =>
        {
            Student single = Data.Students.Single(s => s.City == "Knoxville"); //!
        });
    }
}
