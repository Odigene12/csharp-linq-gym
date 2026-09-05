namespace LinqGym.Generation;

/// <summary>
/// Enumerable.Range(start, count) - a sequence of `count` consecutive integers starting at `start`.
/// A static method on Enumerable, not an extension method.
/// </summary>
public class RangeExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_OneToFive()
    {
        // Task: the integers 1 through 5.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, result);
    }

    [Fact]
    public void Easy_02_ZeroCountIsEmpty()
    {
        // Task: Range with a count of 0.
        IEnumerable<int> result = TODO;

        LinqAssert.IsEmpty(result);
    }

    [Fact]
    public void Easy_03_StartAtTen()
    {
        // Task: three integers starting at 10.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 10, 11, 12 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_SquaresOfOneToFive()
    {
        // Task: the squares 1, 4, 9, 16, 25 (Range + Select).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 4, 9, 16, 25 }, result);
    }

    [Fact]
    public void Medium_05_NegativeStart()
    {
        // Task: -3 through 3.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { -3, -2, -1, 0, 1, 2, 3 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_NegativeCountThrows()
    {
        // Task: a negative count throws ArgumentOutOfRangeException (immediately).
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            IEnumerable<int> result = TODO;
        });
    }

    [Fact]
    public void Hard_07_FizzBuzz()
    {
        // Task: FizzBuzz for 1..15: multiples of 15 -> "FizzBuzz", of 3 -> "Fizz", of 5 -> "Buzz", otherwise the number as text.
        IEnumerable<string> result = TODO;

        Assert.Equal(15, result.Count());
        Assert.Equal("Fizz", result.ElementAt(2));
        Assert.Equal("Buzz", result.ElementAt(4));
        Assert.Equal("FizzBuzz", result.Last());
        Assert.Equal("7", result.ElementAt(6));
    }
}
