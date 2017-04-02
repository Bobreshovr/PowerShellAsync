# PowerShellAsync
Extentions for PowerShell for use C# syntax async/await

Use like nuget:
```powershell
Install-Package PowerShellAsync
```

Use in System.Management.Automation.dll syntax async/await
```csharp
var ps = PowerShell.Create();
ps.AddScript("ls");
var result = await ps.InvokeAsync<PSObject>();
```


