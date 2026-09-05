namespace LinqGym.Concatenation;

/// <summary>
/// Append - a new sequence with one extra element at the END. The source is not modified.
/// </summary>
public class AppendExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_AppendEleven()
    {
        // Task: Data.Numbers with 11 added at the end.
        IEnumerable<int> result = Data.Numbers.Append(11); //!

        Assert.Equal(11, result.Count());
        Assert.Equal(11, result.Last());
    }

    [Fact]
    public void Easy_02_AppendToEmpty()
    {
        // Task: Data.Empty with 1 appended.
        IEnumerable<int> result = Data.Empty.Append(1); //!

        Assert.Equal(new[] { 1 }, result);
    }

    [Fact]
    public void Easy_03_AppendDoesNotMutateTheSource()
    {
        // Task: append 99 to Data.Numbers; the original list still has 10 elements.
        IEnumerable<int> result = Data.Numbers.Append(99); //!

        Assert.Equal(11, result.Count());
        Assert.Equal(10, Data.Numbers.Count);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_AppendAStudent()
    {
        // Task: Data.Students with Data.Student(1) appended again (21 elements, Anne last).
        IEnumerable<Student> result = Data.Students.Append(Data.Student(1)); //!

        Assert.Equal(21, result.Count());
        Assert.Equal("Anne", result.Last().FirstName);
    }

    [Fact]
    public void Medium_05_ChainTwoAppends()
    {
        // Task: Data.Numbers followed by 0 and then -1.
        IEnumerable<int> result = Data.Numbers.Append(0).Append(-1); //!

        Assert.Equal(new[] { 0, -1 }, result.TakeLast(2));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_AppendIsDeferred()
    {
        // Task: build list.Append(4); the 5 added to the list afterwards appears BEFORE the appended 4.
        var list = new List<int> { 1, 2, 3 };

        IEnumerable<int> query = list.Append(4); //!

        list.Add(5);
        Assert.Equal(new[] { 1, 2, 3, 5, 4 }, query);
    }

    [Fact]
    public void Hard_07_TotalRow()
    {
        // Task: Data.Prices followed by their sum as a final "total" element.
        IEnumerable<decimal> result = Data.Prices.Append(Data.Prices.Sum()); //!

        Assert.Equal(7, result.Count());
        Assert.Equal(194.46m, result.Last());
    }
}
