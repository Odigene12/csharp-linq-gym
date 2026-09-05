namespace LinqGym.Support;

/// <summary>Small assertion helpers that read well in exercises.</summary>
public static class LinqAssert
{
    /// <summary>Same elements, any order (duplicates must match too).</summary>
    public static void SameItems<T>(IEnumerable<T> expected, IEnumerable<T> actual)
    {
        var e = expected.ToList();
        var a = actual.ToList();
        var same = e.Count == a.Count
                   && e.GroupBy(x => x).All(g => a.Count(x => Equals(x, g.Key)) == g.Count());
        Assert.True(same,
            $"Expected the same items (any order).\nExpected: [{string.Join(", ", e)}]\nActual:   [{string.Join(", ", a)}]");
    }

    /// <summary>Asserts a sequence is empty, with a readable message.</summary>
    public static void IsEmpty<T>(IEnumerable<T> actual)
    {
        var a = actual.ToList();
        Assert.True(a.Count == 0, $"Expected an empty sequence but got [{string.Join(", ", a)}]");
    }
}
