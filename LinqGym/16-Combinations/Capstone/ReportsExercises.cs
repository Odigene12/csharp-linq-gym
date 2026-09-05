namespace LinqGym.Combinations;

/// <summary>
/// Capstone, part 1: build real reports. Each exercise needs several operators working together.
/// Write the query however you like (method or query syntax, single expression or a few steps).
/// </summary>
public class ReportsExercises : LinqExercise
{
    [Fact]
    public void Report_01_CohortSummary()
    {
        // Task: for each cohort: (Name, ActiveStudents, AverageAge).
        IEnumerable<(string Name, int ActiveStudents, double AverageAge)> result = Data.Cohorts.Select(c => (c.Name, c.Students.Count(s => s.Active), c.Students.Average(s => s.Age))); //!

        Assert.Equal(new[]
        {
            ("Evening Five", 4, 41.6), ("Cohort of the Future", 5, 45.2), ("Evening Ninja Warriors", 3, 45.6), ("Day Backgammon Geeks", 4, 55.2),
        }, result);
    }

    [Fact]
    public void Report_02_CourseSummary()
    {
        // Task: for each course, a CourseStats(Code, EnrollmentCount, AverageGrade) where AverageGrade is over graded
        // enrollments only and 0 when there are none. Keep course order.
        IEnumerable<CourseStats> result = //!{
            Data.Courses.Select(c =>
            {
                var es = Data.Enrollments.Where(e => e.CourseId == c.Id).ToList();
                var graded = es.Where(e => e.Grade.HasValue).ToList();
                return new CourseStats(c.Code, es.Count, graded.Count == 0 ? 0 : graded.Average(e => e.Grade!.Value));
            });
        //!}

        Assert.Equal(new CourseStats("CS101", 8, 79.625), result.First());
        Assert.Equal(new CourseStats("QC999", 0, 0), result.ElementAt(6));
        Assert.Equal(new CourseStats("SE100", 2, 94), result.Last());
    }

    [Fact]
    public void Report_03_InstructorWorkload()
    {
        // Task: for each instructor: (FullName, CourseCount, DistinctStudentCount across their courses),
        // ordered by DistinctStudentCount descending, then FullName ascending.
        IEnumerable<(string Name, int Courses, int Students)> result = //!{
            Data.Instructors
                .Select(i =>
                {
                    var courseIds = Data.Courses.Where(c => c.InstructorId == i.Id).Select(c => c.Id).ToList();
                    var students = Data.Enrollments.Where(e => courseIds.Contains(e.CourseId)).Select(e => e.StudentId).Distinct().Count();
                    return (i.FullName, courseIds.Count, students);
                })
                .OrderByDescending(x => x.students)
                .ThenBy(x => x.FullName);
        //!}

        Assert.Equal(new[]
        {
            ("Kate Williams", 2, 11), ("Jason JavaFanBoy", 1, 5), ("Jurnell Cockhren", 2, 5), ("Blaise Gratton", 1, 4), ("Terry TerribleInstructor", 0, 0), ("Zachary Zohan", 1, 0),
        }, result);
    }

    [Fact]
    public void Report_04_CityLeaderboard()
    {
        // Task: (City, StudentCount, ActiveRate) per city, ordered by ActiveRate descending then City ascending.
        // ActiveRate = active students / all students in that city, as a double.
        IEnumerable<(string City, int Students, double ActiveRate)> result = //!{
            Data.Students
                .GroupBy(s => s.City)
                .Select(g => (g.Key, g.Count(), (double)g.Count(s => s.Active) / g.Count()))
                .OrderByDescending(x => x.Item3)
                .ThenBy(x => x.Key);
        //!}

        Assert.Equal(new[] { "Chattanooga", "Knoxville", "Memphis", "Nashville" }, result.Select(r => r.City));
        Assert.Equal(0.75, result.ElementAt(2).ActiveRate);
    }

    [Fact]
    public void Report_05_TopThreeStudentsByAverageGrade()
    {
        // Task: the first names of the three students with the highest average Grade, counting only students with
        // at least TWO graded enrollments.
        IEnumerable<string> result = //!{
            Data.Enrollments
                .Where(e => e.Grade.HasValue)
                .GroupBy(e => e.StudentId)
                .Where(g => g.Count() >= 2)
                .OrderByDescending(g => g.Average(e => e.Grade!.Value))
                .Take(3)
                .Select(g => Data.Student(g.Key).FirstName);
        //!}

        Assert.Equal(new[] { "Ingrid", "Paul", "Carrie" }, result);
    }

    [Fact]
    public void Report_06_StudentsWhoTookEveryBackendCourse()
    {
        // Task: first names of students enrolled in ALL courses of the "Backend" category.
        IEnumerable<string> result = //!{
            Data.Students
                .Where(s => Data.Courses.Where(c => c.Category == "Backend").All(c => Data.Enrollments.Any(e => e.StudentId == s.Id && e.CourseId == c.Id)))
                .Select(s => s.FirstName);
        //!}

        Assert.Equal(new[] { "Anne", "Derek", "Paul" }, result);
    }

    [Fact]
    public void Report_07_GradeDistribution()
    {
        // Task: how many graded enrollments fall in each band: "A" (90+), "B" (80-89), "C" (70-79), "F" (below 70), ordered by band.
        IEnumerable<(string Band, int Count)> result = //!{
            Data.Enrollments
                .Where(e => e.Grade.HasValue)
                .GroupBy(e => e.Grade >= 90 ? "A" : e.Grade >= 80 ? "B" : e.Grade >= 70 ? "C" : "F")
                .Select(g => (g.Key, g.Count()))
                .OrderBy(x => x.Key);
        //!}

        Assert.Equal(new[] { ("A", 8), ("B", 10), ("C", 7), ("F", 4) }, result);
    }

    [Fact]
    public void Report_08_BirthdayCalendar()
    {
        // Task: (Month, number of students born that month) for every month that has at least one student, ordered by month.
        IEnumerable<(int Month, int Count)> result = Data.Students.GroupBy(s => s.Birthday.Month).Select(g => (g.Key, g.Count())).OrderBy(x => x.Key); //!

        Assert.Equal(new[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12 }, result.Select(r => r.Month));
        Assert.Equal(4, result.Single(r => r.Month == 7).Count);
    }
}
