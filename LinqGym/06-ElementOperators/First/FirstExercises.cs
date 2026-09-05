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
        int result = Data.Numbers.First(); //!

        Assert.Equal(5, result);
    }

    [Fact]
    public void Easy_02_FirstStudent()
    {
        // Task: the first student.
        Student result = Data.Students.First(); //!

        Assert.Equal("Anne", result.FirstName);
    }

    [Fact]
    public void Easy_03_FirstNumberAboveSeven()
    {
        // Task: the first number greater than 7.
        int result = Data.Numbers.First(n => n > 7); //!

        Assert.Equal(8, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_FirstInactiveStudent()
    {
        // Task: the first student who is not active.
        Student result = Data.Students.First(s => !s.Active); //!

        Assert.Equal("Bobbie", result.FirstName);
    }

    [Fact]
    public void Medium_05_FirstOnEmptyThrows()
    {
        // Task: call First() on Data.Empty. It must throw InvalidOperationException.
        Assert.Throws<InvalidOperationException>(() =>
        {
            int result = Data.Empty.First(); //!
        });
    }

    [Fact]
    public void Medium_06_FirstWithNoMatchThrows()
    {
        // Task: call First with a predicate nobody satisfies (e.g. a student named "Zelda").
        Assert.Throws<InvalidOperationException>(() =>
        {
            Student result = Data.Students.First(s => s.FirstName == "Zelda"); //!
        });
    }

    [Fact]
    public void Medium_07_FirstLongWord()
    {
        // Task: the first word longer than 6 characters.
        string result = Data.Words.First(w => w.Length > 6); //!

        Assert.Equal("Elderberry", result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_OldestStudentViaOrderByAndFirst()
    {
        // Task: the oldest student (order by Birthday, then First). Compare with MinBy later in the course.
        Student result = Data.Students.OrderBy(s => s.Birthday).First(); //!

        Assert.Equal(18, result.Id);
    }

    [Fact]
    public void Hard_09_FirstCohortTaughtByACSharpSpecialist()
    {
        // Task: the first cohort whose PrimaryInstructor has Specialty "C#".
        Cohort result = Data.Cohorts.First(c => c.PrimaryInstructor.Specialty == "C#"); //!

        Assert.Equal(3, result.Id);
    }

    [Fact]
    public void Hard_10_FirstShortCircuits()
    {
        // Task: pass Data.Numbers through a counting Select, then take First(n => n == 8). Only 3 elements should be evaluated.
        int evaluated = 0;

        int result = Data.Numbers.Select(n => { evaluated++; return n; }).First(n => n == 8); //!

        Assert.Equal(8, result);
        Assert.Equal(3, evaluated);
    }
}
