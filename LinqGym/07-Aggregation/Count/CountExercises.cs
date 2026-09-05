namespace LinqGym.Aggregation;

/// <summary>
/// Count - how many elements (optionally: how many match a predicate). Executes immediately.
/// Note: List&lt;T&gt;.Count and Array.Length are PROPERTIES; LINQ's Count() is a METHOD that may enumerate everything.
/// </summary>
public class CountExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_HowManyNumbers()
    {
        // Task: the number of elements in Data.Numbers, using the LINQ method.
        int result = Data.Numbers.Count(); //!

        Assert.Equal(10, result);
    }

    [Fact]
    public void Easy_02_HowManyActiveStudents()
    {
        // Task: how many students are Active (use the predicate overload, not Where + Count).
        int result = Data.Students.Count(s => s.Active); //!

        Assert.Equal(16, result);
    }

    [Fact]
    public void Easy_03_CountOfEmpty()
    {
        // Task: Count() of Data.Empty.
        int result = Data.Empty.Count(); //!

        Assert.Equal(0, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_InProgressEnrollments()
    {
        // Task: how many enrollments have no Grade yet.
        int result = Data.Enrollments.Count(e => e.Grade is null); //!

        Assert.Equal(3, result);
    }

    [Fact]
    public void Medium_05_StudentsInNashville()
    {
        // Task: how many students live in Nashville.
        int result = Data.Students.Count(s => s.City == "Nashville"); //!

        Assert.Equal(9, result);
    }

    [Fact]
    public void Medium_06_DistinctNumbers()
    {
        // Task: how many DIFFERENT values Data.Numbers contains.
        int result = Data.Numbers.Distinct().Count(); //!

        Assert.Equal(8, result);
    }

    [Fact]
    public void Medium_07_CoursesTaughtByInstructorOne()
    {
        // Task: how many courses have InstructorId 1.
        int result = Data.Courses.Count(c => c.InstructorId == 1); //!

        Assert.Equal(2, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_TotalCharactersAcrossAllWords()
    {
        // Task: the total number of characters in all of Data.Words (flatten, then count).
        int result = Data.Words.SelectMany(w => w).Count(); //!

        Assert.Equal(55, result);
    }

    [Fact]
    public void Hard_09_ActiveStudentsPerCohort()
    {
        // Task: (CohortName, ActiveStudentCount) for every cohort.
        IEnumerable<(string Name, int Active)> result = Data.Cohorts.Select(c => (c.Name, c.Students.Count(s => s.Active))); //!

        Assert.Equal(new[] { ("Evening Five", 4), ("Cohort of the Future", 5), ("Evening Ninja Warriors", 3), ("Day Backgammon Geeks", 4) }, result);
    }

    [Fact]
    public void Hard_10_CountEnumeratesEverything()
    {
        // Task: pass Data.Numbers through a counting Select and then Count(n => n > 0).
        // Unlike Any, Count must look at every element - all 10 flow through the selector.
        int evaluated = 0;

        int result = Data.Numbers.Select(n => { evaluated++; return n; }).Count(n => n > 0); //!

        Assert.Equal(10, result);
        Assert.Equal(10, evaluated);
    }
}
