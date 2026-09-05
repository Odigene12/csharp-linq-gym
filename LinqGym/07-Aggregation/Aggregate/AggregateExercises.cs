namespace LinqGym.Aggregation;

/// <summary>
/// Aggregate - the general-purpose "fold": run an accumulator function over every element and return the final accumulator.
/// Sum, Min, Max, Count... could all be written with Aggregate. Three overloads: (func), (seed, func), (seed, func, resultSelector).
/// </summary>
public class AggregateExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ProductOfAllNumbers()
    {
        // Task: multiply every number together (no seed needed - the first element is the starting accumulator).
        int result = Data.Numbers.Aggregate((acc, n) => acc * n); //!

        Assert.Equal(3_628_800, result);
    }

    [Fact]
    public void Easy_02_JoinWordsWithCommas()
    {
        // Task: "apple,Banana,cherry,..." built with Aggregate (string.Join would be the real-world choice).
        string result = Data.Words.Aggregate((acc, w) => acc + "," + w); //!

        Assert.Equal(string.Join(",", Data.Words), result);
    }

    [Fact]
    public void Easy_03_SumWithASeed()
    {
        // Task: the sum of Data.Numbers using the (seed, func) overload with a seed of 0.
        int result = Data.Numbers.Aggregate(0, (acc, n) => acc + n); //!

        Assert.Equal(56, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_MaxViaAggregate()
    {
        // Task: the largest number, using Aggregate with Math.Max.
        int result = Data.Numbers.Aggregate((acc, n) => Math.Max(acc, n)); //!

        Assert.Equal(10, result);
    }

    [Fact]
    public void Medium_05_AverageViaTupleAccumulatorAndResultSelector()
    {
        // Task: accumulate a (Sum, Count) tuple, then use the third overload's result selector to divide.
        double result = Data.Numbers.Aggregate((Sum: 0, Count: 0), (acc, n) => (acc.Sum + n, acc.Count + 1), acc => (double)acc.Sum / acc.Count); //!

        Assert.Equal(5.6, result);
    }

    [Fact]
    public void Medium_06_EmptySequenceNeedsASeed()
    {
        // Task: without a seed, Aggregate over Data.Empty throws. With a seed, it returns the seed.
        Assert.Throws<InvalidOperationException>(() =>
        {
            int noSeed = Data.Empty.Aggregate((acc, n) => acc + n); //!
        });

        int withSeed = Data.Empty.Aggregate(100, (acc, n) => acc + n); //!

        Assert.Equal(100, withSeed);
    }

    [Fact]
    public void Medium_07_CountOccurrencesIntoADictionary()
    {
        // Task: build a Dictionary<string, int> of word -> occurrences, using a new Dictionary as the seed.
        Dictionary<string, int> result = Data.Words.Aggregate(new Dictionary<string, int>(), (acc, w) => { acc[w] = acc.GetValueOrDefault(w) + 1; return acc; }); //!

        Assert.Equal(2, result["apple"]);
        Assert.Equal(1, result["APPLE"]);
        Assert.Equal(9, result.Count);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_ReverseAStringWithAggregate()
    {
        // Task: reverse "linq" by prepending each character to the accumulator (seed: empty string).
        string result = "linq".Aggregate("", (acc, c) => c + acc); //!

        Assert.Equal("qnil", result);
    }

    [Fact]
    public void Hard_09_RunningTotals()
    {
        // Task: the running (cumulative) totals of Data.Numbers as a List<int>: 5, 8, 16, 17, ...
        List<int> result = Data.Numbers.Aggregate(new List<int>(), (acc, n) => { acc.Add((acc.Count == 0 ? 0 : acc[^1]) + n); return acc; }); //!

        Assert.Equal(new[] { 5, 8, 16, 17, 26, 28, 36, 43, 46, 56 }, result);
    }

    [Fact]
    public void Hard_10_RowSumsJoinedWithPipes()
    {
        // Task: "6|9|30" - the sum of each row in Data.Matrix, joined with '|', built in a single Aggregate.
        string result = Data.Matrix.Aggregate("", (acc, row) => acc.Length == 0 ? row.Sum().ToString() : acc + "|" + row.Sum()); //!

        Assert.Equal("6|9|30", result);
    }
}
