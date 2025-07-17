# Stock CRUD API

A RESTful API for managing stock data built with ASP.NET Core and Entity Framework Core.

## Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [API Endpoints](#api-endpoints)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Usage Examples](#usage-examples)
- [Technologies Used](#technologies-used)

## Features

- Complete CRUD operations for stock management
- RESTful API design
- Entity Framework Core for data persistence
- DTO pattern for data transfer
- Centralized endpoint management
- Proper HTTP status code responses
- OpenAPI/Swagger documentation

## Architecture

This project follows a clean architecture pattern with clear separation of concerns:

### Layers

1. **Controllers** - Handle HTTP requests and responses
2. **DTOs** - Data Transfer Objects for API contracts
3. **Mappers** - Convert between entities and DTOs
4. **Data** - Entity Framework DbContext and database models
5. **Endpoints** - Centralized route definitions

### Design Patterns

- **Repository Pattern** - Through Entity Framework DbContext
- **DTO Pattern** - Separate request/response models
- **Mapper Pattern** - Entity to DTO conversion
- **Dependency Injection** - For DbContext and services


## API Endpoints

### Base URL

/api/stocks

### Available Endpoints

| Method | Endpoint | Description | Status Codes |
|--------|----------|-------------|--------------|
| GET | `/api/stocks` | Get all stocks | 200 |
| GET | `/api/stocks/{id}` | Get stock by ID | 200, 404 |
| POST | `/api/stocks` | Create new stock | 201 |
| PUT | `/api/stocks/{id}` | Update existing stock | 200, 404 |
| DELETE | `/api/stocks/{id}` | Delete stock | 204, 404 |

## Getting Started

### Prerequisites

- .NET 6.0 or later
- SQL Server (or your preferred database)
- Visual Studio 2022 or JetBrains Rider

### Installation

1. Clone the repository:
```bash
git clone https://github.com/Sonseldeep/stock-api
cd stock-api
```
2. Restore dependencies
```bash
dotnet restore
```

## 🔧 Setup Entity Framework Core with SQL Server using .NET CLI

### 1️⃣ Install Required EF Core Packages

Use the following commands to install the necessary NuGet packages via .NET CLI:

```bash
# EF Core Runtime
dotnet add package Microsoft.EntityFrameworkCore

# EF Core SQL Server Provider
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

# EF Core Tools (for migrations and database update)
dotnet add package Microsoft.EntityFrameworkCore.Tools


# Add Migration
dotnet ef migrations add AddStockTableToDb

# Update Database
dotnet ef database update


## 🔗 Connection String Configuration

Make sure your `appsettings.json` includes a valid SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=YourDbName;User Id=SA;Password=YourStrongPassword;TrustServerCertificate=True;"
  }
}


