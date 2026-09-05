namespace LinqGym.Filtering;

/// <summary>
/// OfType&lt;T&gt; - keep only the elements that ARE a T (and skip nulls). Never throws.
/// </summary>
public class OfTypeExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_OnlyIntegers()
    {
        // Task: the int values inside Data.MixedBag, in order.
        IEnumerable<int> result = Data.MixedBag.OfType<int>(); //!

        Assert.Equal(new[] { 1, 3, 5 }, result);
    }

    [Fact]
    public void Easy_02_OnlyStrings()
    {
        // Task: the string values inside Data.MixedBag.
        IEnumerable<string> result = Data.MixedBag.OfType<string>(); //!

        Assert.Equal(new[] { "one", "three", "five" }, result);
    }

    [Fact]
    public void Easy_03_NullsAreDropped()
    {
        // Task: OfType<object>() keeps everything that is an object - which is everything except null.
        IEnumerable<object> result = Data.MixedBag.OfType<object>(); //!

        Assert.Equal(9, result.Count());
        Assert.DoesNotContain(null, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_TypeMustMatchExactlyForValueTypes()
    {
        // Task: the long values. Note that the ints 1, 3, 5 are NOT longs - boxed value types do not convert.
        IEnumerable<long> result = Data.MixedBag.OfType<long>(); //!

        Assert.Equal(new long[] { 4L }, result);
    }

    [Fact]
    public void Medium_05_InterfacesWork()
    {
        // Task: every element that implements IComparable (int, string, double, long and bool all do).
        IEnumerable<IComparable> result = Data.MixedBag.OfType<IComparable>(); //!

        Assert.Equal(9, result.Count());
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_FilterAHeterogeneousListOfPeople()
    {
        // Task: `people` mixes Students and Instructors (both derive from Person). Return just the Instructors.
        var people = new List<Person> { Data.Student(1), Data.Instructor(2), Data.Student(3), Data.Instructor(6) };

        IEnumerable<Instructor> result = people.OfType<Instructor>(); //!

        Assert.Equal(new[] { "Jurnell", "Zachary" }, result.Select(i => i.FirstName));
    }

    [Fact]
    public void Hard_07_SumOnlyTheNumericValues()
    {
        // Task: from Data.MixedBag, add up every int AND every long as a single long total (1 + 3 + 4 + 5 = 13).
        // Hint: two OfType calls, Concat (or Select to long), then Sum.
        long result = Data.MixedBag.OfType<int>().Select(i => (long)i).Concat(Data.MixedBag.OfType<long>()).Sum(); //!

        Assert.Equal(13L, result);
    }
}
