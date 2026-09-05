namespace LinqGym.Support;

/// <summary>
/// Base class for every exercise file.
/// <list type="bullet">
/// <item><see cref="Data"/> is a brand-new <see cref="SchoolData"/> for every test.</item>
/// <item><see cref="TODO"/> is the placeholder you replace with your LINQ expression. Until you do,
/// the test fails with <see cref="NotImplementedException"/>.</item>
/// </list>
/// </summary>
public abstract class LinqExercise
{
    protected SchoolData Data { get; } = new();

    /// <summary>
    /// Replace every <c>TODO</c> with a LINQ expression. It is typed <c>dynamic</c> only so that the
    /// file compiles whatever the expected result type is; your answer should never contain <c>dynamic</c>.
    /// </summary>
    protected static dynamic TODO =>
        throw new NotImplementedException("Replace TODO with your LINQ expression.");
}
