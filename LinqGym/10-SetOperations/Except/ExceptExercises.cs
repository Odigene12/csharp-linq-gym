namespace LinqGym.SetOperations;

/// <summary>
/// Except - the distinct elements of the first sequence that are NOT in the second. Order follows the first sequence.
/// Not symmetric: A.Except(B) != B.Except(A).
/// </summary>
public class ExceptExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_AMinusB()
    {
        // Task: the values in Data.SetA that are not in Data.SetB.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 2, 3 }, result);
    }

    [Fact]
    public void Easy_02_BMinusA()
    {
        // Task: the values in Data.SetB that are not in Data.SetA.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 6, 7 }, result);
    }

    [Fact]
    public void Easy_03_RemoveSpecificValues()
    {
        // Task: Data.Numbers without any 8 or 3 (and, being a set operation, without other duplicates too).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 5, 1, 9, 2, 7, 10 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ExceptIgnoringCase()
    {
        // Task: tags in TagsA that are not in TagsB, ignoring case.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "csharp" }, result);
    }

    [Fact]
    public void Medium_05_StudentsWithNoEnrollments()
    {
        // Task: students not present in the enrolled set. Build the enrolled students with Data.Student(e.StudentId)
        // so the objects are the same references that live in Data.Students.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 2, 12, 17 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_InstructorsWhoAreNeverPrimary()
    {
        // Task: instructors who are not the PrimaryInstructor of any cohort (Ids).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 4, 5 }, result);
    }

    [Fact]
    public void Hard_07_ExceptAlsoDeduplicatesTheFirstSequence()
    {
        // Task: [1, 1, 2, 2, 3] except [3] - notice the duplicates of 1 and 2 collapse.
        var source = new[] { 1, 1, 2, 2, 3 };

        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 2 }, result);
    }
}
