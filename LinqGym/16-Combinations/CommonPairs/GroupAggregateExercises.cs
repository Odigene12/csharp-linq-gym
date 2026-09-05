namespace LinqGym.Combinations;

/// <summary>
/// Part 2: grouping and aggregating - the LINQ equivalent of SQL's GROUP BY / HAVING / aggregate functions.
/// </summary>
public class GroupAggregateExercises : LinqExercise
{
    [Fact]
    public void Pair_01_GroupByCountPerKey()
    {
        // Task: (CourseId, number of enrollments) for every course that has enrollments.
        IEnumerable<(int CourseId, int Count)> result = TODO;

        Assert.Equal(7, result.Count());
        Assert.Equal((1, 8), result.First());
    }

    [Fact]
    public void Pair_02_GroupByOrderByCountFirst()
    {
        // Task: the most common City among students (group, order groups by size, take the first key).
        string result = TODO;

        Assert.Equal("Nashville", result);
    }

    [Fact]
    public void Pair_03_GroupByAverageHaving()
    {
        // Task: the CourseIds whose average Grade (graded enrollments only) is at least 85 - GroupBy + Where(group) like SQL HAVING.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 2, 8 }, result);
    }

    [Fact]
    public void Pair_04_GroupByToDictionary()
    {
        // Task: City -> oldest Age in that city, as a dictionary.
        Dictionary<string, int> result = TODO;

        Assert.Equal(67, result["Nashville"]);
        Assert.Equal(77, result["Chattanooga"]);
    }

    [Fact]
    public void Pair_05_SelectSumVersusSumSelector()
    {
        // Task: total course Credits, as Select(...).Sum() and as Sum(selector).
        int viaSelect = TODO;
        int viaSelector = TODO;

        Assert.Equal(29, viaSelect);
        Assert.Equal(29, viaSelector);
    }

    [Fact]
    public void Pair_06_SelectMaxVersusMaxSelector()
    {
        // Task: the longest word length, both ways.
        int viaSelect = TODO;
        int viaSelector = TODO;

        Assert.Equal(10, viaSelect);
        Assert.Equal(10, viaSelector);
    }

    [Fact]
    public void Pair_07_GroupByThenSelectManyToRegroup()
    {
        // Task: the students re-ordered so that everyone from the same city sits together (group by City, then flatten).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 2, 4, 8, 10, 12, 14, 17, 19 }, result.Take(9));
        Assert.Equal(20, result.Count());
    }

    [Fact]
    public void Pair_08_CountByIsGroupByCount()
    {
        // Task: students per city, once with CountBy and once with GroupBy + Select. Same (Key, Value) pairs.
        IEnumerable<KeyValuePair<string, int>> viaCountBy = TODO;
        IEnumerable<KeyValuePair<string, int>> viaGroupBy = TODO;

        Assert.Equal(viaGroupBy, viaCountBy);
    }
}
