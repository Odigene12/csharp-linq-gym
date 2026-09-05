namespace LinqGym.Aggregation;

/// <summary>
/// MinBy (.NET 6+) - the ELEMENT whose key is smallest (Min returns the key itself). Ties -> the first element.
/// Empty sequence: null for reference types, exception for value types.
/// </summary>
public class MinByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_OldestStudent()
    {
        // Task: the student with the earliest Birthday.
        Student? result = TODO;

        Assert.Equal("Richard", result?.FirstName);
    }

    [Fact]
    public void Easy_02_ShortestWord()
    {
        // Task: the word with the smallest Length.
        string? result = TODO;

        Assert.Equal("fig", result);
    }

    [Fact]
    public void Easy_03_CourseWithFewestCredits()
    {
        // Task: the course with the fewest Credits.
        Course? result = TODO;

        Assert.Equal("SE100", result?.Code);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_MinByOnEmptyIsNull()
    {
        // Task: MinBy over students from "Paris" (none) returns null.
        Student? result = TODO;

        Assert.Null(result);
    }

    [Fact]
    public void Medium_05_TiesGoToTheFirstElement()
    {
        // Task: the number with the smallest remainder mod 3. Both 3s and the 9 have remainder 0 - the FIRST wins.
        int result = TODO;

        Assert.Equal(3, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_MinByWithAComparer()
    {
        // Task: the alphabetically-first word ignoring case (pass StringComparer.OrdinalIgnoreCase as the key comparer).
        string? result = TODO;

        Assert.Equal("apple", result);
    }

    [Fact]
    public void Hard_07_StudentWithTheLowestAverageGrade()
    {
        // Task: among students that have at least one graded enrollment, the one with the lowest average Grade.
        Student? result = TODO;

        Assert.Equal("Gary", result?.FirstName);
    }
}
