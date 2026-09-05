namespace LinqGym.Partitioning;

/// <summary>
/// TakeWhile - yield elements from the start as long as the predicate is true, then STOP for good
/// (even if later elements would satisfy it again). Compare with Where, which checks every element.
/// </summary>
public class TakeWhileExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_WhileLessThanEight()
    {
        // Task: numbers from the start while they are less than 8.
        IEnumerable<int> result = Data.Numbers.TakeWhile(n => n < 8); //!

        Assert.Equal(new[] { 5, 3 }, result);
    }

    [Fact]
    public void Easy_02_WhileLongerThanFourLetters()
    {
        // Task: words from the start while their Length is greater than 4.
        IEnumerable<string> result = Data.Words.TakeWhile(w => w.Length > 4); //!

        Assert.Equal(new[] { "apple", "Banana", "cherry", "apple" }, result);
    }

    [Fact]
    public void Easy_03_TakeWhileVersusWhere()
    {
        // Task: write both. `takeWhile` stops at the first 9; `where` skips only the 9 and keeps going.
        IEnumerable<int> takeWhile = Data.Numbers.TakeWhile(n => n != 9); //!
        IEnumerable<int> where = Data.Numbers.Where(n => n != 9); //!

        Assert.Equal(new[] { 5, 3, 8, 1 }, takeWhile);
        Assert.Equal(9, where.Count());
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_LeadingActiveStudents()
    {
        // Task: students from the start while they are Active. Bobbie (2nd) is inactive, so only Anne qualifies.
        IEnumerable<Student> result = Data.Students.TakeWhile(s => s.Active); //!

        Assert.Equal(new[] { 1 }, result.Select(s => s.Id));
    }

    [Fact]
    public void Medium_05_TakeWhileWithIndex()
    {
        // Task: use the (element, index) overload: take numbers while each number is greater than its index.
        IEnumerable<int> result = Data.Numbers.TakeWhile((n, i) => n > i); //!

        Assert.Equal(new[] { 5, 3, 8 }, result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_TopGradesFromASortedSequence()
    {
        // Task: enrollments sorted by Grade descending, then take while Grade >= 90.
        // TakeWhile only makes sense on sorted data - here it avoids scanning the whole list.
        IEnumerable<Enrollment> result = Data.Enrollments.OrderByDescending(e => e.Grade).TakeWhile(e => e.Grade >= 90); //!

        Assert.Equal(8, result.Count());
        Assert.Equal(90, result.Last().Grade);
    }

    [Fact]
    public void Hard_07_LeadingRunOfEqualValues()
    {
        // Task: the run of elements at the start that equal the first element.
        var seq = new[] { 7, 7, 7, 3, 7 };

        IEnumerable<int> result = seq.TakeWhile(n => n == seq[0]); //!

        Assert.Equal(new[] { 7, 7, 7 }, result);
    }
}
