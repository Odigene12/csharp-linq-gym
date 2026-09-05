# 09 - Joining

Correlate two sequences by key.

| Method | Exercises | Unmatched outer | Unmatched inner | Shape |
|--------|-----------|-----------------|-----------------|-------|
| [Join](Join/README.md) | 10 | dropped | dropped | flat pairs |
| [GroupJoin](GroupJoin/README.md) | 7 | kept with empty group | dropped | outer + group of inners |
| [LeftJoin](LeftJoin/README.md) | 7 | kept with null inner | dropped | flat pairs (.NET 10) |
| [RightJoin](RightJoin/README.md) | 7 | dropped | kept with null outer | flat pairs (.NET 10) |

Key types must match exactly (`int?` vs `int` is a compile error - cast one side). Before .NET 10 the left
outer join is `GroupJoin` + `SelectMany` + `DefaultIfEmpty`; the exercises show both.
