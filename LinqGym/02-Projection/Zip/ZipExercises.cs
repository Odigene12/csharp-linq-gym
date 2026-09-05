namespace LinqGym.Projection;

/// <summary>
/// Zip - walk two (or three) sequences side by side and combine element i of each.
/// Stops as soon as the shortest sequence runs out.
/// </summary>
public class ZipExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ZipIntoTuples()
    {
        // Task: pair each number with the word at the same position. The no-selector overload returns (First, Second) tuples.
        IEnumerable<(int First, string Second)> result = TODO;

        Assert.Equal(10, result.Count());
        Assert.Equal((5, "apple"), result.First());
        Assert.Equal((10, "grape"), result.Last());
    }

    [Fact]
    public void Easy_02_ZipWithResultSelector()
    {
        // Task: element-wise sums of the two arrays.
        var a = new[] { 1, 2, 3 };
        var b = new[] { 10, 20, 30 };

        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 11, 22, 33 }, result);
    }

    [Fact]
    public void Easy_03_StopsAtTheShorterSequence()
    {
        // Task: zip five numbers with two letters. Extra elements of the longer sequence are ignored.
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var letters = new[] { "a", "b" };

        IEnumerable<(int, string)> result = TODO;

        Assert.Equal(2, result.Count());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ZipThreeSequences()
    {
        // Task: the three-sequence overload yields (First, Second, Third) tuples.
        var ids = new[] { 1, 2 };
        var names = new[] { "a", "b" };
        var flags = new[] { true, false };

        IEnumerable<(int, string, bool)> result = TODO;

        Assert.Equal(new[] { (1, "a", true), (2, "b", false) }, result);
    }

    [Fact]
    public void Medium_05_NumberEachWord()
    {
        // Task: "1. apple", "2. Banana", ... by zipping Data.Words with Enumerable.Range(1, 100).
        IEnumerable<string> result = TODO;

        Assert.Equal(10, result.Count());
        Assert.Equal("1. apple", result.First());
        Assert.Equal("10. grape", result.Last());
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_PairwiseDifferences()
    {
        // Task: the difference between each number and the one before it (next - previous).
        // Hint: zip the sequence with itself shifted by one (Skip(1)).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { -2, 5, -7, 8, -7, 6, -1, -4, 7 }, result);
    }

    [Fact]
    public void Hard_07_DotProduct()
    {
        // Task: the dot product of two vectors: sum of the element-wise products (1*4 + 2*5 + 3*6 = 32).
        var v1 = new[] { 1, 2, 3 };
        var v2 = new[] { 4, 5, 6 };

        int result = TODO;

        Assert.Equal(32, result);
    }
}
