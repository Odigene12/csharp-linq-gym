namespace LinqGym.Conversion;

/// <summary>
/// Cast&lt;T&gt; - treat every element AS a T. Throws InvalidCastException (lazily, on enumeration) if one is not.
/// Compare with OfType&lt;T&gt;, which silently skips non-matching elements. Mostly used on non-generic IEnumerable.
/// </summary>
public class CastExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_CastALegacyArrayList()
    {
        // Task: the non-generic ArrayList as an IEnumerable<int>.
        var legacy = new System.Collections.ArrayList { 1, 2, 3 };

        IEnumerable<int> result = legacy.Cast<int>(); //!

        Assert.Equal(new[] { 1, 2, 3 }, result);
    }

    [Fact]
    public void Easy_02_CastToObject()
    {
        // Task: Data.Numbers as IEnumerable<object> (each int gets boxed).
        IEnumerable<object> result = Data.Numbers.Cast<object>(); //!

        Assert.Equal(10, result.Count());
        Assert.Equal(5, result.First());
    }

    [Fact]
    public void Easy_03_CastObjectsToStrings()
    {
        // Task: an object[] that happens to hold strings, as IEnumerable<string>.
        object[] boxed = { "a", "b" };

        IEnumerable<string> result = boxed.Cast<string>(); //!

        Assert.Equal(new[] { "a", "b" }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_MixedTypesThrowOnEnumeration()
    {
        // Task: Cast<int> over Data.MixedBag; building the query is fine, ToList throws at the first string.
        Assert.Throws<InvalidCastException>(() =>
        {
            List<int> result = Data.MixedBag.Cast<int>().ToList(); //!
        });
    }

    [Fact]
    public void Medium_05_CastDoesNotConvertBetweenNumericTypes()
    {
        // Task: a boxed long is NOT an int, so Cast<int> throws; Select with an explicit (int) conversion works.
        var longs = new List<long> { 1L, 2L };

#pragma warning disable CA2021 // the invalid cast is the point of this exercise
        Assert.Throws<InvalidCastException>(() =>
        {
            List<int> cast = longs.Cast<int>().ToList(); //!
        });
#pragma warning restore CA2021

        IEnumerable<int> converted = longs.Select(l => (int)l); //!

        Assert.Equal(new[] { 1, 2 }, converted);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_UpcastingIsUsuallyUnnecessary()
    {
        // Task: Data.Students as IEnumerable<Person>. (IEnumerable<T> is covariant, so a plain assignment would also work -
        // Cast just makes the intent explicit.)
        IEnumerable<Person> result = Data.Students.Cast<Person>(); //!

        Assert.Equal(20, result.Count());
        Assert.Equal("Anne", result.First().FirstName);
    }

    [Fact]
    public void Hard_07_FromNonGenericIEnumerableToLinq()
    {
        // Task: `untyped` only exposes the non-generic IEnumerable, which has no Where. Cast first, then filter (> 8).
        System.Collections.IEnumerable untyped = Data.Numbers;

        IEnumerable<int> result = untyped.Cast<int>().Where(n => n > 8); //!

        Assert.Equal(new[] { 9, 10 }, result);
    }
}
