namespace LinqGym.Conversion;

/// <summary>
/// ToArray - run the query now and copy the results into a new array. Fixed size, supports index-from-end (arr[^1]).
/// </summary>
public class ToArrayExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_OddNumbersAsAnArray()
    {
        // Task: the odd numbers as an int[].
        int[] result = Data.Numbers.Where(n => n % 2 == 1).ToArray(); //!

        Assert.IsType<int[]>(result);
        Assert.Equal(new[] { 5, 3, 1, 9, 7, 3 }, result);
    }

    [Fact]
    public void Easy_02_FirstNamesArray()
    {
        // Task: all first names as a string[] (then use Length).
        string[] result = Data.Students.Select(s => s.FirstName).ToArray(); //!

        Assert.Equal(20, result.Length);
    }

    [Fact]
    public void Easy_03_EmptyArray()
    {
        // Task: numbers greater than 100 as an array - Length 0, not null.
        int[] result = Data.Numbers.Where(n => n > 100).ToArray(); //!

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ToArrayIsASnapshot()
    {
        // Task: materialize `source` as an array; adding to `source` afterwards does not change the array.
        var source = new List<int> { 1, 2, 3 };

        int[] snapshot = source.ToArray(); //!

        source.Add(4);
        Assert.Equal(3, snapshot.Length);
    }

    [Fact]
    public void Medium_05_ToArrayAlwaysCopies()
    {
        // Task: ToArray on an array returns a NEW array with equal contents.
        object?[] result = Data.MixedBag.ToArray(); //!

        Assert.NotSame(Data.MixedBag, result);
        Assert.Equal(Data.MixedBag, result);
    }

    [Fact]
    public void Medium_06_IndexFromEnd()
    {
        // Task: the last number, via ToArray and the ^1 index.
        int result = Data.Numbers.ToArray()[^1]; //!

        Assert.Equal(10, result);
    }

    [Fact]
    public void Medium_07_SortedCopyWithoutMutatingTheSource()
    {
        // Task: a sorted array of Data.Numbers; Data.Numbers itself keeps its original order.
        int[] result = Data.Numbers.Order().ToArray(); //!

        Assert.Equal(1, result[0]);
        Assert.Equal(5, Data.Numbers[0]);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_JaggedArray()
    {
        // Task: Data.Matrix with every value doubled, as an int[][].
        int[][] result = Data.Matrix.Select(row => row.Select(v => v * 2).ToArray()).ToArray(); //!

        Assert.Equal(18, result[2][3]);
        Assert.Equal(3, result.Length);
    }

    [Fact]
    public void Hard_09_PassToAnArrayApi()
    {
        // Task: materialize Data.Numbers as an array so it can be handed to Array.IndexOf (which needs an array).
        int[] arr = Data.Numbers.ToArray(); //!

        Assert.Equal(4, Array.IndexOf(arr, 9));
    }

    [Fact]
    public void Hard_10_ToArraySurfacesErrorsImmediately()
    {
        // Task: Cast<int> over Data.MixedBag throws only when materialized.
        Assert.Throws<InvalidCastException>(() =>
        {
            int[] result = Data.MixedBag.Cast<int>().ToArray(); //!
        });
    }
}
