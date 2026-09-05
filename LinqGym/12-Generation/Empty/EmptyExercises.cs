namespace LinqGym.Generation;

/// <summary>
/// Enumerable.Empty&lt;T&gt;() - a cached, allocation-free empty sequence. Prefer it over `new T[0]` or null.
/// </summary>
public class EmptyExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_EmptyInts()
    {
        // Task: an empty sequence of int.
        IEnumerable<int> result = TODO;

        Assert.Equal(0, result.Count());
    }

    [Fact]
    public void Easy_02_NullCoalesceToEmpty()
    {
        // Task: `maybe` might be null; produce a safe sequence with ?? and Enumerable.Empty.
        string[]? maybe = null;

        IEnumerable<string> result = TODO;

        LinqAssert.IsEmpty(result);
    }

    [Fact]
    public void Easy_03_SumOfEmptyIsZero()
    {
        // Task: Sum over Enumerable.Empty<int>().
        int result = TODO;

        Assert.Equal(0, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_EmptyIsASingleton()
    {
        // Task: two calls to Enumerable.Empty<int>() return the very same object (use ReferenceEquals).
        bool result = TODO;

        Assert.True(result);
    }

    [Fact]
    public void Medium_05_EmptyAsAStartingPoint()
    {
        // Task: start from Empty and Concat [1, 2] onto it.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 2 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_EmptyWithDefaultIfEmpty()
    {
        // Task: Enumerable.Empty<int>() with DefaultIfEmpty(42) yields exactly [42].
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 42 }, result);
    }

    [Fact]
    public void Hard_07_ConditionalQuery()
    {
        // Task: when includeArchived is false, return Enumerable.Empty<Student>(); otherwise the inactive students.
        bool includeArchived = false;

        IEnumerable<Student> result = TODO;

        LinqAssert.IsEmpty(result);
    }
}
