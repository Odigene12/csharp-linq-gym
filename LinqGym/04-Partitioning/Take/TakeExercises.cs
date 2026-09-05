namespace LinqGym.Partitioning;

/// <summary>
/// Take - the first N elements. Never throws for N larger than the sequence, or for N &lt;= 0 (returns empty).
/// </summary>
public class TakeExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_FirstThreeNumbers()
    {
        // Task: the first three values of Data.Numbers.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 5, 3, 8 }, result);
    }

    [Fact]
    public void Easy_02_FirstFiveStudentNames()
    {
        // Task: the first names of the first five students.
        IEnumerable<string> result = TODO;

        Assert.Equal(new[] { "Anne", "Bobbie", "Carrie", "Derek", "Ethel" }, result);
    }

    [Fact]
    public void Easy_03_TakeMoreThanAvailable()
    {
        // Task: ask for 100 numbers. Take never throws - you just get everything there is.
        IEnumerable<int> result = TODO;

        Assert.Equal(10, result.Count());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_TakeZero()
    {
        // Task: Take(0) yields nothing.
        IEnumerable<int> result = TODO;

        LinqAssert.IsEmpty(result);
    }

    [Fact]
    public void Medium_05_TakeARange()
    {
        // Task: Take accepts a Range (.NET 6+). Return elements at positions 2, 3 and 4 with a single Take call.
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 8, 1, 9 }, result);
    }

    [Fact]
    public void Medium_06_TakeFromTheEndWithARange()
    {
        // Task: the last three numbers using Take with a range that starts from the end (^3..).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 7, 3, 10 }, result);
    }

    [Fact]
    public void Medium_07_ThreeOldestStudents()
    {
        // Task: the three oldest students (order by Birthday, then Take).
        IEnumerable<Student> result = TODO;

        Assert.Equal(new[] { 18, 17, 19 }, result.Select(s => s.Id));
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_NegativeCountIsEmpty()
    {
        // Task: Take(-1) is treated like Take(0): empty, no exception.
        IEnumerable<int> result = TODO;

        LinqAssert.IsEmpty(result);
    }

    [Fact]
    public void Hard_09_SecondPageOfThree()
    {
        // Task: paging - the second page when the page size is 3 (elements at positions 3, 4, 5).
        IEnumerable<int> result = TODO;

        Assert.Equal(new[] { 1, 9, 2 }, result);
    }

    [Fact]
    public void Hard_10_TakeOnlyPullsWhatItNeeds()
    {
        // Task: project every number through a selector that increments `evaluated`, then Take(2).
        // Because everything is lazy, only two elements should ever flow through the selector.
        int evaluated = 0;

        IEnumerable<int> query = TODO;

        Assert.Equal(new[] { 5, 3 }, query.ToList());
        Assert.Equal(2, evaluated);
    }
}
