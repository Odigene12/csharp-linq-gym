# 03 - Sorting

Change the order. All sorts are **stable** (ties keep their original order) and **buffering** (the whole
source is read before the first element is produced).

| Method | Exercises | One-liner |
|--------|-----------|-----------|
| [OrderBy](OrderBy/README.md) | 10 | Ascending by key |
| [OrderByDescending](OrderByDescending/README.md) | 10 | Descending by key |
| [ThenBy](ThenBy/README.md) | 10 | Secondary ascending key |
| [ThenByDescending](ThenByDescending/README.md) | 7 | Secondary descending key |
| [Order](Order/README.md) | 7 | Ascending by the element itself (.NET 7) |
| [OrderDescending](OrderDescending/README.md) | 7 | Descending by the element itself (.NET 7) |
| [Reverse](Reverse/README.md) | 7 | Flip the order - no sorting |

Two things to internalize: `OrderBy(a).OrderBy(b)` is **not** `OrderBy(a).ThenBy(b)`, and string sorting
needs an explicit `StringComparer` if the data is mixed-case.
