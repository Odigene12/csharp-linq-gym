# 08 - Grouping

Bucket elements by a key.

| Method | Exercises | One-liner |
|--------|-----------|-----------|
| [GroupBy](GroupBy/README.md) | 10 | Deferred groups, in first-seen key order |
| [ToLookup](ToLookup/README.md) | 7 | Immediate, indexable groups |

`GroupBy` + `Select` is SQL `GROUP BY`; `GroupBy` + `Where(group)` is `HAVING`. Reach for `ToLookup` when
you will look groups up by key repeatedly.
