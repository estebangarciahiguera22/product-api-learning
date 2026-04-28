# ASP.NET Core Web API – Scalable Product Management System (Learning Project)
# Product API Learning (ASP.NET Core)
This repository documents my learning journey building a RESTful API using ASP.NET Core.
The project evolves step by step from a simple CRUD implementation to a more professional layered architecture.

-----------------------------------------------------

## 🚀 Project Evolution
### 🔹 Version 1 - Basic CRUD
- Simple in-memory data handling
- Basic endpoints (GET, POST, PUT, DELETE)
- Direct logic inside controller
  
-----------------------------------------------------

### 🔹 Version 2 - Service Layer
- Introduced Service Layer
- Separation of concerns
- Controller only handles HTTP logic

-----------------------------------------------------

### 🔹 Version 3 - Validations
- Input validation added
- Better error handling
- Structured responses

-----------------------------------------------------

### 🔹 Version 4 - DTO Layer
- Introduced DTOs (Data Transfer Objects)
- Clean separation between API and domain models
- Improved scalability and maintainability

-----------------------------------------------------


### 🔹 Version 5 - Added AutoMapper and Response Wrapper
- RESTful CRUD endpoints
- Service Layer for business logic
- DTOs for request and response handling
- AutoMapper for object transformation
- Standard API response wrapper
- Swagger for API testing and documentation

----------------------------------------------------

### 🔹 Version 6 - Database Integration (Entity Framework Core)
- Integrated Entity Framework Core
- SQLite database persistence
- Migrations for database versioning
- DbContext configuration
- Full CRUD operations connected to real database
- Business rule validation (e.g., price must be greater than zero)
- Improved service layer with real data handling

----------------------------------------------------

### ⚡ Version 7 - Async/Await Scalability Upgrade
- Converted database operations to async/await
- Implemented non-blocking Entity Framework Core queries
- Replaced synchronous methods with asynchronous service methods
- Improved backend scalability and performance under concurrent requests
- Applied modern ASP.NET Core backend best practices

----------------------------------------------------

## Additionally Standard API Response Format

All endpoints return a standardized response structure:

//```json
{
  "success": true,
  "message": "Operation completed successfully",
  "data": {}
}
//


------------------------------------------------------

## 🧠 Key Concepts Learned

- Layered Architecture
- Separation of Concerns
- DTO Pattern
- Service Layer Pattern
- Entity Framework Core (ORM)
- Database Migrations
- Standardized API Responses
- Object Mapping with AutoMapper
- Validation-driven business rules
- Async/Await programming
- Non-blocking database operations
- Scalable backend request handling

-----------------------------------------------------

## 🛠️ Technology Tools Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQLite
- Swagger (API testing)
- AutoMapper (object mapping)
- Built-in Dependency Injection

-----------------------------------------------------

## ▶️ How to Run

1. Open the solution in Visual Studio
2. Run the project
3. The database will be created automatically via migrations
    Open Swagger UI: https://localhost:44356/swagger/index.html


-----------------------------------------------------

## 📌Author
**Esteban Garcia Higuera**

-----------------------------------------------------

## 📈 Future Improvements
## Next Technical Goals

- Global exception handling (Middleware)
- Authentication and authorization with JWT
- Logging (Serilog)
- Unit testing
- PostgreSQL integration
