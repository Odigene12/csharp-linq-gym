namespace LinqGym.Sorting;

/// <summary>
/// OrderBy - sort ascending by a key. The sort is STABLE: equal keys keep their original relative order.
/// </summary>
public class OrderByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_NumbersAscending()
    {
        // Task: Data.Numbers from smallest to largest.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 2, 3, 3, 5, 7, 8, 8, 9, 10 }, result);
    }

    [Fact]
    public void Easy_02_StudentsOldestFirst()
    {
        // Task: students ordered by Birthday (earliest birthday = oldest person first).
        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { 18, 17, 19 }, result.Take(3).Select(s => s.Id));
        Assert.Equal("Carrie", result.Last().FirstName);
    }

    [Fact]
    public void Easy_03_WordsByLengthIsStable()
    {
        // Task: words ordered by Length. Words with the same length must stay in their original order.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "fig", "date", "apple", "apple", "APPLE", "grape", "Banana", "cherry", "banana", "Elderberry" }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_OrdinalStringOrdering()
    {
        // Task: words ordered with StringComparer.Ordinal (uppercase letters sort before lowercase).
        // The default comparer is culture-sensitive and gives machine-dependent results for mixed case - avoid it.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "APPLE", "Banana", "Elderberry", "apple", "apple", "banana", "cherry", "date", "fig", "grape" }, result);
    }

    [Fact]
    public void Medium_05_CaseInsensitiveOrdering()
    {
        // Task: words ordered with StringComparer.OrdinalIgnoreCase. Equal keys ("apple"/"APPLE") keep original order.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "apple", "apple", "APPLE", "Banana", "banana", "cherry", "date", "Elderberry", "fig", "grape" }, result);
    }

    [Fact]
    public void Medium_06_OrderByComputedKey()
    {
        // Task: students ordered by Age (youngest first). Two students share age 36 - stability decides who comes first.
        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { "Carrie", "Ingrid", "Paul", "Terrence", "Bobbie" }, result.Take(5).Select(s => s.FirstName));
    }

    [Fact]
    public void Medium_07_OrderByBoolean()
    {
        // Task: cohorts ordered by FullTime. Booleans sort false before true, so part-time cohorts come first.
        IEnumerable<Cohort> result = TODO;

        Assert.Equal(new[] { "Evening Five", "Evening Ninja Warriors", "Cohort of the Future", "Day Backgammon Geeks" }, result.Select(c => c.Name));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_OddsFirstThenEvensKeepingOrder()
    {
        // Task: all odd numbers first (in original order), then all even numbers (in original order).
        // Hint: a single OrderBy with a boolean key does this - no Where/Concat needed.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 5, 3, 1, 9, 7, 3, 8, 2, 8, 10 }, result);
    }

    [Fact]
    public void Hard_09_CustomPriorityOrder()
    {
        // Task: courses ordered by the position of their Category in `priority` (Backend first, General last).
        var priority = new List<string> { "Backend", "Data", "Frontend", "Research", "General" };

        IEnumerable<Course> result = TODO;

        Assert.Equal(new[] { "CS101", "CS201", "DB101", "DB201", "JS101", "JS201", "QC999", "SE100" }, result.Select(c => c.Code));
    }

    [Fact]
    public void Hard_10_OrderByIsDeferred()
    {
        // Task: build (but do not execute) an ascending query over `list`. The element added afterwards must be sorted in.
        var list = new List<int> { 3, 1, 2 };

        IEnumerable<int> query = TODO;

        list.Add(0);
        Assert.Equal(new[] { 0, 1, 2, 3 }, query);
    }
}
