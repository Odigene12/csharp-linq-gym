# 06 - Element operators

Pull a single element out of a sequence. The family has a pattern: the plain version **throws** when the
element is missing; the `OrDefault` version returns `default(T)` (or a value you supply) instead.

| Method | Exercises | Missing -> | More than one -> |
|--------|-----------|------------|------------------|
| [First](First/README.md) | 10 | throws | fine |
| [FirstOrDefault](FirstOrDefault/README.md) | 10 | default | fine |
| [Last](Last/README.md) | 7 | throws | fine |
| [LastOrDefault](LastOrDefault/README.md) | 7 | default | fine |
| [Single](Single/README.md) | 10 | throws | **throws** |
| [SingleOrDefault](SingleOrDefault/README.md) | 10 | default | **throws** |
| [ElementAt](ElementAt/README.md) | 7 | throws (ArgumentOutOfRange) | n/a |
| [ElementAtOrDefault](ElementAtOrDefault/README.md) | 7 | default | n/a |
| [DefaultIfEmpty](DefaultIfEmpty/README.md) | 7 | yields one default | n/a |

Choose by intent: `First` = "give me one", `Single` = "there must be exactly one", `OrDefault` = "it may
not exist and that is fine".
