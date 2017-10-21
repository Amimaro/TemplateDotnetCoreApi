# TemplateDotnetCoreApi

ASP.Net Core 2 WepApi with Entity Framework and SQL Server data persistence

#### For migration:
1. Setup DefaultConnection SQL Server parameters at appsettings
2. Run:
```sh
dotnet ef migrations add init
dotnet ef database update
```


