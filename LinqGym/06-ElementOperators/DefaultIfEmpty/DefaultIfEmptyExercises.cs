namespace LinqGym.ElementOperators;

/// <summary>
/// DefaultIfEmpty - if the sequence is empty, yield a single default value instead; otherwise pass it through unchanged.
/// Its most famous job is building LEFT OUTER JOINs together with GroupJoin.
/// </summary>
public class DefaultIfEmptyExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_EmptyBecomesSingleDefault()
    {
        // Task: Data.Empty with DefaultIfEmpty() yields exactly one element: 0.
        IEnumerable<int> result = Data.Empty.DefaultIfEmpty(); //!

        Assert.Equal(new[] { 0 }, result);
    }

    [Fact]
    public void Easy_02_NonEmptyIsUnchanged()
    {
        // Task: Data.Numbers with DefaultIfEmpty() is just Data.Numbers.
        IEnumerable<int> result = Data.Numbers.DefaultIfEmpty(); //!

        Assert.Equal(Data.Numbers, result);
    }

    [Fact]
    public void Easy_03_CustomDefault()
    {
        // Task: Data.Empty with a default of -1.
        IEnumerable<int> result = Data.Empty.DefaultIfEmpty(-1); //!

        Assert.Equal(new[] { -1 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_EmptyQueryOverClassesYieldsOneNull()
    {
        // Task: students from "Paris" (none) with DefaultIfEmpty - one element, and it is null.
        IEnumerable<Student?> result = Data.Students.Where(s => s.City == "Paris").DefaultIfEmpty(); //!

        Assert.Single(result);
        Assert.Null(result.First());
    }

    [Fact]
    public void Medium_05_SafeMaxOfAPossiblyEmptySequence()
    {
        // Task: Max() on an empty sequence throws. Use DefaultIfEmpty so the max of Data.Empty is 0 instead.
        int result = Data.Empty.DefaultIfEmpty().Max(); //!

        Assert.Equal(0, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_LeftOuterJoinWithGroupJoinAndDefaultIfEmpty()
    {
        // Task: one row per (Course, Enrollment) pair, but courses with NO enrollments must still appear once
        // with a null enrollment id. The classic recipe: GroupJoin -> SelectMany(group.DefaultIfEmpty()).
        IEnumerable<(string Code, int? EnrollmentId)> result = //!{
            Data.Courses
                .GroupJoin(Data.Enrollments, c => c.Id, e => e.CourseId, (c, es) => (c, es))
                .SelectMany(x => x.es.DefaultIfEmpty(), (x, e) => (x.c.Code, (int?)e?.Id));
        //!}

        Assert.Equal(33, result.Count());
        Assert.Contains(("QC999", (int?)null), result);
        Assert.Equal(8, result.Count(r => r.Code == "CS101"));
    }

    [Fact]
    public void Hard_07_AverageOfAPossiblyEmptyGroup()
    {
        // Task: the average grade of course 7 (which has no enrollments) as 0.0 rather than an exception.
        // Treat null grades as 0 and use DefaultIfEmpty before Average.
        double result = Data.Enrollments.Where(e => e.CourseId == 7).Select(e => e.Grade ?? 0).DefaultIfEmpty().Average(); //!

        Assert.Equal(0.0, result);
    }
}
