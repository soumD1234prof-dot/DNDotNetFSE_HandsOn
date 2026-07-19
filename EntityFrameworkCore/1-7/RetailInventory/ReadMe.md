# Lab 1: Understanding ORM with a Retail Inventory System

## 1. What is ORM?
 
**ORM (Object-Relational Mapping)** is a technique that maps C# classes to database tables, allowing developers to interact with a relational database using objects instead of raw SQL.
 
- A C# class (e.g. `Product`) maps to a database table (e.g. `Products`)
- Class properties map to table columns
- Class instances map to table rows
### Benefits
| Benefit | Description |
|---|---|
| **Productivity** | Write C#/LINQ instead of hand-crafted SQL for common operations |
| **Maintainability** | Schema changes are driven by code changes and tracked via migrations |
| **Abstraction** | Developers work with objects, not raw SQL, reducing boilerplate and errors |
 
---
 
## 2. EF Core vs EF Framework (EF6)
 
| | EF Core | EF Framework (EF6) |
|---|---|---|
| Platform | Cross-platform (Windows/macOS/Linux) | Windows-only |
| Performance | Lightweight, modern, performant | Heavier, older architecture |
| Features | LINQ, async queries, compiled queries | Mature but limited flexibility |
| Status | Actively developed | Maintenance mode |
 
---
 
## 3. EF Core 8.0 Features
 
- **JSON column mapping** — map complex types directly to JSON columns in SQL Server
- **Compiled models** — improved startup performance via pre-generated models
- **Interceptors & bulk operations** — finer control over query execution and batch operations
---
 
## Setup Instructions
 
### 4. Create a .NET Console App
```bash
dotnet new console -n RetailInventory
cd RetailInventory
```
 
### 5. Install EF Core Packages
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```
 
---
 
## Environment
 
- **IDE**: VS Code (with C# extension) or Visual Studio — either works, all commands run via the .NET CLI in the terminal
- **SDK**: .NET SDK (verify with `dotnet --version`)
- **Database**: SQL Server (local or containerized)
---
 
## Key Takeaways
 
- ORM removes the need to hand-write most SQL for CRUD operations
- EF Core is the modern, cross-platform choice over EF6
- This project is scaffolded as a console app with the SQL Server provider and EF Core design-time tooling installed, ready for model classes and a `DbContext` in the next steps