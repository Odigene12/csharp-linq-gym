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
        IEnumerable<(string Name, int ActiveStudents, double AverageAge)> result = TODO;

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
        IEnumerable<CourseStats> result = TODO;

        Assert.Equal(new CourseStats("CS101", 8, 79.625), result.First());
        Assert.Equal(new CourseStats("QC999", 0, 0), result.ElementAt(6));
        Assert.Equal(new CourseStats("SE100", 2, 94), result.Last());
    }

    [Fact]
    public void Report_03_InstructorWorkload()
    {
        // Task: for each instructor: (FullName, CourseCount, DistinctStudentCount across their courses),
        // ordered by DistinctStudentCount descending, then FullName ascending.
        IEnumerable<(string Name, int Courses, int Students)> result = TODO;

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
        IEnumerable<(string City, int Students, double ActiveRate)> result = TODO;

        Assert.Equal(new[] { "Chattanooga", "Knoxville", "Memphis", "Nashville" }, result.Select(r => r.City));
        Assert.Equal(0.75, result.ElementAt(2).ActiveRate);
    }

    [Fact]
    public void Report_05_TopThreeStudentsByAverageGrade()
    {
        // Task: the first names of the three students with the highest average Grade, counting only students with
        // at least TWO graded enrollments.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "Ingrid", "Paul", "Carrie" }, result);
    }

    [Fact]
    public void Report_06_StudentsWhoTookEveryBackendCourse()
    {
        // Task: first names of students enrolled in ALL courses of the "Backend" category.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "Anne", "Derek", "Paul" }, result);
    }

    [Fact]
    public void Report_07_GradeDistribution()
    {
        // Task: how many graded enrollments fall in each band: "A" (90+), "B" (80-89), "C" (70-79), "F" (below 70), ordered by band.
        IEnumerable<(string Band, int Count)> result = TODO;

        Assert.Equal(new[] { ("A", 8), ("B", 10), ("C", 7), ("F", 4) }, result);
    }

    [Fact]
    public void Report_08_BirthdayCalendar()
    {
        // Task: (Month, number of students born that month) for every month that has at least one student, ordered by month.
        IEnumerable<(int Month, int Count)> result = TODO;

        Assert.Equal(new[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12 }, result.Select(r => r.Month));
        Assert.Equal(4, result.Single(r => r.Month == 7).Count);
    }
}
