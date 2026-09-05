namespace LinqGym.Sorting;

/// <summary>
/// OrderDescending (.NET 7+) - sort comparable values descending by the values themselves.
/// </summary>
public class OrderDescendingExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_NumbersDescending()
    {
        // Task: Data.Numbers descending, without a key selector.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 10, 9, 8, 8, 7, 5, 3, 3, 2, 1 }, result);
    }

    [Fact]
    public void Easy_02_WordsOrdinalDescending()
    {
        // Task: Data.Words descending using StringComparer.Ordinal.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "grape", "fig", "date", "cherry", "banana", "apple", "apple", "Elderberry", "Banana", "APPLE" }, result);
    }

    [Fact]
    public void Easy_03_TemperaturesHottestFirst()
    {
        // Task: Data.Temperatures descending.
        IEnumerable<double> result = TODO;

        Assert.Equal(new[] { 80.1, 78.3, 75.2, 72.5, 71.9, 68.0, 66.4 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_TopThreePrices()
    {
        // Task: the three highest prices, highest first.
        IEnumerable<decimal> result = TODO;

        Assert.Equal(new[] { 120.00m, 42.50m, 19.99m }, result);
    }

    [Fact]
    public void Medium_05_CaseInsensitiveDescending()
    {
        // Task: Data.Words descending, ignoring case (ties keep original order).
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "grape", "fig", "Elderberry", "date", "cherry", "Banana", "banana", "apple", "apple", "APPLE" }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_BirthdaysLatestFirst()
    {
        // Task: all student birthdays, latest first.
        IEnumerable<DateOnly> result = TODO;

        Assert.Equal(new DateOnly(1996, 2, 4), result.First());
        Assert.Equal(new DateOnly(1948, 10, 31), result.Last());
    }

    [Fact]
    public void Hard_07_ThirdLargestDistinctNumber()
    {
        // Task: the third-largest DISTINCT value in Data.Numbers (10, 9, then 8).
        int result = TODO;

        Assert.Equal(8, result);
    }
}
