# 04 - Partitioning

Take a slice: the first n, the last n, everything after a point, everything while a condition holds.
None of these throw when the count exceeds the sequence.

| Method | Exercises | One-liner |
|--------|-----------|-----------|
| [Take](Take/README.md) | 10 | First n (or a Range) |
| [Skip](Skip/README.md) | 10 | Everything after the first n |
| [TakeWhile](TakeWhile/README.md) | 7 | From the start while a predicate holds |
| [SkipWhile](SkipWhile/README.md) | 7 | Drop the leading run, keep the rest |
| [TakeLast](TakeLast/README.md) | 7 | Last n |
| [SkipLast](SkipLast/README.md) | 7 | All but the last n |
| [Chunk](Chunk/README.md) | 7 | Consecutive batches of n (.NET 6) |

`Skip(a).Take(b)` is paging; `TakeWhile`/`SkipWhile` only make sense on ordered data.
