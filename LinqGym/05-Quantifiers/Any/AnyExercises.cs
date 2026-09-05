namespace LinqGym.Quantifiers;

/// <summary>
/// Any - true if the sequence has at least one element (or one that matches the predicate).
/// Stops at the first match, so it is the cheapest way to ask "is there one?".
/// </summary>
public class AnyExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_AnyNumberAboveNine()
    {
        // Task: is there any number greater than 9?
        bool result = Data.Numbers.Any(n => n > 9); //!

        Assert.True(result);
    }

    [Fact]
    public void Easy_02_AnyStudentInChattanooga()
    {
        // Task: does any student live in Chattanooga?
        bool result = Data.Students.Any(s => s.City == "Chattanooga"); //!

        Assert.True(result);
    }

    [Fact]
    public void Easy_03_AnyOnAnEmptySequence()
    {
        // Task: Any() with no predicate asks "is there at least one element?". Data.Empty has none.
        bool result = Data.Empty.Any(); //!

        Assert.False(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_AnyInactiveInstructor()
    {
        // Task: is any instructor inactive?
        bool result = Data.Instructors.Any(i => !i.Active); //!

        Assert.True(result);
    }

    [Fact]
    public void Medium_05_NoStudentNamedZelda()
    {
        // Task: is there a student whose FirstName is "Zelda"?
        bool result = Data.Students.Any(s => s.FirstName == "Zelda"); //!

        Assert.False(result);
    }

    [Fact]
    public void Medium_06_AnyWithoutPredicate()
    {
        // Task: does Data.Numbers contain at least one element?
        bool result = Data.Numbers.Any(); //!

        Assert.True(result);
    }

    [Fact]
    public void Medium_07_CohortsWithAnyInactiveStudent()
    {
        // Task: the cohorts that have at least one inactive student (Any inside a Where).
        IEnumerable<Cohort> result = Data.Cohorts.Where(c => c.Students.Any(s => !s.Active)); //!

        Assert.Equal(new[] { 1, 3, 4 }, result.Select(c => c.Id));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_AnyInProgressEnrollment()
    {
        // Task: is any enrollment still in progress (Grade is null)? Prefer Any(...) over Count(...) > 0.
        bool result = Data.Enrollments.Any(e => e.Grade is null); //!

        Assert.True(result);
    }

    [Fact]
    public void Hard_09_AnyShortCircuits()
    {
        // Task: pass Data.Numbers through a counting Select, then ask Any(n => n == 8).
        // The first 8 is at index 2, so exactly three elements should be evaluated.
        int evaluated = 0;

        bool result = Data.Numbers.Select(n => { evaluated++; return n; }).Any(n => n == 8); //!

        Assert.True(result);
        Assert.Equal(3, evaluated);
    }

    [Fact]
    public void Hard_10_StudentsWithAnyGradeOfNinetyOrMore()
    {
        // Task: students who have at least one enrollment graded 90 or higher (correlate via Data.Enrollments).
        IEnumerable<Student> result = Data.Students.Where(s => Data.Enrollments.Any(e => e.StudentId == s.Id && e.Grade >= 90)); //!

        Assert.Equal(new[] { 1, 3, 5, 9, 16 }, result.Select(s => s.Id));
    }
}
