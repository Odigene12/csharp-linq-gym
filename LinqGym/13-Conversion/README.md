# 13 - Conversion

Change what kind of thing you are holding: materialize a query into a collection, or change the
static type without materializing.

| Method | Exercises | Immediate? | One-liner |
|--------|-----------|------------|-----------|
| [ToList](ToList/README.md) | 10 | yes | Snapshot into a List |
| [ToArray](ToArray/README.md) | 10 | yes | Snapshot into an array |
| [ToDictionary](ToDictionary/README.md) | 10 | yes | Unique key -> value |
| [ToHashSet](ToHashSet/README.md) | 7 | yes | Distinct values with O(1) Contains |
| [Cast](Cast/README.md) | 7 | no | Assert every element is a T |
| [AsEnumerable](AsEnumerable/README.md) | 7 | no | Re-type as IEnumerable to steer overload resolution |
| [AsQueryable](AsQueryable/README.md) | 7 | no | Enter the expression-tree world of IQueryable |

`ToLookup` lives in 08-Grouping. The `To*` methods end deferred execution; the `As*`/`Cast` methods do not.
