namespace LinqGym.Projection;

/// <summary>
/// SelectMany - project each element to a sequence and flatten all those sequences into one.
/// </summary>
public class SelectManyExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_FlattenTheMatrix()
    {
        // Task: all values of Data.Matrix as one flat sequence.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, result);
    }

    [Fact]
    public void Easy_02_AllStudentsFromAllCohorts()
    {
        // Task: every student of every cohort, in cohort order.
        IEnumerable<Student> result = TODO;

        Assert.Equal(Enumerable.Range(1, 20), result.Select(s => s.Id));
    }

    [Fact]
    public void Easy_03_AllJuniorInstructorsWithDuplicates()
    {
        // Task: every junior instructor of every cohort. SelectMany does NOT remove duplicates.
        IEnumerable<Instructor> result = TODO;

        Assert.Equal(new[] { 1, 3, 5, 4, 4, 6, 1, 5, 3 }, result.Select(i => i.Id));
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_FlattenStringsIntoCharacters()
    {
        // Task: every character of every word (a string is an IEnumerable<char>).
        IEnumerable<char> result = TODO;

        Assert.Equal(55, result.Count());
        Assert.Equal("apple", new string(result.Take(5).ToArray()));
    }

    [Fact]
    public void Medium_05_ResultSelectorPairsParentWithChild()
    {
        // Task: use the SelectMany overload with a result selector to produce (CohortName, StudentFirstName) pairs.
        IEnumerable<(string Cohort, string Student)> result = TODO;

        Assert.Equal(20, result.Count());
        Assert.Equal(("Evening Five", "Anne"), result.First());
        Assert.Equal(("Cohort of the Future", "Francis"), result.ElementAt(5));
    }

    [Fact]
    public void Medium_06_PrimaryPlusJuniorsPerCohort()
    {
        // Task: for every cohort, its PrimaryInstructor followed by its JuniorInstructors, all flattened.
        // Hint: Prepend or Concat inside the collection selector.
        IEnumerable<Instructor> result = TODO;

        Assert.Equal(new[] { 2, 1, 3, 6, 5, 4, 3, 4, 6, 1, 1, 5, 3 }, result.Select(i => i.Id));
    }

    [Fact]
    public void Medium_07_SelectManyWithIndex()
    {
        // Task: multiply every value in a row by that row's index (row 0 -> x0, row 1 -> x1, row 2 -> x2), flattened.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 0, 0, 0, 4, 5, 12, 14, 16, 18 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_CartesianProduct()
    {
        // Task: every combination of a number and a letter as "1a", "1b", "2a", "2b" (numbers outer, letters inner).
        var numbers = new[] { 1, 2 };
        var letters = new[] { 'a', 'b' };

        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "1a", "1b", "2a", "2b" }, result);
    }

    [Fact]
    public void Hard_09_SplitSentencesIntoWords()
    {
        // Task: all words from all sentences (split on a single space).
        var sentences = new[] { "the quick brown", "fox jumps" };

        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "the", "quick", "brown", "fox", "jumps" }, result);
    }

    [Fact]
    public void Hard_10_FlattenThenFilter()
    {
        // Task: (CohortName, StudentFirstName) for every INACTIVE student, walking through Data.Cohorts.
        IEnumerable<(string Cohort, string Student)> result = TODO;

        Assert.Equal(new[]
        {
            ("Evening Five", "Bobbie"), ("Evening Ninja Warriors", "Kate"), ("Evening Ninja Warriors", "Louis"), ("Day Backgammon Geeks", "Quincy"),
        }, result);
    }
}
