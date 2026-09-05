#!/usr/bin/env bash
#
# Throw away your answers so you can do the exercises again.
#
#   tools/reset-exercises.sh                  discard uncommitted edits (restore from your branch)
#   tools/reset-exercises.sh Where            ... only the Where exercises
#   tools/reset-exercises.sh --blank          back to unsolved TODOs, even if you committed answers
#   tools/reset-exercises.sh --blank Where    ... only the Where exercises
#
# A filter is matched against the file path, so a method name (Where), a category
# (07-Aggregation) or a partial name all work.
#
# Only *Exercises.cs files are touched, so notes you add to a README survive.
set -euo pipefail
root="$(cd "$(dirname "$0")/.." && pwd)"

blank=0
if [ "${1:-}" = "--blank" ]; then blank=1; shift; fi
filter="${1:-}"

branch=$(git -C "$root" rev-parse --abbrev-ref HEAD)
if [ "$blank" -eq 1 ] && [ "$branch" = "solutions" ]; then
  echo "Refusing: --blank on 'solutions' would replace the reference answers with TODO." >&2
  echo "Switch to your practice branch first." >&2
  exit 1
fi

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

if [ "$blank" -eq 1 ]; then
  source_ref=main
  git -C "$root" rev-parse --verify --quiet "$source_ref" >/dev/null || source_ref=origin/main
  git -C "$root" rev-parse --verify --quiet "$source_ref" >/dev/null || {
    echo "Cannot find a 'main' branch to restore the unsolved exercises from." >&2; exit 1; }
  changed=$(git -C "$root" diff --name-only "$source_ref" -- "$pathspec" | wc -l)
  git -C "$root" checkout "$source_ref" -- "$pathspec"
  echo "Restored $changed of $matched exercise file(s) to the unsolved version from $source_ref."
  if [ "$changed" -eq 0 ]; then
    echo "They already matched $source_ref, so nothing changed."
  fi
else
  changed=$(git -C "$root" diff --name-only -- "$pathspec" | wc -l)
  git -C "$root" checkout -- "$pathspec"
  echo "Discarded uncommitted edits in $changed of $matched exercise file(s)."
  if [ "$changed" -eq 0 ]; then
    echo "Nothing was uncommitted. If you already committed answers, use --blank to go back to TODOs."
  fi
fi
