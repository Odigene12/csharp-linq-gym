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
        Student? result = Data.Students.MinBy(s => s.Birthday); //!

        Assert.Equal("Richard", result?.FirstName);
    }

    [Fact]
    public void Easy_02_ShortestWord()
    {
        // Task: the word with the smallest Length.
        string? result = Data.Words.MinBy(w => w.Length); //!

        Assert.Equal("fig", result);
    }

    [Fact]
    public void Easy_03_CourseWithFewestCredits()
    {
        // Task: the course with the fewest Credits.
        Course? result = Data.Courses.MinBy(c => c.Credits); //!

        Assert.Equal("SE100", result?.Code);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_MinByOnEmptyIsNull()
    {
        // Task: MinBy over students from "Paris" (none) returns null.
        Student? result = Data.Students.Where(s => s.City == "Paris").MinBy(s => s.Age); //!

        Assert.Null(result);
    }

    [Fact]
    public void Medium_05_TiesGoToTheFirstElement()
    {
        // Task: the number with the smallest remainder mod 3. Both 3s and the 9 have remainder 0 - the FIRST wins.
        int result = Data.Numbers.MinBy(n => n % 3); //!

        Assert.Equal(3, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_MinByWithAComparer()
    {
        // Task: the alphabetically-first word ignoring case (pass StringComparer.OrdinalIgnoreCase as the key comparer).
        string? result = Data.Words.MinBy(w => w, StringComparer.OrdinalIgnoreCase); //!

        Assert.Equal("apple", result);
    }

    [Fact]
    public void Hard_07_StudentWithTheLowestAverageGrade()
    {
        // Task: among students that have at least one graded enrollment, the one with the lowest average Grade.
        Student? result = //!{
            Data.Students
                .Where(s => Data.Enrollments.Any(e => e.StudentId == s.Id && e.Grade.HasValue))
                .MinBy(s => Data.Enrollments.Where(e => e.StudentId == s.Id && e.Grade.HasValue).Average(e => e.Grade!.Value));
        //!}

        Assert.Equal("Gary", result?.FirstName);
    }
}
