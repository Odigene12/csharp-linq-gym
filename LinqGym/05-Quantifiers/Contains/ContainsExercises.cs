namespace LinqGym.Quantifiers;

/// <summary>
/// Contains - true if the sequence contains a specific value. Uses the default equality comparer
/// (value equality for primitives/records/strings, REFERENCE equality for classes) unless you pass one.
/// </summary>
public class ContainsExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ContainsNine()
    {
        // Task: does Data.Numbers contain 9?
        bool result = TODO;

        Assert.True(result);
    }

    [Fact]
    public void Easy_02_DoesNotContainFour()
    {
        // Task: does Data.Numbers contain 4?
        bool result = TODO;

        Assert.False(result);
    }

    [Fact]
    public void Easy_03_ContainsApple()
    {
        // Task: does Data.Words contain "apple"?
        bool result = TODO;

        Assert.True(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ContainsIsCaseSensitiveByDefault()
    {
        // Task: "APPLE" is in the list exactly, "Apple" is not.
        bool upper = TODO;
        bool mixed = TODO;

        Assert.True(upper);
        Assert.False(mixed);
    }

    [Fact]
    public void Medium_05_ContainsWithACaseInsensitiveComparer()
    {
        // Task: does Data.Words contain "CHERRY" when case is ignored? Pass StringComparer.OrdinalIgnoreCase.
        bool result = TODO;

        Assert.True(result);
    }

    [Fact]
    public void Medium_06_ReferenceEqualityForClasses()
    {
        // Task: Data.Student(3) is the same object that lives in Data.Students, so Contains finds it.
        // `copy` has identical data but is a different object, so Contains does NOT find it.
        var copy = new Student { Id = 3, FirstName = "Carrie", LastName = "Cooper", Birthday = new(1996, 2, 4), Active = true, City = "Memphis", Email = "carrie@example.com", CohortId = 1 };

        bool original = TODO;
        bool duplicate = TODO;

        Assert.True(original);
        Assert.False(duplicate);
    }

    [Fact]
    public void Medium_07_CohortsWithAGivenJuniorInstructor()
    {
        // Task: cohorts whose JuniorInstructors contain Kate Williams (Data.Instructor(1)).
        IEnumerable<Cohort> result = TODO;

        Assert.Equal(new[] { 1, 3 }, result.Select(c => c.Id));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_ContainsAsAnInFilter()
    {
        // Task: the students whose Id is in `ids` (the LINQ equivalent of SQL's WHERE Id IN (...)).
        var ids = new[] { 2, 4, 6 };

        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { "Bobbie", "Derek", "Francis" }, result.Select(s => s.FirstName));
    }

    [Fact]
    public void Hard_09_ContainsAsANotInFilter()
    {
        // Task: students whose City is NOT one of the given cities.
        var cities = new[] { "Nashville", "Memphis" };

        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { 5, 7, 9, 13, 15, 18, 20 }, result.Select(s => s.Id));
    }

    [Fact]
    public void Hard_10_ContainsWithACustomComparer()
    {
        // Task: `copy` is a different object with the same Id as student 3. Make Contains find it by
        // passing PersonIdComparer.Instance (see Support/Comparers.cs).
        var copy = new Student { Id = 3, FirstName = "Carrie", LastName = "Cooper", Birthday = new(1996, 2, 4), Active = true, City = "Memphis", Email = null, CohortId = 1 };

        bool result = TODO;

        Assert.True(result);
    }
}
