param([string] $ProjectDir, [string]$OutputPath);

# Create directory "..\bin\Debug\Extensions" if does not exist. 
[string]$extensionsDirectoryPath = [System.IO.Path]::Combine($ProjectDir, $OutputPath, "Extensions");
if (!(Test-Path $extensionsDirectoryPath))
{
    $extensionsDirectoryPath = [System.IO.Path]::Combine($ProjectDir, $OutputPath);
    New-Item -Path $extensionsDirectoryPath -Name "Extensions" -ItemType "directory" | Out-Null;
}

# Create file "..\bin\Microsoft.VisualStudio.Data.Tools.Package.dll"
[string]$dummyDllPath = [System.IO.Path]::Combine($ProjectDir, $OutputPath, "..", "Microsoft.VisualStudio.Data.Tools.Package.dll");
if (!(Test-Path $dummyDllPath))
{
    "" | Out-File $dummyDllPath
}