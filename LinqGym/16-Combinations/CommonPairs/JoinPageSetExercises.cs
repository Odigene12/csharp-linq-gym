namespace LinqGym.Combinations;

/// <summary>
/// Part 3: paging, joining and set-style combinations.
/// </summary>
public class JoinPageSetExercises : LinqExercise
{
    [Fact]
    public void Pair_01_SkipTakePaging()
    {
        // Task: page 2 of the students when the page size is 5 (students 6-10).
        int page = 2, pageSize = 5;

        IEnumerable<int> result = Data.Students.Skip((page - 1) * pageSize).Take(pageSize).Select(s => s.Id); //!

        Assert.Equal(new[] { 6, 7, 8, 9, 10 }, result);
    }

    [Fact]
    public void Pair_02_OrderOfSkipAndTakeMatters()
    {
        // Task: Take(5).Skip(2) versus Skip(2).Take(5) over Data.Numbers - different results!
        IEnumerable<int> takeThenSkip = Data.Numbers.Take(5).Skip(2); //!
        IEnumerable<int> skipThenTake = Data.Numbers.Skip(2).Take(5); //!

        Assert.Equal(new[] { 8, 1, 9 }, takeThenSkip);
        Assert.Equal(new[] { 8, 1, 9, 2, 8 }, skipThenTake);
    }

    [Fact]
    public void Pair_03_JoinWhereSelectDistinct()
    {
        // Task: the distinct first names of students who scored 90 or more in any course (join enrollments to students).
        IEnumerable<string> result = Data.Enrollments.Where(e => e.Grade >= 90).Join(Data.Students, e => e.StudentId, s => s.Id, (e, s) => s.FirstName).Distinct(); //!

        Assert.Equal(new[] { "Anne", "Carrie", "Ethel", "Ingrid", "Paul" }, result);
    }

    [Fact]
    public void Pair_04_GroupJoinToFindOrphans()
    {
        // Task: course codes that have zero enrollments (GroupJoin, then keep empty groups).
        IEnumerable<string> result = Data.Courses.GroupJoin(Data.Enrollments, c => c.Id, e => e.CourseId, (c, es) => (c.Code, es)).Where(x => !x.es.Any()).Select(x => x.Code); //!

        Assert.Equal(new[] { "QC999" }, result);
    }

    [Fact]
    public void Pair_05_SelectManyDistinct()
    {
        // Task: the distinct Ids of every instructor attached to any cohort (primary first, then juniors, per cohort).
        IEnumerable<int> result = Data.Cohorts.SelectMany(c => c.JuniorInstructors.Prepend(c.PrimaryInstructor)).Select(i => i.Id).Distinct(); //!

        Assert.Equal(new[] { 2, 1, 3, 6, 5, 4 }, result);
    }

    [Fact]
    public void Pair_06_ContainsFilterThenOrder()
    {
        // Task: the students whose Id is in `wanted`, oldest first.
        var wanted = new[] { 15, 3, 9 };

        IEnumerable<int> result = Data.Students.Where(s => wanted.Contains(s.Id)).OrderBy(s => s.Birthday).Select(s => s.Id); //!

        Assert.Equal(new[] { 15, 9, 3 }, result);
    }

    [Fact]
    public void Pair_07_TopN()
    {
        // Task: the three highest grades (OrderByDescending + Take + Select).
        IEnumerable<int?> result = Data.Enrollments.OrderByDescending(e => e.Grade).Take(3).Select(e => e.Grade); //!

        Assert.Equal(new int?[] { 100, 96, 95 }, result);
    }

    [Fact]
    public void Pair_08_SliceBetweenTwoMarkers()
    {
        // Task: the numbers strictly between the first 8 and the second 8: SkipWhile to the first 8, Skip it, TakeWhile not 8.
        IEnumerable<int> result = Data.Numbers.SkipWhile(n => n != 8).Skip(1).TakeWhile(n => n != 8); //!

        Assert.Equal(new[] { 1, 9, 2 }, result);
    }
}
