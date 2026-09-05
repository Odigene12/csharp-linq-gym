namespace LinqGym.Conversion;

/// <summary>
/// ToHashSet - materialize into a HashSet&lt;T&gt;: distinct values with O(1) Contains. Great for membership tests inside Where.
/// </summary>
public class ToHashSetExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_DistinctNumbersAsASet()
    {
        // Task: Data.Numbers as a HashSet<int>.
        HashSet<int> result = Data.Numbers.ToHashSet(); //!

        Assert.Equal(8, result.Count);
        Assert.Contains(8, result);
    }

    [Fact]
    public void Easy_02_SetOfCities()
    {
        // Task: the set of cities students live in.
        HashSet<string> result = Data.Students.Select(s => s.City).ToHashSet(); //!

        Assert.Equal(4, result.Count);
    }

    [Fact]
    public void Easy_03_CaseInsensitiveSet()
    {
        // Task: Data.Words as a case-insensitive set (StringComparer.OrdinalIgnoreCase).
        HashSet<string> result = Data.Words.ToHashSet(StringComparer.OrdinalIgnoreCase); //!

        Assert.Equal(7, result.Count);
        Assert.Contains("CHERRY", result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_FastMembershipInsideWhere()
    {
        // Task: build a set of enrolled StudentIds, then the students NOT in it.
        HashSet<int> enrolledIds = Data.Enrollments.Select(e => e.StudentId).ToHashSet(); //!
        IEnumerable<int> notEnrolled = Data.Students.Where(s => !enrolledIds.Contains(s.Id)).Select(s => s.Id); //!

        Assert.Equal(new[] { 2, 12, 17 }, notEnrolled);
    }

    [Fact]
    public void Medium_05_SetEquals()
    {
        // Task: Data.SetA as a HashSet; SetEquals ignores order and duplicates.
        HashSet<int> result = Data.SetA.ToHashSet(); //!

        Assert.True(result.SetEquals(new[] { 5, 4, 3, 2, 1 }));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_ToHashSetAlwaysCopies()
    {
        // Task: two ToHashSet calls give two different set objects.
        HashSet<int> first = Data.Numbers.ToHashSet(); //!
        HashSet<int> second = Data.Numbers.ToHashSet(); //!

        Assert.NotSame(first, second);
        Assert.True(first.SetEquals(second));
    }

    [Fact]
    public void Hard_07_DistinctLettersAcrossAllWords()
    {
        // Task: how many distinct letters (ignoring case) appear across all of Data.Words.
        int result = Data.Words.SelectMany(w => w.ToLowerInvariant()).ToHashSet().Count; //!

        Assert.Equal(15, result);
    }
}
