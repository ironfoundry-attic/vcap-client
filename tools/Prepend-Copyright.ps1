Process
{
    if (! $_.PSIsContainer)
    {
        $fullFileName = $_.FullName
        $fileName = $_.Name

        Write-Host -ForegroundColor 'yellow' "Processing file: $_"

        $template = @"
// -----------------------------------------------------------------------
// <copyright file="$fileName" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

"@

        $content = Get-Content $_
        $newName = $fullFileName + '.bak'
        Move-Item $_ $newName
        Set-Content $_ -Value $template,$content
    }
}
