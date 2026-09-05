namespace LinqGym.Quantifiers;

/// <summary>
/// All - true if EVERY element satisfies the predicate. True for an empty sequence ("vacuous truth").
/// Stops at the first element that fails.
/// </summary>
public class AllExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_AllNumbersPositive()
    {
        // Task: are all numbers greater than zero?
        bool result = Data.Numbers.All(n => n > 0); //!

        Assert.True(result);
    }

    [Fact]
    public void Easy_02_NotAllStudentsActive()
    {
        // Task: are all students active?
        bool result = Data.Students.All(s => s.Active); //!

        Assert.False(result);
    }

    [Fact]
    public void Easy_03_AllOnAnEmptySequenceIsTrue()
    {
        // Task: All over Data.Empty - there is no element that fails the predicate, so the answer is true.
        bool result = Data.Empty.All(n => n > 1000); //!

        Assert.True(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_AllInstructorsBornBefore2000()
    {
        // Task: were all instructors born before the year 2000? (Check Zachary...)
        bool result = Data.Instructors.All(i => i.Birthday.Year < 2000); //!

        Assert.False(result);
    }

    [Fact]
    public void Medium_05_AllWordsNonEmpty()
    {
        // Task: does every word have at least one character?
        bool result = Data.Words.All(w => w.Length > 0); //!

        Assert.True(result);
    }

    [Fact]
    public void Medium_06_EveryCohortHasFiveStudents()
    {
        // Task: does every cohort have exactly five students?
        bool result = Data.Cohorts.All(c => c.Students.Count == 5); //!

        Assert.True(result);
    }

    [Fact]
    public void Medium_07_CohortsWhereAllStudentsAreActive()
    {
        // Task: the cohorts in which every student is active (All inside a Where).
        IEnumerable<Cohort> result = Data.Cohorts.Where(c => c.Students.All(s => s.Active)); //!

        Assert.Equal(new[] { "Cohort of the Future" }, result.Select(c => c.Name));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_AllShortCircuits()
    {
        // Task: pass Data.Numbers through a counting Select, then ask All(n => n < 8).
        // The first failure (8) is at index 2, so exactly three elements are evaluated.
        int evaluated = 0;

        bool result = Data.Numbers.Select(n => { evaluated++; return n; }).All(n => n < 8); //!

        Assert.False(result);
        Assert.Equal(3, evaluated);
    }

    [Fact]
    public void Hard_09_CoursesWhereEveryGradeIsAtLeastSeventy()
    {
        // Task: courses where every GRADED enrollment (Grade not null) is >= 70.
        // QC999 has no enrollments at all - All over an empty set is true, so it is included.
        IEnumerable<Course> result = Data.Courses.Where(c => Data.Enrollments.Where(e => e.CourseId == c.Id && e.Grade.HasValue).All(e => e.Grade >= 70)); //!

        Assert.Equal(new[] { 2, 4, 6, 7, 8 }, result.Select(c => c.Id));
    }

    [Fact]
    public void Hard_10_AllIsTheSameAsNotAny()
    {
        // Task: "every student is an adult" written both ways: with All, and as the negation of Any.
        bool viaAll = Data.Students.All(s => s.Age >= 18); //!
        bool viaAny = !Data.Students.Any(s => s.Age < 18); //!

        Assert.True(viaAll);
        Assert.True(viaAny);
    }
}
