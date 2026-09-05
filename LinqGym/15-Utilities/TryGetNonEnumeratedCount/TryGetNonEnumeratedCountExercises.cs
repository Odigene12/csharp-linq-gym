namespace LinqGym.Utilities;

/// <summary>
/// TryGetNonEnumeratedCount (.NET 6+) - ask "do you know your count WITHOUT enumerating?".
/// Collections and many simple iterators (Select, Skip, Take, Range...) say yes; Where, Distinct, GroupBy say no.
/// Use it to pre-size buffers without accidentally running an expensive query twice.
/// </summary>
public class TryGetNonEnumeratedCountExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ListKnowsItsCount()
    {
        // Task: call TryGetNonEnumeratedCount on Data.Numbers, capturing the count into `count`.
        int count = -1;

        bool result = TODO;

        Assert.True(result);
        Assert.Equal(10, count);
    }

    [Fact]
    public void Easy_02_WhereDoesNot()
    {
        // Task: a Where query cannot know its count without running.
        int count = -1;

        bool result = TODO;

        Assert.False(result);
        Assert.Equal(0, count);
    }

    [Fact]
    public void Easy_03_ArraysKnowTheirCount()
    {
        // Task: an array reports its length.
        int count = -1;

        bool result = TODO;

        Assert.True(result);
        Assert.Equal(10, count);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_SelectOverAListKeepsTheCount()
    {
        // Task: Select does not change the number of elements, so its count is known cheaply.
        int count = -1;

        bool result = TODO;

        Assert.True(result);
        Assert.Equal(10, count);
    }

    [Fact]
    public void Medium_05_RangeKnowsItsCount()
    {
        // Task: Enumerable.Range(1, 5).
        int count = -1;

        bool result = TODO;

        Assert.True(result);
        Assert.Equal(5, count);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_MaterializingMakesTheCountKnown()
    {
        // Task: the same Where query, but materialized with ToList first - now the count is known.
        int count = -1;

        bool result = TODO;

        Assert.True(result);
        Assert.Equal(6, count);
    }

    [Fact]
    public void Hard_07_SkipAndTakeStillKnow()
    {
        // Task: Skip(2) over a list - the runtime can compute 10 - 2 without enumerating.
        int count = -1;

        bool result = TODO;

        Assert.True(result);
        Assert.Equal(8, count);
    }
}
