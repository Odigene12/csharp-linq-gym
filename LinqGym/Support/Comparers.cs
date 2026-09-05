namespace LinqGym.Support;

/// <summary>
/// Treats two people as equal when their Ids match, regardless of reference identity.
/// Used by exercises that take an IEqualityComparer (Distinct, Contains, Union, GroupBy, ...).
/// </summary>
public sealed class PersonIdComparer : IEqualityComparer<Person>
{
    public static readonly PersonIdComparer Instance = new();

    public bool Equals(Person? x, Person? y) => x?.Id == y?.Id;
    public int GetHashCode(Person obj) => obj.Id;
}
