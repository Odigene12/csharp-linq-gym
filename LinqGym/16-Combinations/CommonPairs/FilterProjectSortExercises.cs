namespace LinqGym.Combinations;

/// <summary>
/// Pairs of methods that almost always travel together, and the shortcuts LINQ offers for the most common ones.
/// Part 1: filtering, projecting and sorting.
/// </summary>
public class FilterProjectSortExercises : LinqExercise
{
    [Fact]
    public void Pair_01_WhereThenSelect()
    {
        // Task: the first names of the ACTIVE students who live in Nashville. Filter first, then project.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "Anne", "Derek", "Howard", "Jacob", "Nancy", "Steve" }, result);
    }

    [Fact]
    public void Pair_02_SelectThenWhere()
    {
        // Task: first names longer than 5 characters. Here you must project first, because the filter is on the projection.
        // (When the filter can run on the ORIGINAL element, put Where first - it does less work.)
        IEnumerable<string> result = TODO;

        Assert.Equal(9, result.Count());
        Assert.Equal("Bobbie", result.First());
    }

    [Fact]
    public void Pair_03_WhereFirstOrDefaultHasAShortcut()
    {
        // Task: the first student from Knoxville, written twice: Where(...).FirstOrDefault() and FirstOrDefault(predicate).
        // The predicate overload exists for First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, Any, All and Count.
        Student? viaWhere = TODO;
        Student? viaPredicate = TODO;

        Assert.Same(viaWhere, viaPredicate);
        Assert.Equal("Ethel", viaPredicate?.FirstName);
    }

    [Fact]
    public void Pair_04_WhereCountHasAShortcut()
    {
        // Task: the number of active students, both ways.
        int viaWhere = TODO;
        int viaPredicate = TODO;

        Assert.Equal(16, viaWhere);
        Assert.Equal(16, viaPredicate);
    }

    [Fact]
    public void Pair_05_WhereAnyHasAShortcut()
    {
        // Task: "is there an inactive instructor?", both ways.
        bool viaWhere = TODO;
        bool viaPredicate = TODO;

        Assert.True(viaWhere);
        Assert.True(viaPredicate);
    }

    [Fact]
    public void Pair_06_OrderByThenByThenSelect()
    {
        // Task: first names of students ordered by City then by Age (ascending).
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "Matt", "Gary", "Richard" }, result.Take(3));
    }

    [Fact]
    public void Pair_07_OrderByFirstVersusMinBy()
    {
        // Task: the oldest student, as OrderBy(Birthday).First() and as MinBy(Birthday). MinBy is a single pass and does no sorting.
        Student viaOrderBy = TODO;
        Student? viaMinBy = TODO;

        Assert.Same(viaOrderBy, viaMinBy);
        Assert.Equal("Richard", viaMinBy?.FirstName);
    }

    [Fact]
    public void Pair_08_SelectDistinctVersusDistinctBy()
    {
        // Task: the distinct cities, as Select(City).Distinct() and as DistinctBy(City).Select(City). Same result;
        // DistinctBy is the one to use when you need the whole element back, not just the key.
        IEnumerable<string> viaSelectDistinct = TODO;
        IEnumerable<string> viaDistinctBy = TODO;

        Assert.Equal(viaSelectDistinct, viaDistinctBy);
        Assert.Equal(4, viaDistinctBy.Count());
    }
}
