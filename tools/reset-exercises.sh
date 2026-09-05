#!/usr/bin/env bash
# Throws away your answers so you can do the exercises again.
# Usage: tools/reset-exercises.sh [part-of-path]   e.g. tools/reset-exercises.sh Where
set -euo pipefail
root="$(cd "$(dirname "$0")/.." && pwd)"
pattern="LinqGym"
if [ "${1:-}" != "" ]; then pattern="LinqGym/*$1*"; fi
git -C "$root" checkout -- $pattern
git -C "$root" clean -fdq -- $pattern
echo "Reset: $pattern"
