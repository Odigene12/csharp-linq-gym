# 10 - Set operations

Treat sequences as sets: remove duplicates, combine, intersect, subtract. Every method here yields
**distinct** results and preserves first-seen order. The `*By` variants (.NET 6) compare by a key
instead of by the whole element - essential for classes, which otherwise compare by reference.

| Method | Exercises | One-liner |
|--------|-----------|-----------|
| [Distinct](Distinct/README.md) | 10 | Remove duplicates |
| [DistinctBy](DistinctBy/README.md) | 7 | Remove elements with a duplicate key |
| [Union](Union/README.md) | 7 | In either sequence |
| [UnionBy](UnionBy/README.md) | 7 | ... by key |
| [Intersect](Intersect/README.md) | 7 | In both sequences |
| [IntersectBy](IntersectBy/README.md) | 7 | ... whose key is in a sequence of keys |
| [Except](Except/README.md) | 7 | In the first but not the second |
| [ExceptBy](ExceptBy/README.md) | 7 | ... whose key is not in a sequence of keys |

Note the asymmetry of `IntersectBy`/`ExceptBy`: their second argument is a sequence of **keys**, and
their result is distinct **by key**.
