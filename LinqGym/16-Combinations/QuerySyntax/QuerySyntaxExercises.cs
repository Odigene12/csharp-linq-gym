namespace LinqGym.Combinations;

/// <summary>
/// Query syntax (from ... where ... select) is compiled into the same method calls you have been writing.
/// It shines for joins, `let`, and multi-level `from`. Solve EVERY exercise in this file with query syntax -
/// the tests cannot check the syntax you used, so hold yourself to it.
/// </summary>
public class QuerySyntaxExercises : LinqExercise
{
    [Fact]
    public void Query_01_FromWhereSelect()
    {
        // Task: the even numbers, with from / where / select.
        IEnumerable<int> result = from n in Data.Numbers where n % 2 == 0 select n; //!

        Assert.Equal(new[] { 8, 2, 8, 10 }, result);
    }

    [Fact]
    public void Query_02_OrderByDescending()
    {
        // Task: numbers descending, with `orderby n descending`.
        IEnumerable<int> result = from n in Data.Numbers orderby n descending select n; //!

        Assert.Equal(new[] { 10, 9, 8, 8, 7, 5, 3, 3, 2, 1 }, result);
    }

    [Fact]
    public void Query_03_OrderByMultipleKeys()
    {
        // Task: students by City then LastName - `orderby s.City, s.LastName` (a comma list = ThenBy).
        IEnumerable<int> result = from s in Data.Students orderby s.City, s.LastName select s.Id; //!

        Assert.Equal(new[] { 7, 13, 18, 5, 9, 15, 20, 3, 6, 11, 16, 1, 2, 4, 8, 10, 12, 14, 17, 19 }, result);
    }

    [Fact]
    public void Query_04_LetIntroducesAVariable()
    {
        // Task: (word, length) pairs for words longer than 5 characters, computing the length once with `let`.
        IEnumerable<(string Word, int Length)> result = from w in Data.Words let len = w.Length where len > 5 select (w, len); //!

        Assert.Equal(new[] { ("Banana", 6), ("cherry", 6), ("banana", 6), ("Elderberry", 10) }, result);
    }

    [Fact]
    public void Query_05_GroupBy()
    {
        // Task: students grouped by City - `group s by s.City`.
        IEnumerable<IGrouping<string, Student>> result = from s in Data.Students group s by s.City; //!

        Assert.Equal(4, result.Count());
    }

    [Fact]
    public void Query_06_GroupIntoWithProjection()
    {
        // Task: (City, count) - `group s by s.City into g select (g.Key, g.Count())`.
        IEnumerable<(string City, int Count)> result = from s in Data.Students group s by s.City into g select (g.Key, g.Count()); //!

        Assert.Equal(new[] { ("Nashville", 9), ("Memphis", 4), ("Knoxville", 4), ("Chattanooga", 3) }, result);
    }

    [Fact]
    public void Query_07_Join()
    {
        // Task: the FirstName for each enrollment - `join s in Data.Students on e.StudentId equals s.Id`.
        IEnumerable<string> result = from e in Data.Enrollments join s in Data.Students on e.StudentId equals s.Id select s.FirstName; //!

        Assert.Equal(32, result.Count());
        Assert.Equal("Anne", result.First());
    }

    [Fact]
    public void Query_08_JoinInto()
    {
        // Task: (Code, enrollment count) per course - `join ... into es` is a GroupJoin.
        IEnumerable<(string Code, int Count)> result = from c in Data.Courses join e in Data.Enrollments on c.Id equals e.CourseId into es select (c.Code, es.Count()); //!

        Assert.Equal(new[] { 8, 4, 5, 4, 5, 4, 0, 2 }, result.Select(r => r.Count));
    }

    [Fact]
    public void Query_09_LeftJoin()
    {
        // Task: the classic query-syntax left join: `join ... into es from e in es.DefaultIfEmpty() select (c.Code, (int?)e?.Id)`.
        IEnumerable<(string Code, int? EnrollmentId)> result = //!{
            from c in Data.Courses
            join e in Data.Enrollments on c.Id equals e.CourseId into es
            from e in es.DefaultIfEmpty()
            select (c.Code, (int?)e?.Id);
        //!}

        Assert.Equal(33, result.Count());
        Assert.Contains(("QC999", (int?)null), result);
    }

    [Fact]
    public void Query_10_MultipleFromIsSelectMany()
    {
        // Task: (CohortName, StudentFirstName) for every inactive student - `from c in ... from s in c.Students where ...`.
        IEnumerable<(string Cohort, string Student)> result = from c in Data.Cohorts from s in c.Students where !s.Active select (c.Name, s.FirstName); //!

        Assert.Equal(4, result.Count());
        Assert.Equal(("Evening Five", "Bobbie"), result.First());
    }

    [Fact]
    public void Query_11_SelectIntoContinuation()
    {
        // Task: ages over 60 - project to Age, then continue with `into age where age > 60 select age`.
        IEnumerable<int> result = from s in Data.Students select s.Age into age where age > 60 select age; //!

        Assert.Equal(new[] { 67, 77 }, result);
    }

    [Fact]
    public void Query_12_MixQuerySyntaxWithMethodCalls()
    {
        // Task: the sum of the even numbers - wrap a query expression in parentheses and call .Sum() on it.
        int result = (from n in Data.Numbers where n % 2 == 0 select n).Sum(); //!

        Assert.Equal(28, result);
    }
}
