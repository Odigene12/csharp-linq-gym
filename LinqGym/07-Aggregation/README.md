# 07 - Aggregation

Reduce a sequence to a single value (or, for the `*By` methods, one value per key). All immediate.

| Method | Exercises | One-liner |
|--------|-----------|-----------|
| [Count](Count/README.md) | 10 | How many |
| [LongCount](LongCount/README.md) | 7 | How many, as a long |
| [Sum](Sum/README.md) | 10 | Total |
| [Average](Average/README.md) | 10 | Mean |
| [Min](Min/README.md) | 10 | Smallest value |
| [Max](Max/README.md) | 10 | Largest value |
| [MinBy](MinBy/README.md) | 7 | Element with the smallest key (.NET 6) |
| [MaxBy](MaxBy/README.md) | 7 | Element with the largest key (.NET 6) |
| [Aggregate](Aggregate/README.md) | 10 | Any fold you can imagine |
| [CountBy](CountBy/README.md) | 7 | Count per key (.NET 9) |
| [AggregateBy](AggregateBy/README.md) | 7 | Fold per key (.NET 9) |

Empty-sequence behaviour differs: `Sum`/`Count` give 0, `Average`/`Min`/`Max` throw for non-nullable
types and return null for nullable ones, `Aggregate` without a seed throws.
