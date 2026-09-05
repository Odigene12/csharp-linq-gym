namespace LinqGym.Data;

/// <summary>
/// The practice dataset. A fresh instance is created for every test, so nothing you do in one
/// exercise can leak into another. Open <c>docs/DATASET.md</c> for a printable reference table.
/// </summary>
public sealed class SchoolData
{
    // ───────────────────────── Primitive collections ─────────────────────────

    /// <summary>10 ints with duplicates (8 and 3 appear twice). Sum = 56.</summary>
    public List<int> Numbers { get; } = [5, 3, 8, 1, 9, 2, 8, 7, 3, 10];

    /// <summary>10 fruit names with mixed casing and duplicates.</summary>
    public List<string> Words { get; } =
        ["apple", "Banana", "cherry", "apple", "date", "banana", "Elderberry", "fig", "APPLE", "grape"];

    /// <summary>6 prices; 5.49 appears twice. Sum = 194.46.</summary>
    public List<decimal> Prices { get; } = [19.99m, 5.49m, 120.00m, 42.50m, 5.49m, 0.99m];

    /// <summary>7 readings. Sum = 512.4, average = 73.2.</summary>
    public List<double> Temperatures { get; } = [72.5, 68.0, 75.2, 80.1, 66.4, 71.9, 78.3];

    /// <summary>Scores with two nulls. Non-null sum = 345, non-null average = 86.25.</summary>
    public List<int?> NullableScores { get; } = [90, null, 85, null, 70, 100];

    /// <summary>A heterogeneous bag for OfType / Cast practice.</summary>
    public object?[] MixedBag { get; } = [1, "one", 2.5, null, 3, "three", 4L, true, 5, "five"];

    /// <summary>A jagged "matrix" for SelectMany practice. 9 values, sum = 45.</summary>
    public List<int[]> Matrix { get; } = [[1, 2, 3], [4, 5], [6, 7, 8, 9]];

    /// <summary>Two small int sets for Union / Intersect / Except.</summary>
    public List<int> SetA { get; } = [1, 2, 3, 4, 5, 5];
    public List<int> SetB { get; } = [4, 5, 6, 7, 7];

    /// <summary>Two tag lists that only match when compared case-insensitively.</summary>
    public List<string> TagsA { get; } = ["csharp", "LINQ", "dotnet"];
    public List<string> TagsB { get; } = ["linq", "Dotnet", "azure"];

    /// <summary>An empty list, for testing how methods behave with no elements.</summary>
    public List<int> Empty { get; } = [];

    // ───────────────────────── Entities ─────────────────────────

    public List<Student> Students { get; }
    public List<Instructor> Instructors { get; }
    public List<Cohort> Cohorts { get; }
    public List<Course> Courses { get; }
    public List<Enrollment> Enrollments { get; }

    // Convenience lookups (plain indexers, not LINQ — feel free to use them in your answers).
    public Student Student(int id) => Students[id - 1];
    public Instructor Instructor(int id) => Instructors[id - 1];
    public Cohort Cohort(int id) => Cohorts[id - 1];
    public Course Course(int id) => Courses[id - 1];

    public SchoolData()
    {
        Students =
        [
            new() { Id = 1,  FirstName = "Anne",     LastName = "Appleton",   Birthday = new(1978, 2, 4),   Active = true,  City = "Nashville",   Email = "anne@example.com",     CohortId = 1 },
            new() { Id = 2,  FirstName = "Bobbie",   LastName = "Bradshaw",   Birthday = new(1988, 7, 14),  Active = false, City = "Nashville",   Email = null,                   CohortId = 1 },
            new() { Id = 3,  FirstName = "Carrie",   LastName = "Cooper",     Birthday = new(1996, 2, 4),   Active = true,  City = "Memphis",     Email = "carrie@example.com",   CohortId = 1 },
            new() { Id = 4,  FirstName = "Derek",    LastName = "Dickinson",  Birthday = new(1984, 9, 29),  Active = true,  City = "Nashville",   Email = "derek@example.com",    CohortId = 1 },
            new() { Id = 5,  FirstName = "Ethel",    LastName = "Erikson",    Birthday = new(1971, 11, 24), Active = true,  City = "Knoxville",   Email = "ethel@example.com",    CohortId = 1 },
            new() { Id = 6,  FirstName = "Francis",  LastName = "Foster",     Birthday = new(1983, 4, 18),  Active = true,  City = "Memphis",     Email = "francis@example.com",  CohortId = 2 },
            new() { Id = 7,  FirstName = "Gary",     LastName = "Gaines",     Birthday = new(1968, 7, 14),  Active = true,  City = "Chattanooga", Email = null,                   CohortId = 2 },
            new() { Id = 8,  FirstName = "Howard",   LastName = "Harrison",   Birthday = new(1973, 8, 24),  Active = true,  City = "Nashville",   Email = "howard@example.com",   CohortId = 2 },
            new() { Id = 9,  FirstName = "Ingrid",   LastName = "Ibanez",     Birthday = new(1991, 1, 8),   Active = true,  City = "Knoxville",   Email = "ingrid@example.com",   CohortId = 2 },
            new() { Id = 10, FirstName = "Jacob",    LastName = "Jiminez",    Birthday = new(1984, 5, 26),  Active = true,  City = "Nashville",   Email = "jacob@example.com",    CohortId = 2 },
            new() { Id = 11, FirstName = "Kate",     LastName = "Kristov",    Birthday = new(1987, 8, 13),  Active = false, City = "Memphis",     Email = "kate@example.com",     CohortId = 3 },
            new() { Id = 12, FirstName = "Louis",    LastName = "Lancaster",  Birthday = new(1978, 3, 24),  Active = false, City = "Nashville",   Email = null,                   CohortId = 3 },
            new() { Id = 13, FirstName = "Matt",     LastName = "Michaelson", Birthday = new(1972, 11, 14), Active = true,  City = "Chattanooga", Email = "matt@example.com",     CohortId = 3 },
            new() { Id = 14, FirstName = "Nancy",    LastName = "Newton",     Birthday = new(1976, 7, 31),  Active = true,  City = "Nashville",   Email = "nancy@example.com",    CohortId = 3 },
            new() { Id = 15, FirstName = "Ophelia",  LastName = "Otterson",   Birthday = new(1984, 12, 24), Active = true,  City = "Knoxville",   Email = "ophelia@example.com",  CohortId = 3 },
            new() { Id = 16, FirstName = "Paul",     LastName = "Pritchard",  Birthday = new(1989, 1, 28),  Active = true,  City = "Memphis",     Email = "paul@example.com",     CohortId = 4 },
            new() { Id = 17, FirstName = "Quincy",   LastName = "Queensland", Birthday = new(1958, 8, 3),   Active = false, City = "Nashville",   Email = null,                   CohortId = 4 },
            new() { Id = 18, FirstName = "Richard",  LastName = "Ridley",     Birthday = new(1948, 10, 31), Active = true,  City = "Chattanooga", Email = "richard@example.com",  CohortId = 4 },
            new() { Id = 19, FirstName = "Steve",    LastName = "Southard",   Birthday = new(1965, 7, 8),   Active = true,  City = "Nashville",   Email = "steve@example.com",    CohortId = 4 },
            new() { Id = 20, FirstName = "Terrence", LastName = "Thompson",   Birthday = new(1989, 10, 19), Active = true,  City = "Knoxville",   Email = "terrence@example.com", CohortId = 4 },
        ];

        Instructors =
        [
            new() { Id = 1, FirstName = "Kate",    LastName = "Williams",           Birthday = new(1987, 8, 13), Active = true,  Specialty = "C#" },
            new() { Id = 2, FirstName = "Jurnell", LastName = "Cockhren",           Birthday = new(1983, 10, 5), Active = true,  Specialty = "JavaScript" },
            new() { Id = 3, FirstName = "Blaise",  LastName = "Gratton",            Birthday = new(1989, 3, 2),  Active = true,  Specialty = "C#" },
            new() { Id = 4, FirstName = "Terry",   LastName = "TerribleInstructor", Birthday = new(1975, 9, 2),  Active = false, Specialty = "Java" },
            new() { Id = 5, FirstName = "Jason",   LastName = "JavaFanBoy",         Birthday = new(1986, 6, 16), Active = true,  Specialty = "Java" },
            new() { Id = 6, FirstName = "Zachary", LastName = "Zohan",              Birthday = new(2298, 1, 1),  Active = true,  Specialty = "Quantum" }, // yes, born in the future
        ];

        Cohorts =
        [
            new()
            {
                Id = 1, Name = "Evening Five", Active = true, FullTime = false, StartDate = new(2025, 1, 13),
                Students = Students[0..5], PrimaryInstructor = Instructor(2), JuniorInstructors = [Instructor(1), Instructor(3)],
            },
            new()
            {
                Id = 2, Name = "Cohort of the Future", Active = false, FullTime = true, StartDate = new(2024, 6, 3),
                Students = Students[5..10], PrimaryInstructor = Instructor(6), JuniorInstructors = [Instructor(5), Instructor(4)],
            },
            new()
            {
                Id = 3, Name = "Evening Ninja Warriors", Active = true, FullTime = false, StartDate = new(2025, 3, 10),
                Students = Students[10..15], PrimaryInstructor = Instructor(3), JuniorInstructors = [Instructor(4), Instructor(6), Instructor(1)],
            },
            new()
            {
                Id = 4, Name = "Day Backgammon Geeks", Active = false, FullTime = true, StartDate = new(2024, 9, 2),
                Students = Students[15..20], PrimaryInstructor = Instructor(1), JuniorInstructors = [Instructor(5), Instructor(3)],
            },
        ];

        Courses =
        [
            new() { Id = 1, Code = "CS101", Title = "Intro to C#",        Credits = 3, Category = "Backend",  InstructorId = 1 },
            new() { Id = 2, Code = "CS201", Title = "Advanced C#",        Credits = 4, Category = "Backend",  InstructorId = 3 },
            new() { Id = 3, Code = "JS101", Title = "JavaScript Basics",  Credits = 3, Category = "Frontend", InstructorId = 2 },
            new() { Id = 4, Code = "JS201", Title = "React Fundamentals", Credits = 5, Category = "Frontend", InstructorId = 2 },
            new() { Id = 5, Code = "DB101", Title = "SQL & Databases",    Credits = 3, Category = "Data",     InstructorId = 5 },
            new() { Id = 6, Code = "DB201", Title = "Entity Framework",   Credits = 4, Category = "Data",     InstructorId = 1 },
            new() { Id = 7, Code = "QC999", Title = "Quantum Computing",  Credits = 5, Category = "Research", InstructorId = 6 },
            new() { Id = 8, Code = "SE100", Title = "Software Ethics",    Credits = 2, Category = "General",  InstructorId = null },
        ];

        // Students 2, 12 and 17 have no enrollments. Course 7 (QC999) has no enrollments.
        // Three enrollments (ids 7, 21, 23) are still in progress (Grade == null).
        Enrollments =
        [
            new() { Id = 1,  StudentId = 1,  CourseId = 1, Grade = 92,   EnrolledOn = new(2025, 1, 15) },
            new() { Id = 2,  StudentId = 1,  CourseId = 2, Grade = 85,   EnrolledOn = new(2025, 4, 1) },
            new() { Id = 3,  StudentId = 1,  CourseId = 5, Grade = 78,   EnrolledOn = new(2025, 4, 1) },
            new() { Id = 4,  StudentId = 3,  CourseId = 1, Grade = 88,   EnrolledOn = new(2025, 1, 15) },
            new() { Id = 5,  StudentId = 3,  CourseId = 3, Grade = 95,   EnrolledOn = new(2025, 4, 1) },
            new() { Id = 6,  StudentId = 4,  CourseId = 1, Grade = 74,   EnrolledOn = new(2025, 1, 15) },
            new() { Id = 7,  StudentId = 4,  CourseId = 2, Grade = null, EnrolledOn = new(2025, 9, 1) },
            new() { Id = 8,  StudentId = 5,  CourseId = 5, Grade = 81,   EnrolledOn = new(2025, 1, 15) },
            new() { Id = 9,  StudentId = 5,  CourseId = 6, Grade = 90,   EnrolledOn = new(2025, 4, 1) },
            new() { Id = 10, StudentId = 6,  CourseId = 3, Grade = 67,   EnrolledOn = new(2024, 6, 5) },
            new() { Id = 11, StudentId = 6,  CourseId = 4, Grade = 72,   EnrolledOn = new(2024, 9, 1) },
            new() { Id = 12, StudentId = 7,  CourseId = 1, Grade = 59,   EnrolledOn = new(2024, 6, 5) },
            new() { Id = 13, StudentId = 8,  CourseId = 1, Grade = 83,   EnrolledOn = new(2024, 6, 5) },
            new() { Id = 14, StudentId = 8,  CourseId = 6, Grade = 88,   EnrolledOn = new(2024, 9, 1) },
            new() { Id = 15, StudentId = 9,  CourseId = 3, Grade = 91,   EnrolledOn = new(2024, 6, 5) },
            new() { Id = 16, StudentId = 9,  CourseId = 4, Grade = 94,   EnrolledOn = new(2024, 9, 1) },
            new() { Id = 17, StudentId = 9,  CourseId = 8, Grade = 100,  EnrolledOn = new(2024, 11, 1) },
            new() { Id = 18, StudentId = 10, CourseId = 5, Grade = 77,   EnrolledOn = new(2024, 9, 1) },
            new() { Id = 19, StudentId = 11, CourseId = 1, Grade = 65,   EnrolledOn = new(2025, 3, 12) },
            new() { Id = 20, StudentId = 13, CourseId = 2, Grade = 89,   EnrolledOn = new(2025, 3, 12) },
            new() { Id = 21, StudentId = 13, CourseId = 6, Grade = null, EnrolledOn = new(2025, 9, 1) },
            new() { Id = 22, StudentId = 14, CourseId = 3, Grade = 70,   EnrolledOn = new(2025, 3, 12) },
            new() { Id = 23, StudentId = 14, CourseId = 4, Grade = null, EnrolledOn = new(2025, 9, 1) },
            new() { Id = 24, StudentId = 15, CourseId = 5, Grade = 84,   EnrolledOn = new(2025, 3, 12) },
            new() { Id = 25, StudentId = 16, CourseId = 1, Grade = 96,   EnrolledOn = new(2024, 9, 4) },
            new() { Id = 26, StudentId = 16, CourseId = 2, Grade = 91,   EnrolledOn = new(2024, 11, 1) },
            new() { Id = 27, StudentId = 18, CourseId = 8, Grade = 88,   EnrolledOn = new(2024, 9, 4) },
            new() { Id = 28, StudentId = 19, CourseId = 5, Grade = 62,   EnrolledOn = new(2024, 9, 4) },
            new() { Id = 29, StudentId = 19, CourseId = 6, Grade = 71,   EnrolledOn = new(2024, 11, 1) },
            new() { Id = 30, StudentId = 20, CourseId = 3, Grade = 79,   EnrolledOn = new(2024, 9, 4) },
            new() { Id = 31, StudentId = 20, CourseId = 4, Grade = 86,   EnrolledOn = new(2024, 11, 1) },
            new() { Id = 32, StudentId = 10, CourseId = 1, Grade = 80,   EnrolledOn = new(2024, 6, 5) },
        ];
    }
}
