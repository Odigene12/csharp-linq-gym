namespace LinqGym.SetOperations;

/// <summary>
/// Union - all distinct elements from both sequences (first sequence's order, then new ones from the second).
/// Duplicates within EITHER sequence are removed too.
/// </summary>
public class UnionExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_UnionOfTwoSets()
    {
        // Task: Data.SetA union Data.SetB.
        IEnumerable<int> result = Data.SetA.Union(Data.SetB); //!

        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7 }, result);
    }

    [Fact]
    public void Easy_02_UnionRemovesDuplicatesWithinASequence()
    {
        // Task: Data.SetA union Data.Empty - the duplicate 5 inside SetA disappears.
        IEnumerable<int> result = Data.SetA.Union(Data.Empty); //!

        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, result);
    }

    [Fact]
    public void Easy_03_UnionWithNewWords()
    {
        // Task: Data.Words union ["kiwi", "apple"] - 9 distinct words plus kiwi.
        IEnumerable<string> result = Data.Words.Union(new[] { "kiwi", "apple" }); //!

        Assert.Equal(10, result.Count());
        Assert.Equal("kiwi", result.Last());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_UnionIgnoringCase()
    {
        // Task: Data.TagsA union Data.TagsB, ignoring case.
        IEnumerable<string> result = Data.TagsA.Union(Data.TagsB, StringComparer.OrdinalIgnoreCase); //!

        Assert.Equal(new[] { "csharp", "LINQ", "dotnet", "azure" }, result);
    }

    [Fact]
    public void Medium_05_UnionOfJuniorInstructors()
    {
        // Task: the junior instructors of cohort 1 union those of cohort 3 (Ids).
        IEnumerable<int> result = Data.Cohort(1).JuniorInstructors.Union(Data.Cohort(3).JuniorInstructors).Select(i => i.Id); //!

        Assert.Equal(new[] { 1, 3, 4, 6 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_AllInstructorsInvolvedWithAnyCohort()
    {
        // Task: every distinct instructor who is a junior OR a primary instructor of some cohort, juniors first.
        IEnumerable<int> result = Data.Cohorts.SelectMany(c => c.JuniorInstructors).Union(Data.Cohorts.Select(c => c.PrimaryInstructor)).Select(i => i.Id); //!

        Assert.Equal(new[] { 1, 3, 5, 4, 6, 2 }, result);
    }

    [Fact]
    public void Hard_07_UnionEqualsConcatPlusDistinct()
    {
        // Task: write SetA union SetB, and the same thing as Concat followed by Distinct. They must match.
        IEnumerable<int> union = Data.SetA.Union(Data.SetB); //!
        IEnumerable<int> concatDistinct = Data.SetA.Concat(Data.SetB).Distinct(); //!

        Assert.Equal(union, concatDistinct);
    }
}
