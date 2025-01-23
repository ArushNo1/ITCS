# Define the base directory for the release files
$baseDir = ".\bin\Release\net*"

# Define the current directory as the target
$targetDir = Get-Location

# Loop through each platform folder
Get-ChildItem -Path $baseDir -Recurse -Directory | ForEach-Object {
    $platform = $_.Name    # Extract platform name (e.g., win-x64)
    $publishDir = Join-Path $_.FullName "publish" # Get the publish folder

    if (Test-Path $publishDir) {
        # Find the runnable file in the publish folder (Windows: .exe, Linux/Mac: no extension)
        $runnableFile = Get-ChildItem -Path $publishDir -File | Where-Object {
            $_.Extension -eq ".exe" -or $_.Extension -eq ""
        } | Select-Object -First 1

        if ($runnableFile) {
            # Create a new name for the runnable based on the platform
            $newFileName = "$($runnableFile.BaseName)-$platform$($runnableFile.Extension)"
            $newFilePath = Join-Path $targetDir $newFileName

            # Copy the runnable to the target directory with the new name
            Copy-Item -Path $runnableFile.FullName -Destination $newFilePath -Force
            Write-Host "Copied $($runnableFile.Name) as $newFileName"
        } else {
            Write-Warning "No runnable found in $publishDir"
        }
    }
}
