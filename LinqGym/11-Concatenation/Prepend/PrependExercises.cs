namespace LinqGym.Concatenation;

/// <summary>
/// Prepend - a new sequence with one extra element at the START. The source is not modified.
/// </summary>
public class PrependExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_PrependZero()
    {
        // Task: Data.Numbers with 0 in front.
        IEnumerable<int> result = TODO;

        Assert.Equal(0, result.First());
        Assert.Equal(11, result.Count());
    }

    [Fact]
    public void Easy_02_PrependToEmpty()
    {
        // Task: Data.Empty with 1 prepended.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1 }, result);
    }

    [Fact]
    public void Easy_03_PrependDoesNotMutateTheSource()
    {
        // Task: prepend 99; Data.Numbers itself still starts with 5.
        IEnumerable<int> result = TODO;

        Assert.Equal(99, result.First());
        Assert.Equal(5, Data.Numbers[0]);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_HeaderRow()
    {
        // Task: Data.Words with a "FRUITS" header in front.
        IEnumerable<string> result = TODO;

        Assert.Equal("FRUITS", result.First());
        Assert.Equal(11, result.Count());
    }

    [Fact]
    public void Medium_05_PrependAndAppend()
    {
        // Task: 0 in front of Data.Numbers and 11 at the end.
        IEnumerable<int> result = TODO;

        Assert.Equal(12, result.Count());
        Assert.Equal(0, result.First());
        Assert.Equal(11, result.Last());
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_PrependIsDeferred()
    {
        // Task: build list.Prepend(0); an element added to the list later still shows up (at the end).
        var list = new List<int> { 1, 2 };

        IEnumerable<int> query = TODO;

        list.Add(3);
        Assert.Equal(new[] { 0, 1, 2, 3 }, query);
    }

    [Fact]
    public void Hard_07_PrimaryInstructorFirst()
    {
        // Task: cohort 3's instructors with the PrimaryInstructor first, then the juniors (Ids).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 3, 4, 6, 1 }, result);
    }
}
