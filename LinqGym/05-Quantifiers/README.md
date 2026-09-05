# 05 - Quantifiers

Yes/no questions about a sequence. All three are immediate and stop as soon as the answer is known.

| Method | Exercises | One-liner |
|--------|-----------|-----------|
| [Any](Any/README.md) | 10 | Is there at least one (matching) element? |
| [All](All/README.md) | 10 | Do all elements match? (true for empty) |
| [Contains](Contains/README.md) | 10 | Is this value present? |

Remember: `Any()` beats `Count() > 0`, `All` over an empty sequence is `true`, and `Contains` on classes
is reference equality unless you pass a comparer.
