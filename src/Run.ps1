$pathToLocalNuGetRepository = "E:\Temp\NuGetLocalRepository"
$targetNuGetPackageSource = "NuGetLocalRepository"
$nuGetPackageName = "Coding4fun.TransactSql.Analyzers"
$packageVersion = "1.0.0"

# Building project with sql analyzers
Write-Host "Building Analyzers.csproj"
dotnet build .\Analyzers\Analyzers.csproj --configuration=Release

# Creating directory with NuGet repository on the local PC for testing purpose
$nugetSources = dotnet nuget list source --format Short
if (($nugetSources | ForEach-Object{$_.ToString().EndsWith($targetNuGetPackageSource)}) -contains $true)
{
    Write-Host "Local NuGet repository already exists"
}
else
{
    Write-Host "Creating local NuGet repository"
    dotnet nuget add source $pathToLocalNuGetRepository --name $targetNuGetPackageSource
}

# Removing package from the nuget cache
if (Test-Path "$env:USERPROFILE\.nuget\packages\$nuGetPackageName")
{
    Write-Host "Removing package from the nuget directory"
    Remove-Item -Path "$env:USERPROFILE\.nuget\packages\$nuGetPackageName" -Recurse -Force
}

# Removing package from the local nuget repository
if (Test-Path "$pathToLocalNuGetRepository\$nuGetPackageName*")
{
    Write-Host "Removing package from the local repository"
    Remove-Item -Path "$pathToLocalNuGetRepository\$nuGetPackageName*"
}

# Pushing package to the local nuget repository
Write-Host "Pushing package to the local repository"
dotnet nuget push ".\Analyzers\bin\Release\$nuGetPackageName.$packageVersion.nupkg" --source $targetNuGetPackageSource

# Building sql project using our analyzers
dotnet build ..\test\ExampleSqlProject\ExampleSqlProject.sqlproj