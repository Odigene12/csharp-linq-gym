namespace LinqGym.Partitioning;

/// <summary>
/// Skip - bypass the first N elements and yield the rest. Never throws.
/// </summary>
public class SkipExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_SkipThree()
    {
        // Task: everything after the first three numbers.
        IEnumerable<int> result = Data.Numbers.Skip(3); //!

        Assert.Equal(new[] { 1, 9, 2, 8, 7, 3, 10 }, result);
    }

    [Fact]
    public void Easy_02_LastFiveStudents()
    {
        // Task: skip the first 15 students to get the last five.
        IEnumerable<Student> result = Data.Students.Skip(15); //!

        Assert.Equal(new[] { 16, 17, 18, 19, 20 }, result.Select(s => s.Id));
    }

    [Fact]
    public void Easy_03_SkipMoreThanAvailable()
    {
        // Task: skipping more than exists yields an empty sequence (no exception).
        IEnumerable<int> result = Data.Numbers.Skip(100); //!

        LinqAssert.IsEmpty(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_SkipZero()
    {
        // Task: Skip(0) yields everything.
        IEnumerable<int> result = Data.Numbers.Skip(0); //!

        Assert.Equal(Data.Numbers, result);
    }

    [Fact]
    public void Medium_05_AllButTheFirstWord()
    {
        // Task: every word except the first.
        IEnumerable<string> result = Data.Words.Skip(1); //!

        Assert.Equal(9, result.Count());
        Assert.Equal("Banana", result.First());
    }

    [Fact]
    public void Medium_06_SecondOldestStudent()
    {
        // Task: the second-oldest student (sort by Birthday, skip the oldest, take the next).
        Student result = Data.Students.OrderBy(s => s.Birthday).Skip(1).First(); //!

        Assert.Equal("Quincy", result.FirstName);
    }

    [Fact]
    public void Medium_07_NegativeCountSkipsNothing()
    {
        // Task: Skip(-5) behaves like Skip(0).
        IEnumerable<int> result = Data.Numbers.Skip(-5); //!

        Assert.Equal(10, result.Count());
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_ThirdPageOfFour()
    {
        // Task: paging - page 3 (1-based) when the page size is 4. Only two elements remain on that page.
        int page = 3, pageSize = 4;

        IEnumerable<int> result = Data.Numbers.Skip((page - 1) * pageSize).Take(pageSize); //!

        Assert.Equal(new[] { 3, 10 }, result);
    }

    [Fact]
    public void Hard_09_SkipIsDeferred()
    {
        // Task: build a Skip(1) query over `list`; the element added afterwards must be included.
        var list = new List<int> { 1, 2, 3 };

        IEnumerable<int> query = list.Skip(1); //!

        list.Add(4);
        Assert.Equal(new[] { 2, 3, 4 }, query);
    }

    [Fact]
    public void Hard_10_AllButTheTwoLargest()
    {
        // Task: Data.Numbers sorted descending, without the two largest values.
        IEnumerable<int> result = Data.Numbers.OrderByDescending(n => n).Skip(2); //!

        Assert.Equal(new[] { 8, 8, 7, 5, 3, 3, 2, 1 }, result);
    }
}
