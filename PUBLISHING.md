# Publishing AnointedAutomation NuGet Packages

This repository contains several NuGet packages that can be published to NuGet.org:

- [AnointedAutomation.APIMiddlewares](https://www.nuget.org/packages/AnointedAutomation.APIMiddlewares/)
- [AnointedAutomation.Logging](https://www.nuget.org/packages/AnointedAutomation.Logging/)
- [AnointedAutomation.Memory](https://www.nuget.org/packages/AnointedAutomation.Memory/)
- [AnointedAutomation.Objects](https://www.nuget.org/packages/AnointedAutomation.Objects/)
- [AnointedAutomation.Objects.API](https://www.nuget.org/packages/AnointedAutomation.Objects.API/)
- [AnointedAutomation.Repository.Mongo](https://www.nuget.org/packages/AnointedAutomation.Repository.Mongo/)

## Automatic Publishing via GitHub Actions

**Packages are automatically published when:**
- Code is merged to the `master` branch
- The package version in the `.csproj` file has been incremented

The GitHub Actions workflow will:
1. Build and test the solution
2. Compare each package's version with the version on NuGet.org
3. Only publish packages that have version changes
4. Skip packages with unchanged versions

## Prerequisites for Manual Publishing

1. .NET 8.0 SDK installed
2. NuGet API key from nuget.org
3. All tests passing

## Manual Publishing Script

A single script is provided for manual publishing when needed:

### Linux/Mac/WSL (Bash)
```bash
export NUGET_API_KEY=your_api_key
./publish-packages.sh
```

This script will:
1. Check the current git branch (warns if not on master)
2. Restore all dependencies
3. Build the solution in Release mode
4. Run all tests
5. Compare local versions with NuGet.org versions
6. Only publish packages with version changes

## Version Management

To publish a new version:

1. Update the `<Version>` tag in the relevant `.csproj` file
2. Commit the change
3. Create a pull request to master
4. When merged, the package will automatically be published

Example version increments:
- Patch: 1.0.0 → 1.0.1
- Minor: 1.0.0 → 1.1.0
- Major: 1.0.0 → 2.0.0

## Manual Publishing Steps

If you need to publish manually without the script:

```bash
# Build
dotnet build --configuration Release

# Test
dotnet test --configuration Release

# Pack a specific project
dotnet pack AnointedAutomation.Logging/AnointedAutomation.Logging.csproj --configuration Release

# Push to NuGet
dotnet nuget push AnointedAutomation.Logging/bin/Release/AnointedAutomation.Logging.*.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```

## GitHub Actions Configuration

The repository uses GitHub Actions for automatic publishing:

- **Workflow**: `.github/workflows/nuget-publish.yml`
- **Trigger**: Push to master branch
- **Secret Required**: `NUGET_API_KEY` must be set in repository secrets

The workflow ensures that:
- Only packages with version changes are published
- All tests pass before publishing
- Publishing only happens from the master branch