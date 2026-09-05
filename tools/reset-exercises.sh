#!/usr/bin/env bash
# Throw away your answers so you can do the exercises again.
#
#   tools/reset-exercises.sh            # every exercise file
#   tools/reset-exercises.sh Where      # just the Where exercises
#   tools/reset-exercises.sh 07-Agg     # every exercise file under 07-Aggregation
#
# Only *Exercises.cs files are touched, so notes you add to a README are safe.
set -euo pipefail
root="$(cd "$(dirname "$0")/.." && pwd)"
filter="${1:-}"
if [ -n "$filter" ]; then
  pathspec="LinqGym/*${filter}*Exercises.cs"
else
  pathspec="LinqGym/*Exercises.cs"
fi
matched=$(git -C "$root" ls-files -- "$pathspec" | wc -l)
if [ "$matched" -eq 0 ]; then
  echo "No exercise files match '$filter'." >&2
  exit 1
fi
git -C "$root" checkout -- "$pathspec"
echo "Reset $matched exercise file(s) matching '${filter:-all}'."
