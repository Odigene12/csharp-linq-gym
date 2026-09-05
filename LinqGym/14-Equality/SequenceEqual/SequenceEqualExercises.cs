namespace LinqGym.Equality;

/// <summary>
/// SequenceEqual - true when two sequences have the same length and equal elements in the same order.
/// Uses the default equality comparer (reference equality for classes) unless you pass one.
/// </summary>
public class SequenceEqualExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_SameElementsSameOrder()
    {
        // Task: are [1, 2, 3] and [1, 2, 3] sequence-equal?
        bool result = TODO;

        Assert.True(result);
    }

    [Fact]
    public void Easy_02_OrderMatters()
    {
        // Task: [1, 2, 3] versus [3, 2, 1].
        bool result = TODO;

        Assert.False(result);
    }

    [Fact]
    public void Easy_03_DifferentInstancesSameContent()
    {
        // Task: Data.Numbers compared with a fresh copy (ToList) of itself.
        bool result = TODO;

        Assert.True(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_DifferentLengths()
    {
        // Task: [1, 2] versus [1, 2, 3].
        bool result = TODO;

        Assert.False(result);
    }

    [Fact]
    public void Medium_05_WithAComparer()
    {
        // Task: ["a", "B"] versus ["A", "b"] ignoring case.
        bool result = TODO;

        Assert.True(result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_ValueTypesVersusReferenceTypes()
    {
        // Task: two lists of equal-valued RECORDS are sequence-equal; two lists of equal-valued CLASS instances are not.
        var records1 = new[] { new StudentSummary("A", "X", 1) };
        var records2 = new[] { new StudentSummary("A", "X", 1) };
        var copy = new Student { Id = 1, FirstName = "Anne", LastName = "Appleton", Birthday = new(1978, 2, 4), Active = true, City = "Nashville", Email = null, CohortId = 1 };

        bool recordsEqual = TODO;
        bool classesEqual = TODO;

        Assert.True(recordsEqual);
        Assert.False(classesEqual);
    }

    [Fact]
    public void Hard_07_IsItSorted()
    {
        // Task: "is Data.Numbers already sorted?" = does it SequenceEqual its own sorted version? (No.)
        bool result = TODO;

        Assert.False(result);
    }
}
