<#
.SYNOPSIS
  Throws away your answers so you can do the exercises again.

.DESCRIPTION
  Restores *Exercises.cs files to the committed version on the current branch. Notes you add to a
  README are left alone.

.EXAMPLE
  .\tools\Reset-Exercises.ps1                 # every exercise file
.EXAMPLE
  .\tools\Reset-Exercises.ps1 -Only Where     # just the Where exercises
.EXAMPLE
  .\tools\Reset-Exercises.ps1 -Only 07-Agg    # everything under 07-Aggregation
#>
[CmdletBinding()]
param([string] $Only = '')

$root = Split-Path -Parent (Split-Path -Parent $PSCommandPath)
$pathspec = if ($Only) { "LinqGym/*$Only*Exercises.cs" } else { 'LinqGym/*Exercises.cs' }

$matched = @(git -C $root ls-files -- $pathspec)
if ($matched.Count -eq 0) {
    Write-Error "No exercise files match '$Only'."
    exit 1
}
git -C $root checkout -- $pathspec
$label = if ($Only) { $Only } else { 'all' }
Write-Host "Reset $($matched.Count) exercise file(s) matching '$label'."
