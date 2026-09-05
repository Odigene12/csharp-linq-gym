namespace LinqGym.ElementOperators;

/// <summary>
/// FirstOrDefault - like First, but returns default(T) (null / 0 / false) instead of throwing when nothing matches.
/// Since .NET 6 you can also pass the default value to return.
/// </summary>
public class FirstOrDefaultExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_NoMatchGivesZeroForInts()
    {
        // Task: the first number greater than 100 - there is none, so the result is default(int) = 0.
        int result = TODO;

        Assert.Equal(0, result);
    }

    [Fact]
    public void Easy_02_NoMatchGivesNullForClasses()
    {
        // Task: the first student named "Zelda" - none exists, so the result is null.
        Student? result = TODO;

        Assert.Null(result);
    }

    [Fact]
    public void Easy_03_EmptySequenceGivesDefault()
    {
        // Task: FirstOrDefault() on Data.Empty.
        int result = TODO;

        Assert.Equal(0, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ExplicitDefaultValue()
    {
        // Task: use the .NET 6 overload that takes a fallback: return -1 when no number is greater than 100.
        int result = TODO;

        Assert.Equal(-1, result);
    }

    [Fact]
    public void Medium_05_MatchIsReturnedNormally()
    {
        // Task: the first student from Knoxville.
        Student? result = TODO;

        Assert.Equal("Ethel", result?.FirstName);
    }

    [Fact]
    public void Medium_06_ZeroIsAmbiguousForValueTypes()
    {
        // Task: `nums` really contains 0, so FirstOrDefault cannot tell "found 0" from "found nothing".
        // Make the "nothing" case return null by turning the elements into int? first (Cast<int?> or Select).
        var nums = new[] { 0, 1 };

        int? result = TODO;

        Assert.Null(result);
    }

    [Fact]
    public void Medium_07_NullConditionalAfterFirstOrDefault()
    {
        // Task: the FirstName of the first student in "Paris", or null if there is none. Use ?. after FirstOrDefault.
        string? result = TODO;

        Assert.Null(result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_StudentWithNoEnrollments()
    {
        // Task: the first enrollment of student 12 - there is none.
        Enrollment? result = TODO;

        Assert.Null(result);
    }

    [Fact]
    public void Hard_09_HighestGradedEnrollment()
    {
        // Task: the enrollment with the highest Grade (order descending, then FirstOrDefault).
        Enrollment? result = TODO;

        Assert.Equal(17, result?.Id);
    }

    [Fact]
    public void Hard_10_FallbackObject()
    {
        // Task: the first student from "Paris", falling back to Data.Student(1) using the default-value overload.
        Student result = TODO;

        Assert.Equal("Anne", result.FirstName);
    }
}
