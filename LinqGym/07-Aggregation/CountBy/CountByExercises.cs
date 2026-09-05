namespace LinqGym.Aggregation;

/// <summary>
/// CountBy (.NET 9+) - count elements per key in one pass. Yields KeyValuePair&lt;TKey, int&gt; in first-appearance order.
/// Replaces GroupBy(key).Select(g => (g.Key, g.Count())) without building groups.
/// </summary>
public class CountByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_StudentsPerCity()
    {
        // Task: how many students live in each city.
        IEnumerable<KeyValuePair<string, int>> result = TODO;

        Assert.Equal(new[]
        {
            KeyValuePair.Create("Nashville", 9), KeyValuePair.Create("Memphis", 4), KeyValuePair.Create("Knoxville", 4), KeyValuePair.Create("Chattanooga", 3),
        }, result);
    }

    [Fact]
    public void Easy_02_OccurrencesOfEachNumber()
    {
        // Task: how many times each value appears in Data.Numbers.
        IEnumerable<KeyValuePair<int, int>> result = TODO;

        Assert.Equal(2, result.Single(kv => kv.Key == 8).Value);
        Assert.Equal(8, result.Count());
    }

    [Fact]
    public void Easy_03_WordsPerLength()
    {
        // Task: how many words have each Length.
        IEnumerable<KeyValuePair<int, int>> result = TODO;

        Assert.Equal(new[] { KeyValuePair.Create(5, 4), KeyValuePair.Create(6, 3), KeyValuePair.Create(4, 1), KeyValuePair.Create(10, 1), KeyValuePair.Create(3, 1) }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_CountByWithAComparer()
    {
        // Task: count words ignoring case. The key that is reported is the first spelling seen ("apple", "Banana").
        IEnumerable<KeyValuePair<string, int>> result = TODO;

        Assert.Equal(3, result.Single(kv => kv.Key == "apple").Value);
        Assert.Equal(2, result.Single(kv => kv.Key == "Banana").Value);
        Assert.Equal(7, result.Count());
    }

    [Fact]
    public void Medium_05_ActiveVersusInactive()
    {
        // Task: how many students are active vs inactive (key = Active).
        IEnumerable<KeyValuePair<bool, int>> result = TODO;

        Assert.Equal(new[] { KeyValuePair.Create(true, 16), KeyValuePair.Create(false, 4) }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_MostPopularCourse()
    {
        // Task: the (CourseId, count) pair with the most enrollments.
        KeyValuePair<int, int> result = TODO;

        Assert.Equal(KeyValuePair.Create(1, 8), result);
    }

    [Fact]
    public void Hard_07_StudentsPerBirthDecade()
    {
        // Task: count students per birth decade (1940, 1950, ...); convert to a Dictionary for the assertions.
        Dictionary<int, int> result = TODO;

        Assert.Equal(6, result[1970]);
        Assert.Equal(8, result[1980]);
        Assert.Equal(2, result[1990]);
        Assert.Equal(1, result[1940]);
        Assert.Equal(6, result.Count);
    }
}
