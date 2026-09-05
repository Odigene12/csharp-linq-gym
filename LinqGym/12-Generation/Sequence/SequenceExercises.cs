namespace LinqGym.Generation;

/// <summary>
/// Enumerable.Sequence(start, endInclusive, step) (.NET 10+) - an arithmetic progression of any numeric type
/// (int, long, double, decimal, char...). Unlike Range it takes an END value and a STEP, and works for non-int types.
/// </summary>
public class SequenceExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_OneToTen()
    {
        // Task: 1 through 10 with a step of 1.
        IEnumerable<int> result = Enumerable.Sequence(1, 10, 1); //!

        Assert.Equal(Enumerable.Range(1, 10), result);
    }

    [Fact]
    public void Easy_02_MultiplesOfFive()
    {
        // Task: 0, 5, 10, 15, 20.
        IEnumerable<int> result = Enumerable.Sequence(0, 20, 5); //!

        Assert.Equal(new[] { 0, 5, 10, 15, 20 }, result);
    }

    [Fact]
    public void Easy_03_CountingDown()
    {
        // Task: 10, 7, 4, 1 (negative step).
        IEnumerable<int> result = Enumerable.Sequence(10, 1, -3); //!

        Assert.Equal(new[] { 10, 7, 4, 1 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_DoublesInQuarterSteps()
    {
        // Task: 0.0, 0.25, 0.5, 0.75, 1.0.
        IEnumerable<double> result = Enumerable.Sequence(0.0, 1.0, 0.25); //!

        Assert.Equal(new[] { 0.0, 0.25, 0.5, 0.75, 1.0 }, result);
    }

    [Fact]
    public void Medium_05_EndIsInclusiveButNotAlwaysHit()
    {
        // Task: from 1 to 10 in steps of 4 - the sequence stops at 9 because 13 would exceed the end.
        IEnumerable<int> result = Enumerable.Sequence(1, 10, 4); //!

        Assert.Equal(new[] { 1, 5, 9 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_InvalidStepThrows()
    {
        // Task: a positive step with start > end throws ArgumentOutOfRangeException (as does a step of 0).
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            IEnumerable<int> result = Enumerable.Sequence(10, 1, 1); //!
        });
    }

    [Fact]
    public void Hard_07_LettersAToE()
    {
        // Task: the characters a, b, c, d, e - char is a numeric type as far as Sequence is concerned (step (char)1).
        IEnumerable<char> result = Enumerable.Sequence('a', 'e', (char)1); //!

        Assert.Equal("abcde", new string(result.ToArray()));
    }
}
