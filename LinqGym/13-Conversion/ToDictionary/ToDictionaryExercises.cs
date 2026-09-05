namespace LinqGym.Conversion;

/// <summary>
/// ToDictionary - materialize into a Dictionary&lt;TKey, TValue&gt;. Keys must be UNIQUE and non-null, or it throws.
/// Compare with ToLookup, which allows many values per key and never throws on lookup.
/// </summary>
public class ToDictionaryExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_StudentsById()
    {
        // Task: a dictionary of students keyed by Id (the element itself is the value).
        Dictionary<int, Student> result = TODO;

        Assert.Equal("Gary", result[7].FirstName);
        Assert.Equal(20, result.Count);
    }

    [Fact]
    public void Easy_02_CourseTitlesByCode()
    {
        // Task: Code -> Title (use the key AND value selector overload).
        Dictionary<string, string> result = TODO;

        Assert.Equal("React Fundamentals", result["JS201"]);
    }

    [Fact]
    public void Easy_03_SquaresOfDistinctNumbers()
    {
        // Task: n -> n * n for the distinct values of Data.Numbers.
        Dictionary<int, int> result = TODO;

        Assert.Equal(81, result[9]);
        Assert.Equal(8, result.Count);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_DuplicateKeysThrow()
    {
        // Task: Data.Numbers keyed by value has duplicates (8 and 3) - ToDictionary throws ArgumentException.
        Assert.Throws<ArgumentException>(() =>
        {
            Dictionary<int, int> result = TODO;
        });
    }

    [Fact]
    public void Medium_05_CaseInsensitiveKeys()
    {
        // Task: courses keyed by Code with StringComparer.OrdinalIgnoreCase so that "cs101" also works.
        Dictionary<string, Course> result = TODO;

        Assert.Equal("Intro to C#", result["cs101"].Title);
    }

    [Fact]
    public void Medium_06_DictionaryFromGroups()
    {
        // Task: City -> number of students (GroupBy then ToDictionary).
        Dictionary<string, int> result = TODO;

        Assert.Equal(9, result["Nashville"]);
    }

    [Fact]
    public void Medium_07_DictionaryFromKeyValuePairs()
    {
        // Task: CountBy yields KeyValuePairs; the .NET 8+ ToDictionary() overload turns them straight into a dictionary.
        Dictionary<string, int> result = TODO;

        Assert.Equal(4, result["Memphis"]);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_08_DictionaryOfLists()
    {
        // Task: City -> list of first names.
        Dictionary<string, List<string>> result = TODO;

        Assert.Equal(new[] { "Gary", "Matt", "Richard" }, result["Chattanooga"]);
    }

    [Fact]
    public void Hard_09_NullKeysThrow()
    {
        // Task: keying students by Email fails with ArgumentNullException because some emails are null.
        Assert.Throws<ArgumentNullException>(() =>
        {
            Dictionary<string, Student> result = TODO;
        });
    }

    [Fact]
    public void Hard_10_UseADictionaryForFastLookups()
    {
        // Task: build a courses-by-Id dictionary once, then total the Credits of every enrollment through it.
        Dictionary<int, Course> byId = TODO;
        int totalCredits = TODO;

        Assert.Equal(110, totalCredits);
    }
}
