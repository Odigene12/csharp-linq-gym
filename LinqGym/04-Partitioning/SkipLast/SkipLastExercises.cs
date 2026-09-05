namespace LinqGym.Partitioning;

/// <summary>
/// SkipLast - everything except the last N elements.
/// </summary>
public class SkipLastExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_AllButLastThree()
    {
        // Task: Data.Numbers without its last three values.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 5, 3, 8, 1, 9, 2, 8 }, result);
    }

    [Fact]
    public void Easy_02_AllButTheLastStudent()
    {
        // Task: every student except the last one.
        IEnumerable<Student> result = TODO;

        Assert.Equal(19, result.Count());
        Assert.Equal("Steve", result.Last().FirstName);
    }

    [Fact]
    public void Easy_03_SkipLastMoreThanAvailable()
    {
        // Task: SkipLast(100) is empty.
        IEnumerable<int> result = TODO;

        LinqAssert.IsEmpty(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_SkipLastZero()
    {
        // Task: SkipLast(0) yields everything.
        IEnumerable<int> result = TODO;

        Assert.Equal(Data.Numbers, result);
    }

    [Fact]
    public void Medium_05_AllButTheYoungest()
    {
        // Task: students ordered oldest-first, without the youngest one.
        IEnumerable<Student> result = TODO;

        Assert.Equal(19, result.Count());
        Assert.Equal("Ingrid", result.Last().FirstName);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_TrimBothEnds()
    {
        // Task: drop the first AND the last number.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 3, 8, 1, 9, 2, 8, 7, 3 }, result);
    }

    [Fact]
    public void Hard_07_SkipLastIsDeferred()
    {
        // Task: build SkipLast(1) over `list`; after adding 4, the query must yield 1, 2, 3 (4 is now the last).
        var list = new List<int> { 1, 2, 3 };

        IEnumerable<int> query = TODO;

        list.Add(4);
        Assert.Equal(new[] { 1, 2, 3 }, query);
    }
}
