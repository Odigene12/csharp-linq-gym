namespace LinqGym.Conversion;

/// <summary>
/// ToList - run the query NOW and copy the results into a new List&lt;T&gt;. The classic way to end deferred execution.
/// </summary>
public class ToListExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_EvenNumbersAsAList()
    {
        // Task: the even numbers as a List<int>.
        List<int> result = Data.Numbers.Where(n => n % 2 == 0).ToList(); //!

        Assert.IsType<List<int>>(result);
        Assert.Equal(new[] { 8, 2, 8, 10 }, result);
    }

    [Fact]
    public void Easy_02_ActiveStudentNames()
    {
        // Task: the first names of active students as a list (then use the Count PROPERTY).
        List<string> result = Data.Students.Where(s => s.Active).Select(s => s.FirstName).ToList(); //!

        Assert.Equal(16, result.Count);
    }

    [Fact]
    public void Easy_03_EmptyQueryGivesAnEmptyListNotNull()
    {
        // Task: students from "Paris" as a list - empty, never null.
        List<Student> result = Data.Students.Where(s => s.City == "Paris").ToList(); //!

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ToListIsASnapshot()
    {
        // Task: materialize "greater than 1" from `source`. Elements added afterwards must NOT appear in the snapshot.
        var source = new List<int> { 1, 2, 3 };

        List<int> snapshot = source.Where(n => n > 1).ToList(); //!

        source.Add(4);
        Assert.Equal(new[] { 2, 3 }, snapshot);
    }

    [Fact]
    public void Medium_05_ToListAlwaysCopies()
    {
        // Task: ToList on a list that already IS a List<int> still returns a NEW list with equal contents.
        List<int> result = Data.Numbers.ToList(); //!

        Assert.NotSame(Data.Numbers, result);
        Assert.Equal(Data.Numbers, result);
    }

    [Fact]
    public void Medium_06_ListsCanBeIndexedAndMutated()
    {
        // Task: the distinct words as a list; then the test adds "kiwi" to it.
        List<string> result = Data.Words.Distinct().ToList(); //!

        result.Add("kiwi");
        Assert.Equal("apple", result[0]);
        Assert.Equal(10, result.Count);
    }

    [Fact]
    public void Medium_07_MaterializeOnceToAvoidReEnumeration()
    {
        // Task: an "expensive" projection is used twice below (Count and Sum). Materialize it with ToList so the selector
        // runs exactly 10 times, not 20.
        int evaluated = 0;

        List<int> materialized = Data.Numbers.Select(n => { evaluated++; return n * 2; }).ToList(); //!

        Assert.Equal(10, materialized.Count());
        Assert.Equal(112, materialized.Sum());
        Assert.Equal(10, evaluated);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_ListOfLists()
    {
        // Task: Data.Matrix as a List<List<int>>.
        List<List<int>> result = Data.Matrix.Select(row => row.ToList()).ToList(); //!

        Assert.Equal(5, result[1][1]);
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void Hard_09_ListOfTuples()
    {
        // Task: (FirstName, Age) pairs for all students, as a list.
        List<(string Name, int Age)> result = Data.Students.Select(s => (s.FirstName, s.Age)).ToList(); //!

        Assert.Equal(("Anne", 47), result[0]);
        Assert.Equal(20, result.Count);
    }

    [Fact]
    public void Hard_10_ToListSurfacesErrorsImmediately()
    {
        // Task: Cast<int> over Data.MixedBag is fine to BUILD (deferred), but ToList runs it and hits the string "one".
        IEnumerable<int> query = Data.MixedBag.Cast<int>(); //!

        Assert.Throws<InvalidCastException>(() =>
        {
            List<int> result = query.ToList(); //!
        });
    }
}
