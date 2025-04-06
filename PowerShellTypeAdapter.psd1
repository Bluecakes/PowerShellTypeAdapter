@{
    RootModule = 'PowerShellTypeAdapter.psm1'
    RequiredAssemblies = "PowerShellTypeAdapter.dll"
    ModuleVersion = '1.0.0.1'
    CmdletsToExport = '*'
    FunctionsToExport = '*'
    AliasesToExport = '*'
    GUID = '1ba978f2-b2a6-47ce-aad5-02fa7a89f6f8'
	PowerShellVersion="3.0"
    DotNetFrameworkVersion = '4.5.1'
	TypesToProcess="PowerShellTypeAdapter.Types.ps1xml"
    Author = 'Bluecakes'
    Description = 'Favorite Cmdlet to test PSPropertyAdapter'
    CompanyName = 'None'
    Copyright = '(c)'
}