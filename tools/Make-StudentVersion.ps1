<#
.SYNOPSIS
  Strips the reference solutions out of every *Exercises.cs file, leaving TODO placeholders.

.DESCRIPTION
  Maintainers author exercises on the `solutions` branch with the answer inline:

      IEnumerable<int> result = Data.Numbers.Where(n => n > 2); //!

  or, for multi-line answers:

      var result = //!{
          Data.Numbers
              .Where(n => n > 2)
              .ToList();
      //!}

  Running this script rewrites both forms to:

      IEnumerable<int> result = TODO;

  Run it from the repo root on the branch that should receive the student version (normally main).
#>
[CmdletBinding()]
param([string] $Root)
if (-not $Root) { $Root = Join-Path (Split-Path -Parent $PSCommandPath) '..' }
$Root = Join-Path (Resolve-Path $Root).Path 'LinqGym'

$files = Get-ChildItem -Path $Root -Recurse -Filter '*Exercises.cs'
$total = 0
foreach ($file in $files) {
    $lines = Get-Content -LiteralPath $file.FullName -Encoding utf8
    $out = New-Object System.Collections.Generic.List[string]
    $i = 0
    $count = 0
    while ($i -lt $lines.Count) {
        $line = $lines[$i]
        if ($line -match '^(?<decl>\s*[^=]*?) = //!\{\s*$') {
            $out.Add("$($Matches.decl) = TODO;")
            $i++
            while ($i -lt $lines.Count -and $lines[$i] -notmatch '^\s*//!\}\s*$') { $i++ }
            $i++
            $count++
            continue
        }
        if ($line -match '^(?<decl>\s*[^=]*?) = (?<expr>.*); //!\s*$') {
            $out.Add("$($Matches.decl) = TODO;")
            $count++
            $i++
            continue
        }
        $out.Add($line)
        $i++
    }
    if ($count -gt 0) {
        # Join with LF explicitly: WriteAllLines would use CRLF on Windows, which git then
        # normalises on commit and warns about for all 82 files on every sync.
        [System.IO.File]::WriteAllText($file.FullName, (($out -join "`n") + "`n"), (New-Object System.Text.UTF8Encoding $false))
        $total += $count
        Write-Host ("{0,4} solutions stripped from {1}" -f $count, $file.FullName.Substring($Root.Length + 1))
    }
}
Write-Host "Done. $total solutions replaced with TODO across $($files.Count) files."
