namespace LinqGym.ElementOperators;

/// <summary>
/// First - the first element (optionally the first that matches a predicate).
/// THROWS InvalidOperationException when there is no such element.
/// </summary>
public class FirstExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_FirstNumber()
    {
        // Task: the first value in Data.Numbers.
        int result = TODO;

        Assert.Equal(5, result);
    }

    [Fact]
    public void Easy_02_FirstStudent()
    {
        // Task: the first student.
        Student result = TODO;

        Assert.Equal("Anne", result.FirstName);
    }

    [Fact]
    public void Easy_03_FirstNumberAboveSeven()
    {
        // Task: the first number greater than 7.
        int result = TODO;

        Assert.Equal(8, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_FirstInactiveStudent()
    {
        // Task: the first student who is not active.
        Student result = TODO;

        Assert.Equal("Bobbie", result.FirstName);
    }

    [Fact]
    public void Medium_05_FirstOnEmptyThrows()
    {
        // Task: call First() on Data.Empty. It must throw InvalidOperationException.
        Assert.Throws<InvalidOperationException>(() =>
        {
            int result = TODO;
        });
    }

    [Fact]
    public void Medium_06_FirstWithNoMatchThrows()
    {
        // Task: call First with a predicate nobody satisfies (e.g. a student named "Zelda").
        Assert.Throws<InvalidOperationException>(() =>
        {
            Student result = TODO;
        });
    }

    [Fact]
    public void Medium_07_FirstLongWord()
    {
        // Task: the first word longer than 6 characters.
        string result = TODO;

        Assert.Equal("Elderberry", result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_OldestStudentViaOrderByAndFirst()
    {
        // Task: the oldest student (order by Birthday, then First). Compare with MinBy later in the course.
        Student result = TODO;

        Assert.Equal(18, result.Id);
    }

    [Fact]
    public void Hard_09_FirstCohortTaughtByACSharpSpecialist()
    {
        // Task: the first cohort whose PrimaryInstructor has Specialty "C#".
        Cohort result = TODO;

        Assert.Equal(3, result.Id);
    }

    [Fact]
    public void Hard_10_FirstShortCircuits()
    {
        // Task: pass Data.Numbers through a counting Select, then take First(n => n == 8). Only 3 elements should be evaluated.
        int evaluated = 0;

        int result = TODO;

        Assert.Equal(8, result);
        Assert.Equal(3, evaluated);
    }
}
