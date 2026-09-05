namespace LinqGym.Data;

/// <summary>
/// Shared base for people in the school. Note: entities use <b>reference equality</b>
/// (the default for classes). Two Student objects with identical data are still "different"
/// to LINQ methods such as Distinct, Contains, Except and GroupBy unless you supply a comparer.
/// </summary>
public abstract class Person
{
    public required int Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required DateOnly Birthday { get; init; }
    public required bool Active { get; init; }

    public string FullName => $"{FirstName} {LastName}";

    /// <summary>Age in whole years on <see cref="Clock.Today"/> (a fixed date so tests are deterministic).</summary>
    public int Age => Clock.AgeOn(Clock.Today, Birthday);

    public override string ToString() => $"{GetType().Name}#{Id} {FullName}";
}

public sealed class Student : Person
{
    public required string City { get; init; }
    /// <summary>Null for students who never supplied one - practise null handling.</summary>
    public string? Email { get; init; }
    public required int CohortId { get; init; }
}

public sealed class Instructor : Person
{
    public required string Specialty { get; init; }
}

public sealed class Cohort
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required bool FullTime { get; init; }
    public required bool Active { get; init; }
    public required DateOnly StartDate { get; init; }
    public required List<Student> Students { get; init; }
    public required Instructor PrimaryInstructor { get; init; }
    public required List<Instructor> JuniorInstructors { get; init; }

    public override string ToString() => $"Cohort#{Id} {Name}";
}

public sealed class Course
{
    public required int Id { get; init; }
    public required string Code { get; init; }
    public required string Title { get; init; }
    public required int Credits { get; init; }
    public required string Category { get; init; }
    /// <summary>Null when no instructor has been assigned yet.</summary>
    public int? InstructorId { get; init; }

    public override string ToString() => $"Course#{Id} {Code}";
}

public sealed class Enrollment
{
    public required int Id { get; init; }
    public required int StudentId { get; init; }
    public required int CourseId { get; init; }
    /// <summary>Null while the course is still in progress.</summary>
    public int? Grade { get; init; }
    public required DateOnly EnrolledOn { get; init; }

    public override string ToString() => $"Enrollment#{Id} S{StudentId}/C{CourseId}={Grade?.ToString() ?? "in progress"}";
}

/// <summary>A small record used by projection exercises. Records have <b>value equality</b>.</summary>
public sealed record StudentSummary(string FullName, string City, int Age);

/// <summary>Another record for grouping/aggregation exercises.</summary>
public sealed record CourseStats(string Code, int EnrollmentCount, double AverageGrade);

/// <summary>Fixed "today" so that age-based exercises never drift as real time passes.</summary>
public static class Clock
{
    public static readonly DateOnly Today = new(2026, 1, 1);

    public static int AgeOn(DateOnly on, DateOnly birthday)
    {
        var age = on.Year - birthday.Year;
        if (birthday.DayOfYear > on.DayOfYear) age--;
        return age;
    }
}
