namespace LinqGym.Combinations;

/// <summary>
/// Deferred execution is THE concept that separates people who use LINQ from people who understand it.
/// A query is a recipe; it runs when something enumerates it - and it runs AGAIN every time something enumerates it.
/// Operators that return a sequence (Where, Select, OrderBy, ...) are deferred. Operators that return a single value
/// (Count, First, Sum, ToList, ToArray, ToDictionary, ...) execute immediately.
/// </summary>
public class DeferredExecutionExercises : LinqExercise
{
    [Fact]
    public void Deferred_01_QueriesRunEveryTimeTheyAreEnumerated()
    {
        // Task: a Select that counts its calls. Enumerating the query twice runs the selector 20 times.
        int calls = 0;

        IEnumerable<int> query = Data.Numbers.Select(n => { calls++; return n; }); //!

        var first = query.ToList();
        var second = query.ToList();
        Assert.Equal(20, calls);
    }

    [Fact]
    public void Deferred_02_MaterializeToRunOnce()
    {
        // Task: the same counting Select, but materialized once with ToList. Using the list twice costs nothing extra.
        int calls = 0;

        List<int> materialized = Data.Numbers.Select(n => { calls++; return n; }).ToList(); //!

        var first = materialized.ToList();
        var second = materialized.ToList();
        Assert.Equal(10, calls);
    }

    [Fact]
    public void Deferred_03_LambdasCaptureVariablesNotValues()
    {
        // Task: filter Data.Numbers to values greater than `threshold`. The test changes `threshold` AFTER building the query;
        // because the lambda captured the VARIABLE, the query uses the new value when it finally runs.
        int threshold = 5;

        IEnumerable<int> query = Data.Numbers.Where(n => n > threshold); //!

        threshold = 8;
        Assert.Equal(new[] { 9, 10 }, query);
    }

    [Fact]
    public void Deferred_04_ModifyingTheSourceWhileEnumeratingThrows()
    {
        // Task: a query over `list` (values > 0). Adding to `list` inside the foreach invalidates the enumerator.
        var list = new List<int> { 1, 2, 3 };

        IEnumerable<int> query = list.Where(n => n > 0); //!

        Assert.Throws<InvalidOperationException>(() =>
        {
            foreach (var n in query) list.Add(n * 10);
        });
    }

    [Fact]
    public void Deferred_05_ImmediateOperatorsRunRightAway()
    {
        // Task: Count() over a counting Select. By the time the next line runs, all 10 selectors have executed.
        int calls = 0;

        int count = Data.Numbers.Select(n => { calls++; return n; }).Count(); //!

        Assert.Equal(10, count);
        Assert.Equal(10, calls);
    }

    [Fact]
    public void Deferred_06_ExceptionsAreDeferredToo()
    {
        // Task: Cast<int> over Data.MixedBag. Building the query does not throw; ToList() does, because it must enumerate.
        // (Beware: Count() would NOT throw here - over an array, Cast can answer Count from the array length without looking at elements.)
        IEnumerable<int> query = Data.MixedBag.Cast<int>(); //!

        Assert.Throws<InvalidCastException>(() => query.ToList());
    }

    [Fact]
    public void Deferred_07_PipelinesAreLazyEndToEnd()
    {
        // Task: Where(n > 3) -> counting Select -> Take(2). Because every stage is lazy, the selector runs only twice
        // even though Where inspects three elements (5, 3, 8) to find two matches.
        int calls = 0;

        List<int> result = Data.Numbers.Where(n => n > 3).Select(n => { calls++; return n * 10; }).Take(2).ToList(); //!

        Assert.Equal(new[] { 50, 80 }, result);
        Assert.Equal(2, calls);
    }

    [Fact]
    public void Deferred_08_SortingMustBufferEverything()
    {
        // Task: counting Select -> OrderBy -> First(). Even though only one element is requested, sorting needs to see all
        // ten, so the selector runs ten times. (MinBy would have done the same job in one pass without sorting.)
        int calls = 0;

        int result = Data.Numbers.Select(n => { calls++; return n; }).OrderBy(n => n).First(); //!

        Assert.Equal(1, result);
        Assert.Equal(10, calls);
    }
}
