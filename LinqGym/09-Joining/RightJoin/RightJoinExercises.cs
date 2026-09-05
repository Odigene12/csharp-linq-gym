namespace LinqGym.Joining;

/// <summary>
/// RightJoin (.NET 10+) - a RIGHT OUTER join: every INNER element appears at least once; unmatched ones get a default outer.
/// Signature: outer.RightJoin(inner, outerKey, innerKey, (outer?, inner) => result). Output order follows the INNER sequence.
/// </summary>
public class RightJoinExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_EveryCourseAppears()
    {
        // Task: enrollments RIGHT-joined to courses, producing (EnrollmentId?, Code). 33 rows.
        IEnumerable<(int? EnrollmentId, string Code)> result = Data.Enrollments.RightJoin(Data.Courses, e => e.CourseId, c => c.Id, (e, c) => ((int?)e?.Id, c.Code)); //!

        Assert.Equal(33, result.Count());
        Assert.Contains(((int?)null, "QC999"), result);
    }

    [Fact]
    public void Easy_02_EveryStudentAppears()
    {
        // Task: enrollments right-joined to students; 32 matches + 3 students without enrollments = 35 rows.
        IEnumerable<(Enrollment? Enrollment, Student Student)> result = Data.Enrollments.RightJoin(Data.Students, e => e.StudentId, s => s.Id, (e, s) => (e, s)); //!

        Assert.Equal(35, result.Count());
    }

    [Fact]
    public void Easy_03_EveryInstructorAppears()
    {
        // Task: courses right-joined to instructors on InstructorId == Id (cast the int to int?). Terry has no course.
        IEnumerable<(string? Code, string Instructor)> result = Data.Courses.RightJoin(Data.Instructors, c => c.InstructorId, i => (int?)i.Id, (c, i) => (c?.Code, i.FirstName)); //!

        Assert.Equal(8, result.Count());
        Assert.Contains(((string?)null, "Terry"), result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_StudentsWithNoEnrollmentViaRightJoin()
    {
        // Task: the first names of the students whose outer (enrollment) side is null.
        IEnumerable<string> result = Data.Enrollments.RightJoin(Data.Students, e => e.StudentId, s => s.Id, (e, s) => (e, s)).Where(x => x.e is null).Select(x => x.s.FirstName); //!

        Assert.Equal(new[] { "Bobbie", "Louis", "Quincy" }, result);
    }

    [Fact]
    public void Medium_05_RightJoinIsASwappedLeftJoin()
    {
        // Task: express "every course with its enrollments" both ways: courses.LeftJoin(enrollments) and enrollments.RightJoin(courses).
        // Both yield 33 (Code, EnrollmentId?) rows.
        IEnumerable<(string, int?)> left = Data.Courses.LeftJoin(Data.Enrollments, c => c.Id, e => e.CourseId, (c, e) => (c.Code, (int?)e?.Id)); //!
        IEnumerable<(string, int?)> right = Data.Enrollments.RightJoin(Data.Courses, e => e.CourseId, c => c.Id, (e, c) => (c.Code, (int?)e?.Id)); //!

        Assert.Equal(33, left.Count());
        Assert.Equal(33, right.Count());
        LinqAssert.SameItems(left, right);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_CoursesPerInstructorIncludingZero()
    {
        // Task: (Instructor FirstName, course count) for every instructor, counting only real matches.
        IEnumerable<(string Name, int Courses)> result = //!{
            Data.Courses
                .RightJoin(Data.Instructors, c => c.InstructorId, i => (int?)i.Id, (c, i) => (i.FirstName, c))
                .GroupBy(x => x.FirstName)
                .Select(g => (g.Key, g.Count(x => x.c is not null)));
        //!}

        Assert.Equal(new[] { ("Kate", 2), ("Jurnell", 2), ("Blaise", 1), ("Terry", 0), ("Jason", 1), ("Zachary", 1) }, result);
    }

    [Fact]
    public void Hard_07_CoursesNobodyTook()
    {
        // Task: the Codes of courses that have no enrollments, found with a RightJoin.
        IEnumerable<string> result = Data.Enrollments.RightJoin(Data.Courses, e => e.CourseId, c => c.Id, (e, c) => (e, c)).Where(x => x.e is null).Select(x => x.c.Code); //!

        Assert.Equal(new[] { "QC999" }, result);
    }
}
