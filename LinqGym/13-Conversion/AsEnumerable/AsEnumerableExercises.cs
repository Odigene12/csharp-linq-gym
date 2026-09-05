namespace LinqGym.Conversion;

/// <summary>
/// AsEnumerable - returns the SAME object, typed as IEnumerable&lt;T&gt;. It does nothing at runtime; it changes which
/// methods the COMPILER picks (LINQ's instead of a collection's own, or Enumerable's instead of Queryable's).
/// </summary>
public class AsEnumerableExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ItIsTheSameObject()
    {
        // Task: AsEnumerable on Data.Numbers; the result is reference-equal to Data.Numbers.
        IEnumerable<int> result = TODO;

        Assert.Same(Data.Numbers, result);
    }

    [Fact]
    public void Easy_02_PickLinqReverseOverListReverse()
    {
        // Task: List<T>.Reverse() is void and mutates. Use AsEnumerable so that .Reverse() resolves to LINQ's.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 10, 3, 7, 8, 2, 9, 1, 8, 3, 5 }, result);
        Assert.Equal(5, Data.Numbers[0]);
    }

    [Fact]
    public void Easy_03_RuntimeTypeIsUnchanged()
    {
        // Task: the compile-time type becomes IEnumerable<int>, but the runtime object is still a List<int>.
        IEnumerable<int> result = TODO;

        Assert.IsType<List<int>>(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_LinqStillWorksAfterwards()
    {
        // Task: count the active students after AsEnumerable.
        int result = TODO;

        Assert.Equal(16, result);
    }

    [Fact]
    public void Medium_05_StringsAreSequencesOfChars()
    {
        // Task: the number of distinct characters in "hello" (AsEnumerable makes the char sequence explicit).
        int result = TODO;

        Assert.Equal(4, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_SwitchFromQueryableToEnumerable()
    {
        // Task: start from Data.Students.AsQueryable(), filter Active with Queryable.Where, then call AsEnumerable and
        // project to FullName. Everything after AsEnumerable runs as ordinary in-memory LINQ, not as an IQueryable.
        IEnumerable<string> result = TODO;

        Assert.Equal(16, result.Count());
        Assert.False(result is IQueryable);
    }

    [Fact]
    public void Hard_07_HideACollectionsOwnMethod()
    {
        // Task: HashSet<T> has its own Contains; after AsEnumerable, Contains resolves to Enumerable.Contains.
        // Return whether the set of numbers contains 7, going through AsEnumerable.
        var set = Data.Numbers.ToHashSet();

        bool result = TODO;

        Assert.True(result);
    }
}
