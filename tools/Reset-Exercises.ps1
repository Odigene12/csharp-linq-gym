<#
.SYNOPSIS
  Throws away your answers so you can do the exercises again.

.DESCRIPTION
  Restores every *Exercises.cs file to the committed version on the current branch.
  Pass -Only with part of a path (e.g. "Where" or "07-Aggregation") to reset just that part.
#>
[CmdletBinding()]
param([string] $Only = '')

$root = Join-Path $PSScriptRoot '..'
$pattern = if ($Only) { "LinqGym/*$Only*" } else { 'LinqGym' }
git -C $root checkout -- $pattern 2>$null
git -C $root clean -fdq -- $pattern 2>$null
Write-Host "Reset: $pattern"
