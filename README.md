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

 ### API endpoints

| Endpoint | Description | HTTP Method | Endpoint Path | Parameters | Request Body | Response |
| -------- | ----------- | ----------- | --------------| ---------- | ------------ | -------- |
| Get All Grids  | Retrieves a list of all grids.  | GET  | /GetAll  | None |  | - Status Code 200 (OK) on success. - JSON response containing a list of grids. - json { "data": [ { "id": 0, "name": "string", "gridItems": [ { "id": 0, "status": "string" } ] } ], "success": true, "message": "string" } |
| Get Single Grid  | Retrieves a single grid by its ID.  | GET  |	/{id} | - id (int) - Unique identifier of the grid to retrieve. |  | 	- Status Code 200 (OK) on success. - JSON response containing a single grid . - Status Code 404 (Not Found) if the grid with the specified ID is not found. - json { "data": { "id": 0, "name": "string", "gridItems": [ { "id": 0, "status": "string" } ] }, "success": true, "message": "string" } |
| Add Grid  | Adds a new grid.  | POST  | / | JSON object containing the properties of the new grid. | Request Body: json { "name": "string", "gridItems": [ { "id": 0, "status": "string" } ] } | - Status Code 200 (OK) on success. - JSON response containing the newly created grid. - Example Response: json { "data": [ { "id": 0, "name": "string", "gridItems": [ { "id": 0, "status": "string" } ] } ], "success": true, "message": "string" } |
| Update Grid  | Updates an existing grid.  | PUT  | /  | JSON object containing the updated properties of the grid. | Request Body: json { "id": 0, "name": "string", "gridItems": [ { "id": 0, "status": "string" } ] } | - Status Code 200 (OK) on success. - JSON response containing the updated grid. - Status Code 404 (Not Found) if the grid with the specified ID is not found. - json { "data": [ { "id": 0, "name": "string", "gridItems": [ { "id": 0, "status": "string" } ] } ], "success": true, "message": "string" }  |
| Delete Grid  | Deletes a grid by its ID.  | DELETE  | /{id}  | - id (int) - Unique identifier of the grid to delete. |  | - Status Code 200 (OK) on success. - Status Code 404 (Not Found) if the grid with the specified ID is not found. - json { "data": [ { "id": 0, "name": "string", "gridItems": [ { "id": 0, "status": "string" } ] } ], "success": true, "message": "string" } |
