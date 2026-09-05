namespace LinqGym.SetOperations;

/// <summary>
/// Distinct - remove duplicates, keeping the FIRST occurrence of each value in original order.
/// Uses the default equality comparer (reference equality for classes!) unless you pass one.
/// </summary>
public class DistinctExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_DistinctNumbers()
    {
        // Task: Data.Numbers without duplicates.
        IEnumerable<int> result = Data.Numbers.Distinct(); //!

        Assert.Equal(new[] { 5, 3, 8, 1, 9, 2, 7, 10 }, result);
    }

    [Fact]
    public void Easy_02_DistinctWordsAreCaseSensitive()
    {
        // Task: Data.Words without exact duplicates ("apple" twice -> once; "APPLE" is different).
        IEnumerable<string> result = Data.Words.Distinct(); //!

        Assert.Equal(9, result.Count());
    }

    [Fact]
    public void Easy_03_DistinctCities()
    {
        // Task: the distinct cities students live in, in first-seen order.
        IEnumerable<string> result = Data.Students.Select(s => s.City).Distinct(); //!

        Assert.Equal(new[] { "Nashville", "Memphis", "Knoxville", "Chattanooga" }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_DistinctIgnoringCase()
    {
        // Task: Data.Words distinct with StringComparer.OrdinalIgnoreCase (first spelling wins).
        IEnumerable<string> result = Data.Words.Distinct(StringComparer.OrdinalIgnoreCase); //!

        Assert.Equal(new[] { "apple", "Banana", "cherry", "date", "Elderberry", "fig", "grape" }, result);
    }

    [Fact]
    public void Medium_05_ReferenceEqualityForClasses()
    {
        // Task: `list` holds the SAME student object twice plus a data-identical copy. Distinct sees 2 distinct objects.
        var copy = new Student { Id = 1, FirstName = "Anne", LastName = "Appleton", Birthday = new(1978, 2, 4), Active = true, City = "Nashville", Email = null, CohortId = 1 };
        var list = new List<Student> { Data.Student(1), Data.Student(1), copy };

        IEnumerable<Student> result = list.Distinct(); //!

        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void Medium_06_DistinctJuniorInstructorsAcrossCohorts()
    {
        // Task: every distinct junior instructor Id across all cohorts, in first-seen order.
        IEnumerable<int> result = Data.Cohorts.SelectMany(c => c.JuniorInstructors).Distinct().Select(i => i.Id); //!

        Assert.Equal(new[] { 1, 3, 5, 4, 6 }, result);
    }

    [Fact]
    public void Medium_07_RecordsUseValueEquality()
    {
        // Task: two StudentSummary records with identical values count as ONE distinct element.
        var summaries = new[] { new StudentSummary("A B", "X", 1), new StudentSummary("A B", "X", 1), new StudentSummary("C D", "Y", 2) };

        IEnumerable<StudentSummary> result = summaries.Distinct(); //!

        Assert.Equal(2, result.Count());
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_DistinctWithACustomComparer()
    {
        // Task: make the data-identical copy count as a duplicate by passing PersonIdComparer.Instance.
        // The comparer is an IEqualityComparer<Person>, so give Distinct its type argument explicitly: Distinct<Student>(...).
        var copy = new Student { Id = 1, FirstName = "Anne", LastName = "Appleton", Birthday = new(1978, 2, 4), Active = true, City = "Nashville", Email = null, CohortId = 1 };
        var list = new List<Student> { Data.Student(1), copy, Data.Student(2) };

        IEnumerable<Student> result = list.Distinct<Student>(PersonIdComparer.Instance); //!

        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void Hard_09_DistinctBirthMonths()
    {
        // Task: how many distinct birth months the students cover (nobody was born in June).
        int result = Data.Students.Select(s => s.Birthday.Month).Distinct().Count(); //!

        Assert.Equal(11, result);
    }

    [Fact]
    public void Hard_10_DistinctIsDeferred()
    {
        // Task: build a Distinct query over `list`; an element added afterwards must show up.
        var list = new List<int> { 1, 1, 2 };

        IEnumerable<int> query = list.Distinct(); //!

        list.Add(3);
        Assert.Equal(new[] { 1, 2, 3 }, query);
    }
}
