namespace LinqGym.Filtering;

/// <summary>
/// Where - keep only the elements that satisfy a predicate.
/// Read README.md in this folder first. Replace each TODO with a LINQ expression.
/// </summary>
public class WhereExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ActiveStudents()
    {
        // Task: all students whose Active flag is true, in their original order.
        IEnumerable<Student> result = TODO;

        Assert.Equal(16, result.Count());
        Assert.All(result, s => Assert.True(s.Active));
    }

    [Fact]
    public void Easy_02_EvenNumbers()
    {
        // Task: only the even values from Data.Numbers, keeping their order.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 8, 2, 8, 10 }, result);
    }

    [Fact]
    public void Easy_03_StudentsFromNashville()
    {
        // Task: students whose City is exactly "Nashville".
        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { 1, 2, 4, 8, 10, 12, 14, 17, 19 }, result.Select(s => s.Id));
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ActiveStudentsFromMemphis()
    {
        // Task: students who are Active AND live in Memphis. Use a single Where with && (not two Where calls).
        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { "Carrie", "Francis", "Paul" }, result.Select(s => s.FirstName));
    }

    [Fact]
    public void Medium_05_BornInThe1980s()
    {
        // Task: students born from 1980-01-01 up to and including 1989-12-31.
        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { 2, 4, 6, 10, 11, 15, 16, 20 }, result.Select(s => s.Id));
    }

    [Fact]
    public void Medium_06_StudentsWithoutEmail()
    {
        // Task: students whose Email is null. Nulls are ordinary values to Where - no special handling needed.
        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { "Bobbie", "Gary", "Louis", "Quincy" }, result.Select(s => s.FirstName));
    }

    [Fact]
    public void Medium_07_WordsStartingWithLowercaseVowel()
    {
        // Task: words that start with a lowercase vowel (a, e, i, o, u). Case matters: "APPLE" must NOT be included.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "apple", "apple" }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_EveryOtherNumberUsingIndex()
    {
        // Task: Where has an overload whose predicate receives the element AND its zero-based index.
        // Return the elements at even positions (index 0, 2, 4, ...).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 5, 8, 9, 8, 3 }, result);
    }

    [Fact]
    public void Hard_09_CohortsWhereAllInstructorsAreActive()
    {
        // Task: cohorts where the PrimaryInstructor is active AND every JuniorInstructor is active.
        // Hint: a Where predicate can itself contain a LINQ call (All).
        IEnumerable<Cohort> result = TODO;

        Assert.Equal(new[] { "Evening Five", "Day Backgammon Geeks" }, result.Select(c => c.Name));
    }

    [Fact]
    public void Hard_10_WhereIsDeferred()
    {
        // Task: build a query over `numbers` that keeps values greater than 2. Do NOT call ToList/ToArray.
        // A Where query is not executed when it is created; it runs when it is enumerated.
        // The Assert below adds an element AFTER the query is built and expects the query to see it.
        var numbers = new List<int> { 1, 2, 3 };

        IEnumerable<int> query = TODO;

        numbers.Add(10);
        Assert.Equal(new[] { 3, 10 }, query);
    }
}
