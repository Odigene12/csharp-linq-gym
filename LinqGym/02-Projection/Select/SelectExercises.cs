namespace LinqGym.Projection;

/// <summary>
/// Select - transform every element into something else (one in, one out).
/// </summary>
public class SelectExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_FirstNames()
    {
        // Task: the FirstName of every student, in order.
        IEnumerable<string> result = Data.Students.Select(s => s.FirstName); //!

        Assert.Equal(20, result.Count());
        Assert.Equal(new[] { "Anne", "Bobbie", "Carrie" }, result.Take(3));
    }

    [Fact]
    public void Easy_02_Squares()
    {
        // Task: the square of every number in Data.Numbers.
        IEnumerable<int> result = Data.Numbers.Select(n => n * n); //!

        Assert.Equal(new[] { 25, 9, 64, 1, 81, 4, 64, 49, 9, 100 }, result);
    }

    [Fact]
    public void Easy_03_WordLengths()
    {
        // Task: the length of every word. Select can change the element type (string -> int).
        IEnumerable<int> result = Data.Words.Select(w => w.Length); //!

        Assert.Equal(new[] { 5, 6, 6, 5, 4, 6, 10, 3, 5, 5 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_FullNamesWithInterpolation()
    {
        // Task: "FirstName LastName" for each instructor (build the string yourself, do not use FullName).
        IEnumerable<string> result = Data.Instructors.Select(i => $"{i.FirstName} {i.LastName}"); //!

        Assert.Equal(new[] { "Kate Williams", "Jurnell Cockhren", "Blaise Gratton" }, result.Take(3));
    }

    [Fact]
    public void Medium_05_ProjectToTuple()
    {
        // Task: project each student to a named tuple (Name, Age) using FullName and Age.
        IEnumerable<(string Name, int Age)> result = Data.Students.Select(s => (s.FullName, s.Age)); //!

        Assert.Equal(("Anne Appleton", 47), result.First());
        Assert.Equal(("Richard Ridley", 77), result.ElementAt(17));
    }

    [Fact]
    public void Medium_06_ProjectToRecord()
    {
        // Task: project each student to a StudentSummary(FullName, City, Age). Records compare by value,
        // so the assertion can compare against a freshly constructed instance.
        IEnumerable<StudentSummary> result = Data.Students.Select(s => new StudentSummary(s.FullName, s.City, s.Age)); //!

        Assert.Equal(new StudentSummary("Carrie Cooper", "Memphis", 29), result.ElementAt(2));
    }

    [Fact]
    public void Medium_07_SelectWithIndex()
    {
        // Task: Select has an overload whose selector receives (element, index). Multiply each number by its index.
        IEnumerable<int> result = Data.Numbers.Select((n, i) => n * i); //!

        Assert.Equal(new[] { 0, 3, 16, 3, 36, 10, 48, 49, 24, 90 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_NestedAggregateInsideSelect()
    {
        // Task: for each cohort, a tuple of (Name, number of ACTIVE students in that cohort).
        IEnumerable<(string Name, int ActiveStudents)> result = Data.Cohorts.Select(c => (c.Name, c.Students.Count(s => s.Active))); //!

        Assert.Equal(new[]
        {
            ("Evening Five", 4), ("Cohort of the Future", 5), ("Evening Ninja Warriors", 3), ("Day Backgammon Geeks", 4),
        }, result);
    }

    [Fact]
    public void Hard_09_SelectIsLazyAndRunsPerElement()
    {
        // Task: project Data.Numbers to n * 2, incrementing `calls` inside the selector each time it runs.
        // Nothing should run until the query is enumerated, and Take(2) should only run the selector twice.
        int calls = 0;

        IEnumerable<int> query = Data.Numbers.Select(n => { calls++; return n * 2; }); //!

        Assert.Equal(0, calls);
        Assert.Equal(new[] { 10, 6 }, query.Take(2));
        Assert.Equal(2, calls);
    }

    [Fact]
    public void Hard_10_MethodGroupAsSelector()
    {
        // Task: parse each string to an int. Pass the method group int.Parse directly instead of writing a lambda.
        var digits = new[] { "1", "22", "333" };

        IEnumerable<int> result = digits.Select(int.Parse); //!

        Assert.Equal(new[] { 1, 22, 333 }, result);
    }
}
