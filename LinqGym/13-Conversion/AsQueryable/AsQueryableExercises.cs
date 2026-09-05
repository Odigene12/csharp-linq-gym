using System.Linq.Expressions;

namespace LinqGym.Conversion;

/// <summary>
/// AsQueryable - wrap an in-memory sequence as an IQueryable&lt;T&gt;. LINQ operators on IQueryable build EXPRESSION TREES
/// instead of running delegates; a provider (EF Core, for example) translates the tree to SQL. Over plain collections the
/// provider is EnumerableQuery, which just compiles the tree and runs it in memory - useful for tests and for writing
/// code that must work against either source.
/// </summary>
public class AsQueryableExercises : LinqExercise
{
    // ----- Easy -----

    [Fact]
    public void Easy_01_ItIsAnIQueryable()
    {
        // Task: Data.Numbers as an IQueryable<int>.
        IQueryable<int> result = TODO;

        Assert.IsAssignableFrom<IQueryable<int>>(result);
    }

    [Fact]
    public void Easy_02_OperatorsBuildAnExpressionTree()
    {
        // Task: a queryable Where(n > 5); its Expression is a method-call node describing the Where, not a result.
        IQueryable<int> result = TODO;

        Assert.Equal(ExpressionType.Call, result.Expression.NodeType);
    }

    [Fact]
    public void Easy_03_EnumeratingExecutesIt()
    {
        // Task: the same Where(n > 5) query, materialized.
        List<int> result = TODO;

        Assert.Equal(new[] { 8, 9, 8, 7, 10 }, result);
    }

    // ----- Medium -----

    [Fact]
    public void Medium_04_ElementType()
    {
        // Task: ElementType of a queryable over students.
        Type result = TODO;

        Assert.Equal(typeof(Student), result);
    }

    [Fact]
    public void Medium_05_TheInMemoryProvider()
    {
        // Task: the Provider of an in-memory queryable is an EnumerableQuery<T>.
        IQueryProvider result = TODO;

        Assert.IsType<EnumerableQuery<int>>(result);
    }

    // ----- Hard -----

    [Fact]
    public void Hard_06_ExpressionLambdaVersusFuncLambda()
    {
        // Task: `filter` is an Expression<Func<...>> (data describing code), not a Func. Pass it to Queryable.Where.
        Expression<Func<Student, bool>> filter = s => s.Active;

        IQueryable<Student> result = TODO;

        Assert.Equal(16, result.Count());
    }

    [Fact]
    public void Hard_07_ComposeAQueryStepByStep()
    {
        // Task: starting from `query`, add: Where Active, OrderBy Age, Select FirstName - then take the first.
        // Each operator returns a new IQueryable whose Expression wraps the previous one.
        IQueryable<Student> query = Data.Students.AsQueryable();

        string result = TODO;

        Assert.Equal("Carrie", result);
    }
}
