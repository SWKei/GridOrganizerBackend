# GridOrganizerBackend

## Thoughts and ideas

## Starting the codebase

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Entity Framwork Tool

```bash
dotnet tool install --global dotnet-ef
```

 ### Tools
  - [Visual Studio Code](https://code.visualstudio.com/download)
  - [Visual Studio Community/ Professional/ Enterprise](https://visualstudio.microsoft.com/downloads/) (Alternative)
  - [SQL Server Management Studio(SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

### Setup    
1. Clone the repo

```bash
git clone https://github.com/SWKei/GridOrganizerBackend.git
```
2. Create database and tables

```bash
dotnet ef migrations add InitialMigration
```
```bash
dotnet ef database update
```
## Buildning the app
- To run API
```bash
dotnet run
```
- To test API with Sweggar
```bash
dotnet watch run
```
