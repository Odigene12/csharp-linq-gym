namespace LinqGym.SetOperations;

/// <summary>
/// Intersect - the distinct elements that appear in BOTH sequences, in the order of the first sequence.
/// </summary>
public class IntersectExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_CommonNumbers()
    {
        // Task: the values in both Data.SetA and Data.SetB.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 4, 5 }, result);
    }

    [Fact]
    public void Easy_02_IntersectWithAnArray()
    {
        // Task: the values of Data.Numbers that are also in [3, 8, 100].
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 3, 8 }, result);
    }

    [Fact]
    public void Easy_03_IntersectWithEmpty()
    {
        // Task: anything intersected with Data.Empty is empty.
        IEnumerable<int> result = TODO;

        LinqAssert.IsEmpty(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_IntersectIgnoringCase()
    {
        // Task: tags present in both TagsA and TagsB ignoring case (elements come from TagsA).
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "LINQ", "dotnet" }, result);
    }

    [Fact]
    public void Medium_05_SharedJuniorInstructors()
    {
        // Task: junior instructors shared by cohort 1 and cohort 3 (Ids).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_StudentsInBothCourses()
    {
        // Task: the StudentIds enrolled in course 1 AND course 2.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 4, 16 }, result);
    }

    [Fact]
    public void Hard_07_CommonCharacters()
    {
        // Task: the characters that "linq" and "language" have in common.
        IEnumerable<char> result = TODO;

        Assert.Equal(new[] { 'l', 'n' }, result);
    }
}
