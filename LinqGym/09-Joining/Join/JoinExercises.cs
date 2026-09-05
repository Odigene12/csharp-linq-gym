namespace LinqGym.Joining;

/// <summary>
/// Join - an INNER join: pair every outer element with every inner element that has an equal key.
/// Elements without a match on the other side are dropped. Output order follows the OUTER sequence.
/// Signature: outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector).
/// </summary>
public class JoinExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_EnrollmentsWithStudentNames()
    {
        // Task: join enrollments to students on StudentId == Id, producing (FirstName, CourseId).
        IEnumerable<(string Student, int CourseId)> result = TODO;

        Assert.Equal(32, result.Count());
        Assert.Equal(("Anne", 1), result.First());
    }

    [Fact]
    public void Easy_02_EnrollmentsWithCourseCodes()
    {
        // Task: join enrollments to courses, producing the course Code for each enrollment.
        IEnumerable<string> result = TODO;

        Assert.Equal("CS101", result.First());
        Assert.Equal(32, result.Count());
    }

    [Fact]
    public void Easy_03_CoursesWithInstructorNames()
    {
        // Task: join courses to instructors on InstructorId == Id, producing (Code, Instructor FullName).
        // Course.InstructorId is int? while Instructor.Id is int - the key types must match, so cast one side.
        // SE100 (no instructor) is dropped because inner joins only keep matches.
        IEnumerable<(string Code, string Instructor)> result = TODO;

        Assert.Equal(7, result.Count());
        Assert.Equal(("CS101", "Kate Williams"), result.First());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ThreeWayJoin()
    {
        // Task: enrollment -> student -> course, producing (StudentFirstName, CourseCode, Grade). Chain two Joins.
        IEnumerable<(string Student, string Course, int? Grade)> result = TODO;

        Assert.Equal(32, result.Count());
        Assert.Equal(("Ingrid", "SE100", (int?)100), result.ElementAt(16));
    }

    [Fact]
    public void Medium_05_CompositeKeyJoin()
    {
        // Task: join enrollments to `bonuses` on BOTH StudentId and CourseId (use a tuple or anonymous type as the key),
        // producing Grade + Bonus.
        var bonuses = new[] { (StudentId: 1, CourseId: 1, Bonus: 5), (StudentId: 9, CourseId: 8, Bonus: 3) };

        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 97, 103 }, result);
    }

    [Fact]
    public void Medium_06_UnmatchedOuterRowsDisappear()
    {
        // Task: join students to enrollments. Students 2, 12 and 17 have no enrollments and must not appear at all.
        IEnumerable<int> result = TODO;

        Assert.Equal(32, result.Count());
        Assert.Equal(17, result.Distinct().Count());
        Assert.DoesNotContain(12, result);
    }

    [Fact]
    public void Medium_07_JoinWithAComparer()
    {
        // Task: join Data.TagsA to Data.TagsB on the tag itself, ignoring case, producing (a, b) pairs.
        IEnumerable<(string A, string B)> result = TODO;

        Assert.Equal(new[] { ("LINQ", "linq"), ("dotnet", "Dotnet") }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_EnrollmentsPerInstructor()
    {
        // Task: (InstructorId, number of enrollments in that instructor's courses), most first, excluding courses with no instructor.
        IEnumerable<(int InstructorId, int Enrollments)> result = TODO;

        Assert.Equal(new[] { (1, 12), (2, 9), (5, 5), (3, 4) }, result);
    }

    [Fact]
    public void Hard_09_SelfJoinStudentsSharingCohortAndBirthMonth()
    {
        // Task: pairs of students in the same cohort born in the same month (each pair once: a.Id < b.Id), as (FirstName, FirstName).
        IEnumerable<(string, string)> result = TODO;

        Assert.Equal(new[] { ("Anne", "Carrie"), ("Richard", "Terrence") }, result);
    }

    [Fact]
    public void Hard_10_StudentsTaughtByKateWilliams()
    {
        // Task: the distinct Ids of students enrolled in any course whose InstructorId is 1.
        IEnumerable<int> result = TODO;

        LinqAssert.SameItems(new[] { 1, 3, 4, 5, 7, 8, 10, 11, 13, 16, 19 }, result);
    }
}
