namespace LinqGym.Concatenation;

/// <summary>
/// Concat - one sequence followed by another. Nothing is removed or reordered (unlike Union).
/// </summary>
public class ConcatExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_AThenB()
    {
        // Task: Data.SetA followed by Data.SetB, duplicates and all.
        IEnumerable<int> result = Data.SetA.Concat(Data.SetB); //!

        Assert.Equal(new[] { 1, 2, 3, 4, 5, 5, 4, 5, 6, 7, 7 }, result);
    }

    [Fact]
    public void Easy_02_TwoCohortsOfStudents()
    {
        // Task: the students of cohort 1 followed by those of cohort 2 (Ids).
        IEnumerable<int> result = Data.Cohort(1).Students.Concat(Data.Cohort(2).Students).Select(s => s.Id); //!

        Assert.Equal(Enumerable.Range(1, 10), result);
    }

    [Fact]
    public void Easy_03_AddAWordAtTheEnd()
    {
        // Task: Data.Words followed by a one-element array containing "kiwi".
        IEnumerable<string> result = Data.Words.Concat(new[] { "kiwi" }); //!

        Assert.Equal(11, result.Count());
        Assert.Equal("kiwi", result.Last());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ConcatVersusUnion()
    {
        // Task: write both. Concat keeps everything (11), Union keeps distinct values only (7).
        int concat = Data.SetA.Concat(Data.SetB).Count(); //!
        int union = Data.SetA.Union(Data.SetB).Count(); //!

        Assert.Equal(11, concat);
        Assert.Equal(7, union);
    }

    [Fact]
    public void Medium_05_JuniorsThenPrimaryPerCohort()
    {
        // Task: for every cohort, its JuniorInstructors followed by its PrimaryInstructor, flattened (13 in total).
        IEnumerable<Instructor> result = Data.Cohorts.SelectMany(c => c.JuniorInstructors.Concat(new[] { c.PrimaryInstructor })); //!

        Assert.Equal(13, result.Count());
        Assert.Equal(2, result.ElementAt(2).Id);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_ConcatIsDeferred()
    {
        // Task: build first.Concat(second); elements added to either list afterwards must be included.
        var first = new List<int> { 1 };
        var second = new List<int> { 3 };

        IEnumerable<int> query = first.Concat(second); //!

        first.Add(2);
        second.Add(4);
        Assert.Equal(new[] { 1, 2, 3, 4 }, query);
    }

    [Fact]
    public void Hard_07_ConcatDifferentCollectionTypes()
    {
        // Task: an array, a List and an Enumerable.Range chained into one sequence: 1, 2, 3, 4.
        IEnumerable<int> result = new[] { 1 }.Concat(new List<int> { 2 }).Concat(Enumerable.Range(3, 2)); //!

        Assert.Equal(new[] { 1, 2, 3, 4 }, result);
    }
}
