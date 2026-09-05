namespace LinqGym.Aggregation;

/// <summary>
/// MaxBy (.NET 6+) - the ELEMENT whose key is largest. Ties -> the first element.
/// </summary>
public class MaxByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_YoungestStudent()
    {
        // Task: the student with the latest Birthday.
        Student? result = Data.Students.MaxBy(s => s.Birthday); //!

        Assert.Equal("Carrie", result?.FirstName);
    }

    [Fact]
    public void Easy_02_LongestWord()
    {
        // Task: the word with the greatest Length.
        string? result = Data.Words.MaxBy(w => w.Length); //!

        Assert.Equal("Elderberry", result);
    }

    [Fact]
    public void Easy_03_CourseWithMostCredits()
    {
        // Task: the course with the most Credits. Two courses have 5 credits - the first one in the list wins.
        Course? result = Data.Courses.MaxBy(c => c.Credits); //!

        Assert.Equal("JS201", result?.Code);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_MaxByOnEmptyIsNull()
    {
        // Task: MaxBy over instructors with Specialty "Cobol" (none) returns null.
        Instructor? result = Data.Instructors.Where(i => i.Specialty == "Cobol").MaxBy(i => i.Age); //!

        Assert.Null(result);
    }

    [Fact]
    public void Medium_05_KeyIsNotTheValue()
    {
        // Task: the number with the largest remainder mod 5 (9 % 5 == 4 is the biggest remainder).
        int result = Data.Numbers.MaxBy(n => n % 5); //!

        Assert.Equal(9, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_MaxByWithAComparer()
    {
        // Task: the ordinally-largest word (pass StringComparer.Ordinal as the key comparer).
        string? result = Data.Words.MaxBy(w => w, StringComparer.Ordinal); //!

        Assert.Equal("grape", result);
    }

    [Fact]
    public void Hard_07_CohortWithTheHighestAverageAge()
    {
        // Task: the cohort whose students have the highest average Age.
        Cohort? result = Data.Cohorts.MaxBy(c => c.Students.Average(s => s.Age)); //!

        Assert.Equal("Day Backgammon Geeks", result?.Name);
    }
}
