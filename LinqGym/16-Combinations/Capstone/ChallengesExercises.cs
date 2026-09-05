namespace LinqGym.Combinations;

/// <summary>
/// Capstone, part 2: algorithmic puzzles solved with LINQ. If you can do these comfortably you are an advanced LINQ user.
/// </summary>
public class ChallengesExercises : LinqExercise
{
    [Fact]
    public void Challenge_01_LongestIncreasingRun()
    {
        // Task: the length of the longest run of strictly increasing consecutive values in Data.Numbers
        // (5 | 3 8 | 1 9 | 2 8 | 7 | 3 10 -> 2). Hint: Aggregate with a (Best, Current, Previous) tuple.
        int result = Data.Numbers.Aggregate((Best: 0, Cur: 0, Prev: int.MinValue), (acc, n) => { var cur = n > acc.Prev ? acc.Cur + 1 : 1; return (Math.Max(acc.Best, cur), cur, n); }).Best; //!

        Assert.Equal(2, result);
    }

    [Fact]
    public void Challenge_02_AnagramGroups()
    {
        // Task: group `words` into anagram groups (same letters, any order) and return the groups that have more than one word.
        var words = new[] { "listen", "silent", "enlist", "google", "gooegl", "cat" };

        IEnumerable<IGrouping<string, string>> result = words.GroupBy(w => new string(w.Order().ToArray())).Where(g => g.Count() > 1); //!

        Assert.Equal(2, result.Count());
        Assert.Equal(3, result.Max(g => g.Count()));
    }

    [Fact]
    public void Challenge_03_TopTwoWordsIgnoringCase()
    {
        // Task: the two most frequent words in Data.Words ignoring case, as (lowercase word, count), most frequent first.
        IEnumerable<(string Word, int Count)> result = Data.Words.GroupBy(w => w.ToLowerInvariant()).Select(g => (g.Key, g.Count())).OrderByDescending(x => x.Item2).Take(2); //!

        Assert.Equal(new[] { ("apple", 3), ("banana", 2) }, result);
    }

    [Fact]
    public void Challenge_04_Pivot()
    {
        // Task: a nested dictionary City -> (Active -> count), e.g. result["Nashville"][true] == 6.
        Dictionary<string, Dictionary<bool, int>> result = Data.Students.GroupBy(s => s.City).ToDictionary(g => g.Key, g => g.GroupBy(s => s.Active).ToDictionary(a => a.Key, a => a.Count())); //!

        Assert.Equal(6, result["Nashville"][true]);
        Assert.Equal(3, result["Nashville"][false]);
        Assert.False(result["Knoxville"].ContainsKey(false));
    }

    [Fact]
    public void Challenge_05_PairsThatSumToTen()
    {
        // Task: every pair of DISTINCT values from Data.Numbers (each pair once, in first-seen order) whose sum is 10.
        // Hint: Distinct, then SelectMany with the index overload so the inner sequence starts after the outer element.
        IEnumerable<(int, int)> result = //!{
            Data.Numbers.Distinct().ToList() is var d
                ? d.SelectMany((a, i) => d.Skip(i + 1).Where(b => a + b == 10).Select(b => (a, b)))
                : throw new InvalidOperationException();
        //!}

        Assert.Equal(new[] { (3, 7), (8, 2), (1, 9) }, result);
    }

    [Fact]
    public void Challenge_06_RunningAverage()
    {
        // Task: the running average of Data.Temperatures (average of the first 1, first 2, first 3, ... readings).
        IEnumerable<double> result = Data.Temperatures.Select((t, i) => Data.Temperatures.Take(i + 1).Average()); //!

        Assert.Equal(72.5, result.First(), 6);
        Assert.Equal(70.25, result.ElementAt(1), 6);
        Assert.Equal(71.9, result.ElementAt(2), 6);
        Assert.Equal(73.2, result.Last(), 6);
    }

    [Fact]
    public void Challenge_07_TransposeAMatrix()
    {
        // Task: transpose a 2x3 matrix into a 3x2 one: [[1,2,3],[4,5,6]] -> [[1,4],[2,5],[3,6]].
        var rows = new[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } };

        int[][] result = Enumerable.Range(0, rows[0].Length).Select(col => rows.Select(row => row[col]).ToArray()).ToArray(); //!

        Assert.Equal(new[] { new[] { 1, 4 }, new[] { 2, 5 }, new[] { 3, 6 } }, result);
    }

    [Fact]
    public void Challenge_08_ValuesThatAppearMoreThanOnce()
    {
        // Task: the values that occur more than once in Data.Numbers, ascending.
        IEnumerable<int> result = Data.Numbers.GroupBy(n => n).Where(g => g.Count() > 1).Select(g => g.Key).Order(); //!

        Assert.Equal(new[] { 3, 8 }, result);
    }

    [Fact]
    public void Challenge_09_FormatAHierarchy()
    {
        // Task: for cohort 1 the string "Primary: Jurnell Cockhren; Juniors: Kate Williams, Blaise Gratton".
        string result = $"Primary: {Data.Cohort(1).PrimaryInstructor.FullName}; Juniors: {string.Join(", ", Data.Cohort(1).JuniorInstructors.Select(i => i.FullName))}"; //!

        Assert.Equal("Primary: Jurnell Cockhren; Juniors: Kate Williams, Blaise Gratton", result);
    }

    [Fact]
    public void Challenge_10_MedianGrade()
    {
        // Task: the median of all non-null grades (29 values -> the 15th smallest).
        int result = Data.Enrollments.Where(e => e.Grade.HasValue).Select(e => e.Grade!.Value).Order().ElementAt(14); //!

        Assert.Equal(84, result);
    }
}
