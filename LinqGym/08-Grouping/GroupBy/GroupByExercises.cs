namespace LinqGym.Grouping;

/// <summary>
/// GroupBy - bucket elements by a key. Yields IGrouping&lt;TKey, TElement&gt; objects (a Key plus the elements),
/// in the order the keys were first seen. Deferred, but the whole source is consumed on first enumeration.
/// </summary>
public class GroupByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_StudentsByCity()
    {
        // Task: group students by City.
        IEnumerable<IGrouping<string, Student>> result = Data.Students.GroupBy(s => s.City); //!

        Assert.Equal(new[] { "Nashville", "Memphis", "Knoxville", "Chattanooga" }, result.Select(g => g.Key));
        Assert.Equal(9, result.First().Count());
    }

    [Fact]
    public void Easy_02_NumbersByParity()
    {
        // Task: group numbers by whether they are even (key = bool).
        IEnumerable<IGrouping<bool, int>> result = Data.Numbers.GroupBy(n => n % 2 == 0); //!

        Assert.Equal(new[] { 5, 3, 1, 9, 7, 3 }, result.Single(g => !g.Key));
        Assert.Equal(new[] { 8, 2, 8, 10 }, result.Single(g => g.Key));
    }

    [Fact]
    public void Easy_03_WordsByLength()
    {
        // Task: group words by Length.
        IEnumerable<IGrouping<int, string>> result = Data.Words.GroupBy(w => w.Length); //!

        Assert.Equal(4, result.Single(g => g.Key == 5).Count());
        Assert.Equal(5, result.Count());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_CountPerGroup()
    {
        // Task: (City, StudentCount) pairs - GroupBy followed by Select.
        IEnumerable<(string City, int Count)> result = Data.Students.GroupBy(s => s.City).Select(g => (g.Key, g.Count())); //!

        Assert.Equal(new[] { ("Nashville", 9), ("Memphis", 4), ("Knoxville", 4), ("Chattanooga", 3) }, result);
    }

    [Fact]
    public void Medium_05_ElementSelector()
    {
        // Task: group by City but keep only FirstName as the element (use the elementSelector overload).
        IEnumerable<IGrouping<string, string>> result = Data.Students.GroupBy(s => s.City, s => s.FirstName); //!

        Assert.Equal(new[] { "Gary", "Matt", "Richard" }, result.Single(g => g.Key == "Chattanooga"));
    }

    [Fact]
    public void Medium_06_ResultSelector()
    {
        // Task: use the resultSelector overload (key, elements) => ... to get (CourseId, AverageGrade) per course.
        IEnumerable<(int CourseId, double? Average)> result = Data.Enrollments.GroupBy(e => e.CourseId, (key, es) => (key, es.Average(e => e.Grade))); //!

        Assert.Equal(80.4, result.Single(r => r.CourseId == 3).Average);
    }

    [Fact]
    public void Medium_07_GroupByWithAComparer()
    {
        // Task: group words ignoring case; "apple", "apple" and "APPLE" end up in one group.
        IEnumerable<IGrouping<string, string>> result = Data.Words.GroupBy(w => w, StringComparer.OrdinalIgnoreCase); //!

        Assert.Equal(7, result.Count());
        Assert.Equal(3, result.First().Count());
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_CompositeKey()
    {
        // Task: group enrollments by (Year of EnrolledOn, CourseId) using a tuple or anonymous type as the key.
        IEnumerable<IGrouping<(int Year, int CourseId), Enrollment>> result = Data.Enrollments.GroupBy(e => (e.EnrolledOn.Year, e.CourseId)); //!

        Assert.Equal(13, result.Count());
        Assert.Equal(4, result.Single(g => g.Key == (2024, 1)).Count());
    }

    [Fact]
    public void Hard_09_OldestStudentPerCity()
    {
        // Task: for each city (in first-seen order), the FirstName of its oldest student.
        IEnumerable<string> result = Data.Students.GroupBy(s => s.City).Select(g => g.MaxBy(s => s.Age)!.FirstName); //!

        Assert.Equal(new[] { "Quincy", "Francis", "Ethel", "Richard" }, result);
    }

    [Fact]
    public void Hard_10_FilterGroupsLikeSqlHaving()
    {
        // Task: the cities that have MORE than three students (filter the groups, then project the keys).
        IEnumerable<string> result = Data.Students.GroupBy(s => s.City).Where(g => g.Count() > 3).Select(g => g.Key); //!

        Assert.Equal(new[] { "Nashville", "Memphis", "Knoxville" }, result);
    }
}
