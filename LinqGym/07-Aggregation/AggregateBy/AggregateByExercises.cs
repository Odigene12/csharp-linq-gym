namespace LinqGym.Aggregation;

/// <summary>
/// AggregateBy (.NET 9+) - Aggregate, but per key: one accumulator per group, yielded as KeyValuePair&lt;TKey, TAccumulate&gt;.
/// Overloads take either a seed VALUE or a seed FACTORY (Func&lt;TKey, TAccumulate&gt;) - use the factory for mutable seeds.
/// </summary>
public class AggregateByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_CreditsPerCategory()
    {
        // Task: total Credits per course Category.
        IEnumerable<KeyValuePair<string, int>> result = Data.Courses.AggregateBy(c => c.Category, 0, (acc, c) => acc + c.Credits); //!

        Assert.Equal(new[]
        {
            KeyValuePair.Create("Backend", 7), KeyValuePair.Create("Frontend", 8), KeyValuePair.Create("Data", 7), KeyValuePair.Create("Research", 5), KeyValuePair.Create("General", 2),
        }, result);
    }

    [Fact]
    public void Easy_02_SumByParity()
    {
        // Task: the sum of odd numbers and the sum of even numbers (key = n % 2).
        IEnumerable<KeyValuePair<int, int>> result = Data.Numbers.AggregateBy(n => n % 2, 0, (acc, n) => acc + n); //!

        Assert.Equal(new[] { KeyValuePair.Create(1, 28), KeyValuePair.Create(0, 28) }, result);
    }

    [Fact]
    public void Easy_03_BestGradePerCourse()
    {
        // Task: the highest Grade per CourseId, considering graded enrollments only.
        IEnumerable<KeyValuePair<int, int>> result = Data.Enrollments.Where(e => e.Grade.HasValue).AggregateBy(e => e.CourseId, 0, (acc, e) => Math.Max(acc, e.Grade!.Value)); //!

        Assert.Equal(96, result.Single(kv => kv.Key == 1).Value);
        Assert.Equal(100, result.Single(kv => kv.Key == 8).Value);
        Assert.Equal(7, result.Count());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_FirstNamesPerCity()
    {
        // Task: a comma-separated string of first names per city ("Gary, Matt, Richard" for Chattanooga).
        IEnumerable<KeyValuePair<string, string>> result = Data.Students.AggregateBy(s => s.City, "", (acc, s) => acc.Length == 0 ? s.FirstName : acc + ", " + s.FirstName); //!

        Assert.Equal("Gary, Matt, Richard", result.Single(kv => kv.Key == "Chattanooga").Value);
    }

    [Fact]
    public void Medium_05_SeedFactoryForMutableAccumulators()
    {
        // Task: the list of CourseIds per StudentId. A List is mutable, so each key needs its OWN list -
        // use the seed-factory overload (key => new List<int>()) rather than passing one shared list.
        IEnumerable<KeyValuePair<int, List<int>>> result = Data.Enrollments.AggregateBy(e => e.StudentId, _ => new List<int>(), (acc, e) => { acc.Add(e.CourseId); return acc; }); //!

        Assert.Equal(new[] { 3, 4, 8 }, result.Single(kv => kv.Key == 9).Value);
        Assert.Equal(17, result.Count());
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_AggregateByWithAComparer()
    {
        // Task: count words ignoring case using AggregateBy (seed 0, add 1 per word, StringComparer.OrdinalIgnoreCase).
        IEnumerable<KeyValuePair<string, int>> result = Data.Words.AggregateBy(w => w, 0, (acc, _) => acc + 1, StringComparer.OrdinalIgnoreCase); //!

        Assert.Equal(3, result.Single(kv => kv.Key == "apple").Value);
        Assert.Equal(7, result.Count());
    }

    [Fact]
    public void Hard_07_AverageGradePerCourse()
    {
        // Task: (CourseId, AverageGrade) per course using a (Sum, Count) tuple accumulator over graded enrollments,
        // then a Select to divide. Course 1 averages 79.625.
        IEnumerable<(int CourseId, double Average)> result = //!{
            Data.Enrollments
                .Where(e => e.Grade.HasValue)
                .AggregateBy(e => e.CourseId, (Sum: 0, Count: 0), (acc, e) => (acc.Sum + e.Grade!.Value, acc.Count + 1))
                .Select(kv => (kv.Key, (double)kv.Value.Sum / kv.Value.Count));
        //!}

        Assert.Equal((1, 79.625), result.First());
        Assert.Equal(94.0, result.Single(r => r.CourseId == 8).Average);
    }
}
