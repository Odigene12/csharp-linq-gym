namespace LinqGym.Grouping;

/// <summary>
/// ToLookup - like GroupBy, but IMMEDIATE and indexable: lookup[key] returns the elements for that key
/// (or an EMPTY sequence for unknown keys - never an exception, unlike Dictionary).
/// </summary>
public class ToLookupExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_StudentsByCity()
    {
        // Task: a lookup of students keyed by City.
        ILookup<string, Student> result = Data.Students.ToLookup(s => s.City); //!

        Assert.Equal(4, result["Memphis"].Count());
        Assert.Equal(4, result.Count);
    }

    [Fact]
    public void Easy_02_UnknownKeyIsEmptyNotAnError()
    {
        // Task: build the same lookup; indexing with a city nobody lives in yields an empty sequence.
        ILookup<string, Student> result = Data.Students.ToLookup(s => s.City); //!

        LinqAssert.IsEmpty(result["Paris"]);
    }

    [Fact]
    public void Easy_03_EnrollmentsByStudent()
    {
        // Task: enrollments keyed by StudentId.
        ILookup<int, Enrollment> result = Data.Enrollments.ToLookup(e => e.StudentId); //!

        Assert.Equal(3, result[9].Count());
        Assert.Equal(17, result.Count);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ElementSelector()
    {
        // Task: course Titles keyed by Category (use the elementSelector overload).
        ILookup<string, string> result = Data.Courses.ToLookup(c => c.Category, c => c.Title); //!

        Assert.Equal(new[] { "SQL & Databases", "Entity Framework" }, result["Data"]);
    }

    [Fact]
    public void Medium_05_ContainsKey()
    {
        // Task: build the city lookup and test key membership with Contains.
        ILookup<string, Student> lookup = Data.Students.ToLookup(s => s.City); //!

        Assert.True(lookup.Contains("Knoxville"));
        Assert.False(lookup.Contains("Paris"));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_ToLookupIsASnapshot()
    {
        // Task: build a lookup of `list` by parity, then add an element to `list`. The lookup must NOT see it
        // (ToLookup executes immediately, unlike GroupBy).
        var list = new List<int> { 1, 2, 3 };

        ILookup<bool, int> lookup = list.ToLookup(n => n % 2 == 0); //!

        list.Add(4);
        Assert.Equal(new[] { 2 }, lookup[true]);
    }

    [Fact]
    public void Hard_07_LookupAvoidsRepeatedScans()
    {
        // Task: build a lookup of enrollments by CourseId ONCE, then use it to get the enrollment count of every course
        // (including 0 for QC999). Without the lookup you would rescan Data.Enrollments for every course.
        ILookup<int, Enrollment> byCourse = Data.Enrollments.ToLookup(e => e.CourseId); //!
        IEnumerable<int> counts = Data.Courses.Select(c => byCourse[c.Id].Count()); //!

        Assert.Equal(new[] { 8, 4, 5, 4, 5, 4, 0, 2 }, counts);
    }
}
