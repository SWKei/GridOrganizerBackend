# GridOrganizerBackend

## Thoughts and ideas
This WEB API serves as the backend application for the frontend project [grid-organizer-frontend](https://github.com/SWKei/grid-organizer-frontend)
Despite its small scale, I have endeavored to implement techniques and architectural principles commonly found in real-world applications.

### Technical features:
- .NET 7 Web API
- RESTful web service calls (GET, POST, PUT, DELETE)
- Entity Framework Core 7 (Code-first migration)
- SQL Server (one-to-many relationship)
- Asynchronous Calls
- Data Transfer Objects (DTOs)
- Controller ↔ Service ↔ Database Architecture


## Starting the codebase

### Prerequisites
Before you start, ensure you have the following software and tools installed:
- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Entity Framwork Tool\
  You can install the Entity Framework Tool globally using the following command:
```bash
dotnet tool install --global dotnet-ef
```

 ### Tools
  - [Visual Studio Code](https://code.visualstudio.com/download)
  - [Visual Studio Community/ Professional/ Enterprise](https://visualstudio.microsoft.com/downloads/) (Alternative)
  - [SQL Server Management Studio(SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

### Setup    
1. Clone the repository:
```bash
git clone https://github.com/SWKei/GridOrganizerBackend.git
```

2. Create the database and tables by running the following commands:
```bash
dotnet ef migrations add InitialMigration
```

```bash
dotnet ef database update
```

## Building the Application
- To run the API, use the following command:
```bash
dotnet run
```

- To test the API using Swagger, you can use the following command:
```bash
dotnet watch run
```
