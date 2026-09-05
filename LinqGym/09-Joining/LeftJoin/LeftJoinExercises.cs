namespace LinqGym.Joining;

/// <summary>
/// LeftJoin (.NET 10+) - a LEFT OUTER join in one call: every outer element appears at least once;
/// when it has no match the inner argument of the result selector is default (null).
/// Signature: outer.LeftJoin(inner, outerKey, innerKey, (outer, inner?) => result).
/// </summary>
public class LeftJoinExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_CoursesWithEnrollments()
    {
        // Task: (Code, EnrollmentId?) for every course/enrollment pair, keeping courses with no enrollments.
        IEnumerable<(string Code, int? EnrollmentId)> result = TODO;

        Assert.Equal(33, result.Count());
        Assert.Contains(("QC999", (int?)null), result);
    }

    [Fact]
    public void Easy_02_StudentsWithoutEnrollmentsGetANullRow()
    {
        // Task: left join students to enrollments; count the rows whose enrollment is null.
        IEnumerable<(Student Student, Enrollment? Enrollment)> result = TODO;

        Assert.Equal(35, result.Count());
        Assert.Equal(3, result.Count(r => r.Enrollment is null));
    }

    [Fact]
    public void Easy_03_CoursesWithInstructorOrUnassigned()
    {
        // Task: (Code, instructor FullName or "unassigned"). Course.InstructorId is int?, so cast the instructor Id.
        IEnumerable<(string Code, string Instructor)> result = TODO;

        Assert.Equal(8, result.Count());
        Assert.Equal(("SE100", "unassigned"), result.Last());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_InstructorsWithTheirCourses()
    {
        // Task: (Instructor FirstName, Course Code or null) - Terry teaches nothing and still gets one row.
        IEnumerable<(string Instructor, string? Code)> result = TODO;

        Assert.Equal(8, result.Count());
        Assert.Contains(("Terry", (string?)null), result);
    }

    [Fact]
    public void Medium_05_CoalesceMissingValues()
    {
        // Task: (Code, Grade) rows where a missing enrollment OR a null grade becomes -1.
        IEnumerable<(string Code, int Grade)> result = TODO;

        Assert.Equal(4, result.Count(r => r.Grade == -1));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_CountPerCourseIncludingZero()
    {
        // Task: enrollment counts per course (in course order) from a LeftJoin + GroupBy, counting only non-null matches.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 8, 4, 5, 4, 5, 4, 0, 2 }, result);
    }

    [Fact]
    public void Hard_07_LeftJoinEqualsTheClassicRecipe()
    {
        // Task: write the same left join twice - once with LeftJoin and once with GroupJoin/SelectMany/DefaultIfEmpty -
        // and show they produce identical (Code, EnrollmentId?) rows.
        IEnumerable<(string, int?)> modern = TODO;
        IEnumerable<(string, int?)> classic = TODO;

        Assert.Equal(classic, modern);
    }
}
