namespace LinqGym.Joining;

/// <summary>
/// GroupJoin - for each OUTER element, the collection of matching inner elements (possibly empty).
/// Every outer element appears exactly once - it is a "left join with the matches grouped".
/// Signature: outer.GroupJoin(inner, outerKey, innerKey, (outer, IEnumerable&lt;inner&gt;) => result).
/// </summary>
public class GroupJoinExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_EnrollmentCountPerCourse()
    {
        // Task: (Code, number of enrollments) for every course - including QC999 with 0.
        IEnumerable<(string Code, int Count)> result = Data.Courses.GroupJoin(Data.Enrollments, c => c.Id, e => e.CourseId, (c, es) => (c.Code, es.Count())); //!

        Assert.Equal(new[] { 8, 4, 5, 4, 5, 4, 0, 2 }, result.Select(r => r.Count));
    }

    [Fact]
    public void Easy_02_StudentsWithNoEnrollments()
    {
        // Task: the Ids of students whose group of enrollments is empty.
        IEnumerable<int> result = Data.Students.GroupJoin(Data.Enrollments, s => s.Id, e => e.StudentId, (s, es) => (s.Id, es)).Where(x => !x.es.Any()).Select(x => x.Id); //!

        Assert.Equal(new[] { 2, 12, 17 }, result);
    }

    [Fact]
    public void Easy_03_StudentsPerCohortViaGroupJoin()
    {
        // Task: join cohorts to students on Cohort.Id == Student.CohortId and count each cohort's students.
        IEnumerable<int> result = Data.Cohorts.GroupJoin(Data.Students, c => c.Id, s => s.CohortId, (c, ss) => ss.Count()); //!

        Assert.Equal(new[] { 5, 5, 5, 5 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_CoursesPerInstructor()
    {
        // Task: (Instructor FirstName, list of course Codes). Mind the int vs int? key types.
        IEnumerable<(string Name, List<string> Codes)> result = Data.Instructors.GroupJoin(Data.Courses, i => (int?)i.Id, c => c.InstructorId, (i, cs) => (i.FirstName, cs.Select(c => c.Code).ToList())); //!

        Assert.Equal(new[] { "CS101", "DB201" }, result.Single(r => r.Name == "Kate").Codes);
        Assert.Empty(result.Single(r => r.Name == "Terry").Codes);
    }

    [Fact]
    public void Medium_05_AverageGradePerCourseWithNullForEmpty()
    {
        // Task: (Code, average Grade) per course. Averaging an empty sequence of int? gives null rather than throwing,
        // so QC999 comes out as null naturally.
        IEnumerable<(string Code, double? Average)> result = Data.Courses.GroupJoin(Data.Enrollments, c => c.Id, e => e.CourseId, (c, es) => (c.Code, es.Average(e => e.Grade))); //!

        Assert.Equal(79.625, result.First().Average);
        Assert.Null(result.Single(r => r.Code == "QC999").Average);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_FlattenToALeftOuterJoin()
    {
        // Task: flatten the GroupJoin with SelectMany + DefaultIfEmpty so that every course appears at least once:
        // (Code, EnrollmentId or null). 32 real rows plus one null row for QC999 = 33.
        IEnumerable<(string Code, int? EnrollmentId)> result = //!{
            Data.Courses
                .GroupJoin(Data.Enrollments, c => c.Id, e => e.CourseId, (c, es) => (c, es))
                .SelectMany(x => x.es.DefaultIfEmpty(), (x, e) => (x.c.Code, (int?)e?.Id));
        //!}

        Assert.Equal(33, result.Count());
        Assert.Contains(("QC999", (int?)null), result);
    }

    [Fact]
    public void Hard_07_GroupJoinWithAComparer()
    {
        // Task: for each tag in TagsA, the tags in TagsB that match ignoring case.
        IEnumerable<(string Tag, List<string> Matches)> result = Data.TagsA.GroupJoin(Data.TagsB, a => a, b => b, (a, bs) => (a, bs.ToList()), StringComparer.OrdinalIgnoreCase); //!

        Assert.Empty(result.ElementAt(0).Matches);
        Assert.Equal(new[] { "linq" }, result.ElementAt(1).Matches);
        Assert.Equal(new[] { "Dotnet" }, result.ElementAt(2).Matches);
    }
}
