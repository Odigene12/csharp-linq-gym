<#
.SYNOPSIS
  Throws away your answers so you can do the exercises again.

.DESCRIPTION
  Without -Blank, discards uncommitted edits by restoring exercise files from your current branch.
  With -Blank, restores the unsolved TODO version from main, which is what you want after committing
  answers on a practice branch. Only *Exercises.cs files are touched, so notes added to a README survive.

.EXAMPLE
  .\tools\Reset-Exercises.ps1
  Discard uncommitted edits in every exercise file.

.EXAMPLE
  .\tools\Reset-Exercises.ps1 -Only Where
  Discard uncommitted edits in the Where exercises only.

.EXAMPLE
  .\tools\Reset-Exercises.ps1 -Blank
  Go back to unsolved TODOs everywhere, even where answers were committed.

.EXAMPLE
  .\tools\Reset-Exercises.ps1 -Blank -Only 07-Aggregation
  Go back to unsolved TODOs for one category.
#>
[CmdletBinding()]
param(
    [switch] $Blank,
    [string] $Only = ''
)

$root = Split-Path -Parent (Split-Path -Parent $PSCommandPath)
$branch = (git -C $root rev-parse --abbrev-ref HEAD).Trim()

if ($Blank -and $branch -eq 'solutions') {
    Write-Error "Refusing: -Blank on 'solutions' would replace the reference answers with TODO. Switch to your practice branch first."
    exit 1
}

$pathspec = if ($Only) { "LinqGym/*$Only*Exercises.cs" } else { 'LinqGym/*Exercises.cs' }

$matched = @(git -C $root ls-files -- $pathspec)
if ($matched.Count -eq 0) {
    Write-Error "No exercise files match '$Only'."
    exit 1
}

if ($Blank) {
    $sourceRef = 'main'
    git -C $root rev-parse --verify --quiet $sourceRef *> $null
    if ($LASTEXITCODE -ne 0) { $sourceRef = 'origin/main' }
    git -C $root rev-parse --verify --quiet $sourceRef *> $null
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Cannot find a 'main' branch to restore the unsolved exercises from."
        exit 1
    }
    $changed = @(git -C $root diff --name-only $sourceRef -- $pathspec)
    git -C $root checkout $sourceRef -- $pathspec
    Write-Host "Restored $($changed.Count) of $($matched.Count) exercise file(s) to the unsolved version from $sourceRef."
    if ($changed.Count -eq 0) { Write-Host "They already matched $sourceRef, so nothing changed." }
}
else {
    $changed = @(git -C $root diff --name-only -- $pathspec)
    git -C $root checkout -- $pathspec
    Write-Host "Discarded uncommitted edits in $($changed.Count) of $($matched.Count) exercise file(s)."
    if ($changed.Count -eq 0) {
        Write-Host "Nothing was uncommitted. If you already committed answers, use -Blank to go back to TODOs."
    }
}
