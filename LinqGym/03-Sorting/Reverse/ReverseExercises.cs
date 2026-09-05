namespace LinqGym.Sorting;

/// <summary>
/// Reverse - yield the elements in the opposite order (no sorting involved).
/// Watch out: List&lt;T&gt; has its OWN void Reverse() method that mutates the list in place. When you call
/// .Reverse() on a List&lt;T&gt;, the compiler picks that one, not LINQ's. Use Enumerable.Reverse(list) or
/// list.AsEnumerable().Reverse() to get the LINQ version.
/// </summary>
public class ReverseExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_NumbersReversed()
    {
        // Task: Data.Numbers in reverse order. Data.Numbers is a List<int> - see the class comment above!
        IEnumerable<int> result = Data.Numbers.AsEnumerable().Reverse(); //!

        Assert.Equal(new[] { 10, 3, 7, 8, 2, 9, 1, 8, 3, 5 }, result);
    }

    [Fact]
    public void Easy_02_ReverseAString()
    {
        // Task: the string "linq" reversed. A string is an IEnumerable<char>; turn the result back into a string.
        string result = new string("linq".Reverse().ToArray()); //!

        Assert.Equal("qnil", result);
    }

    [Fact]
    public void Easy_03_StudentsLastToFirst()
    {
        // Task: students in reverse order.
        IEnumerable<Student> result = Enumerable.Reverse(Data.Students); //!

        Assert.Equal("Terrence", result.First().FirstName);
        Assert.Equal("Anne", result.Last().FirstName);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ReversingASortIsNotADescendingSort()
    {
        // Task: `reversed` = words ordered by Length, then reversed. `descending` = words ordered by Length descending.
        // They differ! Reversing flips the order of equal-length words too, while OrderByDescending keeps them stable.
        IEnumerable<string> reversed = Data.Words.OrderBy(w => w.Length).Reverse(); //!
        IEnumerable<string> descending = Data.Words.OrderByDescending(w => w.Length); //!

        Assert.Equal(new[] { "Elderberry", "banana", "cherry", "Banana", "grape", "APPLE", "apple", "apple", "date", "fig" }, reversed);
        Assert.Equal(new[] { "Elderberry", "Banana", "cherry", "banana", "apple", "apple", "APPLE", "grape", "date", "fig" }, descending);
    }

    [Fact]
    public void Medium_05_ReverseRowsAndCells()
    {
        // Task: reverse the order of the rows in Data.Matrix AND reverse each row, then flatten.
        IEnumerable<int> result = Data.Matrix.AsEnumerable().Reverse().SelectMany(row => row.Reverse()); //!

        Assert.Equal(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_ReverseIsDeferred()
    {
        // Task: build a reversed query over `list` (do not materialize). The element added later must appear first.
        var list = new List<int> { 1, 2, 3 };

        IEnumerable<int> query = list.AsEnumerable().Reverse(); //!

        list.Add(4);
        Assert.Equal(new[] { 4, 3, 2, 1 }, query);
    }

    [Fact]
    public void Hard_07_MostRecentThreeFirst()
    {
        // Task: the last three numbers, most recent (last) first: 10, 3, 7.
        IEnumerable<int> result = Data.Numbers.TakeLast(3).Reverse(); //!

        Assert.Equal(new[] { 10, 3, 7 }, result);
    }
}
