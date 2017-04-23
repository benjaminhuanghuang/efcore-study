## Add dependencies into .csproj

    $ dotnet add package Microsoft.EntityFrameworkCore

```xml
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="1.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="1.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version= "1.1.1"/>
```

## Add dev tools into .csproj
```xml
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="1.0.0" />
```
    used by $ dotnet ef dbcontext info

## MS Sql Cli
    $ mssql -u sa -p Sql@1433
    > sq_databases
    
    
## Config file


