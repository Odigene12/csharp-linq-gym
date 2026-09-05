namespace LinqGym.Utilities;

/// <summary>
/// Shuffle (.NET 10+) - the elements in a random order. Deferred; every enumeration reshuffles. The source is untouched.
/// Because the order is random, these tests check properties (same items, same count) rather than exact positions.
/// </summary>
public class ShuffleExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_SameItemsInSomeOrder()
    {
        // Task: Data.Numbers shuffled.
        IEnumerable<int> result = TODO;

        LinqAssert.SameItems(Data.Numbers, result);
    }

    [Fact]
    public void Easy_02_CountIsUnchanged()
    {
        // Task: shuffled students still number 20.
        int result = TODO;

        Assert.Equal(20, result);
    }

    [Fact]
    public void Easy_03_RandomSampleOfThree()
    {
        // Task: three random numbers from Data.Numbers (Shuffle then Take).
        List<int> result = TODO;

        Assert.Equal(3, result.Count);
        Assert.All(result, n => Assert.Contains(n, Data.Numbers));
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_SortingAShuffleRestoresOrder()
    {
        // Task: shuffle, then Order - equal to the plain sorted list.
        IEnumerable<int> result = TODO;

        Assert.Equal(Data.Numbers.Order(), result);
    }

    [Fact]
    public void Medium_05_TwoRandomDistinctStudents()
    {
        // Task: two random students; they must be different people.
        List<Student> result = TODO;

        Assert.Equal(2, result.Count);
        Assert.NotSame(result[0], result[1]);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_GroupingIsUnaffectedByOrder()
    {
        // Task: the number of distinct values is the same whether or not you shuffle first.
        int result = TODO;

        Assert.Equal(8, result);
    }

    [Fact]
    public void Hard_07_SourceIsNotModified()
    {
        // Task: shuffle and materialize; Data.Numbers itself must still be in its original order.
        List<int> shuffled = TODO;

        Assert.Equal(10, shuffled.Count);
        Assert.Equal(new[] { 5, 3, 8, 1, 9, 2, 8, 7, 3, 10 }, Data.Numbers);
    }
}
