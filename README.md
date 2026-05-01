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

### 🔹 Version 7 - Async/Await Scalability Upgrade
- Converted database operations to async/await
- Implemented non-blocking Entity Framework Core queries
- Replaced synchronous methods with asynchronous service methods
- Improved backend scalability and performance under concurrent requests
- Applied modern ASP.NET Core backend best practices

----------------------------------------------------
### 📦 Version 8 - Clean Architecture & Response Standardization

This version focused on improving code structure, maintainability, and consistency across the API responses.

Instead of returning raw data directly from controllers, a standardized response format and cleaner architecture were implemented to simulate real-world backend practices.

#### 🔹 Version 8.0 - Service Layer Implementation
- Introduced a service layer to separate business logic from controllers
- Controllers now delegate logic to services
- Improved code readability and maintainability
- Implemented custom exception classes (BadRequest, NotFound)
- Added global exception middleware
- Centralized error handling for cleaner controllers
- Consistent error responses across the API
- Created a generic `ApiResponse<T>` wrapper
- Unified success and error response structure
- Included fields like:
  - success
  - message
  - data
- Improved API consistency for frontend integration

----------------------------------------------------

### 🔐 Version 9 - Authentication & Security Module

This version was divided into smaller sub-versions because authentication and security include multiple professional backend concepts that were implemented progressively.

Instead of treating JWT, roles, database users, and password hashing as isolated features, they were grouped under Version 9 as part of the same security module.

The authentication module is divided into subversions to show the progressive implementation of security features:

- V9.0: JWT Authentication
- V9.1: Role-Based Authorization
- V9.2: Register endpoint and password hashing

Each folder contains a working version of the project at that stage.

#### 🔹 Version 9.0 - JWT Authentication
- Implemented JWT token generation
- Added login endpoint
- Configured JWT authentication in ASP.NET Core
- Protected API endpoints using bearer tokens

#### 🔹 Version 9.1 - Role-Based Authorization
- Added role claims to JWT tokens
- Implemented Admin and User roles
- Restricted sensitive endpoints to Admin users
- Verified authorization behavior with 401 Unauthorized and 403 Forbidden responses

#### 🔹 Version 9.2 - User Registration & Password Hashing
- Added user registration endpoint
- Stored users in the database
- Implemented password hashing with BCrypt
- Updated login to validate hashed passwords
- Improved authentication security following backend best practices

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
- Layered architecture (Controller → Service)
- Separation of concerns
- Global exception handling with middleware
- Custom exception design
- Standardized API responses
- Clean and maintainable backend structure
- JWT Authentication
- Role-Based Authorization
- Claims-based security
- Password hashing with BCrypt
- User registration and login flow
- Authentication using database persistence

-----------------------------------------------------

## 🛠️ Technology Tools Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQLite
- Swagger (API testing)
- AutoMapper (object mapping)
- Built-in Dependency Injection
- JWT Bearer Authentication
- BCrypt.Net-Next

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

- Logging (Serilog)
- Unit testing
- PostgreSQL integration
