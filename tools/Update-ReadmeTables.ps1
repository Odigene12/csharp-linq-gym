<#
.SYNOPSIS
  Regenerates the "Exercises" table inside every method README.md from the sibling *Exercises.cs file.

.DESCRIPTION
  Each method folder holds a README.md with the markers

      <!-- exercises:start -->
      <!-- exercises:end -->

  and one or more *Exercises.cs files. For every [Fact] this script reads the method name and the
  "// Task:" comment that follows it, then rewrites the table between the markers. Run it from the repo
  root after adding or renaming exercises so the READMEs never drift from the code.
#>
[CmdletBinding()]
param([string] $Root)
if (-not $Root) { $Root = Join-Path (Split-Path -Parent $PSCommandPath) '..' }
$Root = Join-Path (Resolve-Path $Root).Path 'LinqGym'

function Get-Difficulty([string] $name) {
    switch -Regex ($name) {
        '^Easy_'      { return 'Easy' }
        '^Medium_'    { return 'Medium' }
        '^Hard_'      { return 'Hard' }
        '^Pair_'      { return 'Pair' }
        '^Deferred_'  { return 'Concept' }
        '^Query_'     { return 'Query syntax' }
        '^Report_'    { return 'Capstone' }
        '^Challenge_' { return 'Capstone' }
        default       { return '' }
    }
}

function Get-Exercises([string] $file) {
    $lines = Get-Content -LiteralPath $file -Encoding utf8
    $items = New-Object System.Collections.Generic.List[object]
    for ($i = 0; $i -lt $lines.Count; $i++) {
        if ($lines[$i] -notmatch '^\s*\[Fact\]') { continue }
        $name = $null
        for ($j = $i + 1; $j -lt [Math]::Min($i + 4, $lines.Count); $j++) {
            if ($lines[$j] -match 'public void (?<n>\w+)\(') { $name = $Matches.n; break }
        }
        if (-not $name) { continue }
        $task = ''
        for ($k = $j; $k -lt [Math]::Min($j + 12, $lines.Count); $k++) {
            if ($lines[$k] -match '^\s*// Task: (?<t>.*)$') {
                $task = $Matches.t.Trim()
                $m = $k + 1
                while ($m -lt $lines.Count -and $lines[$m] -match '^\s*// (?<more>.*)$') {
                    $task += ' ' + $Matches.more.Trim()
                    $m++
                }
                break
            }
        }
        $items.Add([pscustomobject]@{ Name = $name; Difficulty = (Get-Difficulty $name); Task = $task })
    }
    return $items
}

$readmes = Get-ChildItem -Path $Root -Recurse -Filter 'README.md' | Where-Object {
    (Get-ChildItem -Path $_.DirectoryName -Filter '*Exercises.cs').Count -gt 0
}

$updated = 0
foreach ($readme in $readmes) {
    $content = Get-Content -LiteralPath $readme.FullName -Raw -Encoding utf8
    if ($content -notmatch '<!-- exercises:start -->') { Write-Warning "No markers in $($readme.FullName)"; continue }

    $rows = New-Object System.Collections.Generic.List[string]
    $files = Get-ChildItem -Path $readme.DirectoryName -Filter '*Exercises.cs' | Sort-Object Name
    foreach ($file in $files) {
        $items = Get-Exercises $file.FullName
        if ($files.Count -gt 1) { $rows.Add(""); $rows.Add("**$($file.Name)**"); $rows.Add("") }
        $rows.Add('| # | Level | Exercise | Task |')
        $rows.Add('|---|-------|----------|------|')
        $n = 0
        foreach ($it in $items) {
            $n++
            $task = $it.Task -replace '\|', '\|'
            $rows.Add("| $n | $($it.Difficulty) | ``$($it.Name)`` | $task |")
        }
    }
    $table = ($rows -join "`n").Trim()
    $new = [regex]::Replace($content, '(?s)(<!-- exercises:start -->).*?(<!-- exercises:end -->)', { param($m) "$($m.Groups[1].Value)`n$table`n$($m.Groups[2].Value)" })
    if ($new -ne $content) {
        [System.IO.File]::WriteAllText($readme.FullName, $new, (New-Object System.Text.UTF8Encoding $false))
        $updated++
    }
}
Write-Host "Updated $updated of $($readmes.Count) README files."
