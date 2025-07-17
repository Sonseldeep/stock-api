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

## Project Structure

API/ ├── Controllers/ │ └── StockController.cs # Main API controller ├── Data/ │ └── ApplicationDbContext.cs # Database context ├── Dtos/ │ └── Stock/ │ ├── CreateStockRequestDto.cs │ ├── UpdateStockRequestDto.cs │ └── StockDto.cs ├── EndPoints/ │ └── ApiEndPoints.cs # Centralized route definitions ├── Mappers/ │ └── StockMappers.cs # Entity to DTO mapping └── Models/ └── Stock.cs # Entity model




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
git clone <repository-url>
cd stock-crud-api
```
2. Restore dependencies
```bash
dotnet restore
```
3. Run Database Migrations
```bash
dotnet run
```


Best Practices Implemented



Best Practices Implemented
✅ RESTful API design
✅ Proper HTTP status codes
✅ DTO pattern for data transfer
✅ Centralized endpoint management
✅ Entity Framework best practices
✅ Dependency injection
✅ API documentation with attributes
✅ Clean code architecture
