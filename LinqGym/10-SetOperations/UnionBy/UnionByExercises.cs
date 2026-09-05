namespace LinqGym.SetOperations;

/// <summary>
/// UnionBy (.NET 6+) - Union, but "same" means "same KEY". Keeps the first element per key.
/// </summary>
public class UnionByExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_FirstStudentPerCityAcrossTwoCohorts()
    {
        // Task: students of cohort 1 union-by-City students of cohort 2 (Ids of the survivors).
        IEnumerable<int> result = Data.Cohort(1).Students.UnionBy(Data.Cohort(2).Students, s => s.City).Select(s => s.Id); //!

        Assert.Equal(new[] { 1, 3, 5, 7 }, result);
    }

    [Fact]
    public void Easy_02_UnionByLowercase()
    {
        // Task: Data.Words union-by lower-cased value with ["KIWI", "Apple"]; only KIWI is new.
        IEnumerable<string> result = Data.Words.UnionBy(new[] { "KIWI", "Apple" }, w => w.ToLowerInvariant()); //!

        Assert.Equal(8, result.Count());
        Assert.Equal("KIWI", result.Last());
    }

    [Fact]
    public void Easy_03_UnionByLastDigit()
    {
        // Task: Data.Numbers union-by last digit (n % 10) with [12, 22, 13] - nothing new is added.
        IEnumerable<int> result = Data.Numbers.UnionBy(new[] { 12, 22, 13 }, n => n % 10); //!

        Assert.Equal(new[] { 5, 3, 8, 1, 9, 2, 7, 10 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_UnionByWithAComparer()
    {
        // Task: TagsA union-by the tag itself with TagsB, ignoring case in the key comparison.
        IEnumerable<string> result = Data.TagsA.UnionBy(Data.TagsB, t => t, StringComparer.OrdinalIgnoreCase); //!

        Assert.Equal(4, result.Count());
    }

    [Fact]
    public void Medium_05_MergeCourseListsByCode()
    {
        // Task: Data.Courses union-by Code with `incoming` - the duplicate CS101 is ignored, ML101 is added.
        var incoming = new List<Course>
        {
            new() { Id = 98, Code = "CS101", Title = "Duplicate", Credits = 1, Category = "Backend" },
            new() { Id = 99, Code = "ML101", Title = "Machine Learning", Credits = 4, Category = "Data" },
        };

        IEnumerable<Course> result = Data.Courses.UnionBy(incoming, c => c.Code); //!

        Assert.Equal(9, result.Count());
        Assert.Equal("Intro to C#", result.First(c => c.Code == "CS101").Title);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_OneInstructorPerSpecialty()
    {
        // Task: primary instructors union-by Specialty with all junior instructors (Ids).
        IEnumerable<int> result = Data.Cohorts.Select(c => c.PrimaryInstructor).UnionBy(Data.Cohorts.SelectMany(c => c.JuniorInstructors), i => i.Specialty).Select(i => i.Id); //!

        Assert.Equal(new[] { 2, 6, 3, 5 }, result);
    }

    [Fact]
    public void Hard_07_FirstEnrollmentPerStudentAcrossYears()
    {
        // Task: 2024 enrollments union-by StudentId with 2025 enrollments - one enrollment per student, 17 in total.
        IEnumerable<Enrollment> result = Data.Enrollments.Where(e => e.EnrolledOn.Year == 2024).UnionBy(Data.Enrollments.Where(e => e.EnrolledOn.Year == 2025), e => e.StudentId); //!

        Assert.Equal(17, result.Count());
        Assert.Equal(10, result.First().Id);
    }
}
