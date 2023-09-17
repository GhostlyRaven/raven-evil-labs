$currentNumberProjectTemplates = 1

function PrintError {
    param (
        $Message
    )

    Write-Host $Message -ForegroundColor Red
}

function PrintInformation {
    param (
        $Message
    )

    Write-Host $Message -ForegroundColor Green
}

function PrintSeparationLine {
    Write-Host $("-" * $Host.UI.RawUI.WindowSize.Width) -ForegroundColor Yellow
}

$projectTemplates = @(
    [pscustomobject]@{
        Name = "LabTemplates"
        Path = "./lab-templates/lab-templates.nuspec"
    }
)

PrintInformation "The build script is running."
PrintSeparationLine
PrintInformation "The build of the Nuget packages with templates has begun:"

foreach ($projectTemplate in $projectTemplates) {
    if ($(Start-Process -FilePath "./tools/nuget" -ArgumentList "pack $($projectTemplate.Path) -OutputDirectory ../../files/all-packages" -WindowStyle Hidden -PassThru -Wait).ExitCode -eq 0) {
        PrintInformation "$($currentNumberProjectTemplates). $($projectTemplate.Name) - successfully."
    }
    else {
        PrintError "$($currentNumberProjectTemplates). $($projectTemplate.Name) - failed."
    }

    $currentNumberProjectTemplates++
}
