namespace LinqGym.Sorting;

/// <summary>
/// Order (.NET 7+) - sort a sequence of comparable values by the values themselves. Equivalent to OrderBy(x => x).
/// </summary>
public class OrderExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_NumbersAscending()
    {
        // Task: Data.Numbers ascending, without writing a key selector.
        IEnumerable<int> result = Data.Numbers.Order(); //!

        Assert.Equal(new[] { 1, 2, 3, 3, 5, 7, 8, 8, 9, 10 }, result);
    }

    [Fact]
    public void Easy_02_WordsOrdinal()
    {
        // Task: Data.Words ordered with StringComparer.Ordinal.
        IEnumerable<string> result = Data.Words.Order(StringComparer.Ordinal); //!

        Assert.Equal(new[] { "APPLE", "Banana", "Elderberry", "apple", "apple", "banana", "cherry", "date", "fig", "grape" }, result);
    }

    [Fact]
    public void Easy_03_CharactersOfAString()
    {
        // Task: the characters of "linq" in ascending order (a string is an IEnumerable<char>).
        IEnumerable<char> result = "linq".Order(); //!

        Assert.Equal(new[] { 'i', 'l', 'n', 'q' }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_PricesAscending()
    {
        // Task: Data.Prices ascending.
        IEnumerable<decimal> result = Data.Prices.Order(); //!

        Assert.Equal(new[] { 0.99m, 5.49m, 5.49m, 19.99m, 42.50m, 120.00m }, result);
    }

    [Fact]
    public void Medium_05_CustomComparer()
    {
        // Task: use Order with a comparer built by Comparer<int>.Create so that numbers come out DESCENDING.
        IEnumerable<int> result = Data.Numbers.Order(Comparer<int>.Create((a, b) => b.CompareTo(a))); //!

        Assert.Equal(new[] { 10, 9, 8, 8, 7, 5, 3, 3, 2, 1 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_SortedDistinctAges()
    {
        // Task: the distinct ages of all students, ascending.
        IEnumerable<int> result = Data.Students.Select(s => s.Age).Order().Distinct(); //!

        Assert.Equal(new[] { 29, 34, 36, 37, 38, 41, 42, 47, 49, 52, 53, 54, 57, 60, 67, 77 }, result);
    }

    [Fact]
    public void Hard_07_MedianOfNumbers()
    {
        // Task: the median of Data.Numbers (10 values -> average of the 5th and 6th sorted values = (5 + 7) / 2 = 6.0).
        // Hint: Order, then Skip/Take to reach the middle two.
        double result = Data.Numbers.Order().Skip(4).Take(2).Average(); //!

        Assert.Equal(6.0, result);
    }
}
