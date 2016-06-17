param (
	[Parameter(Mandatory=$true)]
	[int]
	$BuildNumber
)

$PSScriptFilePath = (Get-Item $MyInvocation.MyCommand.Path).FullName

" PSScriptFilePath = $PSScriptFilePath"

$SolutionRoot = Split-Path -Path $PSScriptFilePath -Parent
$ProjectJsonPath = Join-Path -Path $SolutionRoot -ChildPath "src\Microsoft.BusinessStore\project.json"

$DOTNET = "dotnet"

# Make sure we don't have a build folder for this version already
$BuildFolder = Join-Path -Path $SolutionRoot -ChildPath "artifacts";
if ((Get-Item $BuildFolder -ErrorAction SilentlyContinue) -ne $null)
{
	Write-Warning "$BuildFolder already exists on your local machine. It will now be deleted."
	Remove-Item $BuildFolder -Recurse
}

# Build the proj in release mode

& $DOTNET --info

& $DOTNET restore
if (-not $?)
{
	throw "The dotnet restore process returned an error code."
}

& $DOTNET build "$ProjectJsonPath"
if (-not $?)
{
	throw "The dotnet build process returned an error code."
}

& $DOTNET pack "$ProjectJsonPath" --configuration Release --output "$BuildFolder"  --version-suffix $BuildNumber
if (-not $?)
{
	throw "The dotnet pack process returned an error code."
}
