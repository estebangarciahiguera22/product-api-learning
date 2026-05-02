# 🚀 ASP.NET Core Web API – Scalable Product Management System

This repository presents a complete backend API built with ASP.NET Core, evolving from a basic CRUD implementation to a production-oriented architecture.

The project demonstrates real-world backend development practices including layered architecture, authentication, security, error handling, and logging.

-----------------------------------------------------

## 🚀 Project Evolution

### 🔹 Version 1 - Basic CRUD
- In-memory data handling
- Basic endpoints (GET, POST, PUT, DELETE)
- Direct logic inside controller

-----------------------------------------------------

### 🔹 Version 2 - Service Layer
- Introduced Service Layer
- Separation of concerns
- Controllers handle only HTTP logic

-----------------------------------------------------

### 🔹 Version 3 - Validations
- Input validation added
- Improved error handling
- Structured responses

-----------------------------------------------------

### 🔹 Version 4 - DTO Layer
- Introduced DTOs
- Separation between API and domain models
- Improved scalability and maintainability

-----------------------------------------------------

### 🔹 Version 5 - AutoMapper & Response Wrapper
- RESTful CRUD endpoints
- Service Layer implementation
- DTOs for request/response
- AutoMapper integration
- Standardized API response wrapper
- Swagger for testing

-----------------------------------------------------

### 🔹 Version 6 - Database Integration (EF Core)
- SQLite database integration
- Migrations and DbContext configuration
- Full CRUD with persistence
- Business rule validations

-----------------------------------------------------

### 🔹 Version 7 - Async/Await Scalability
- Asynchronous database operations
- Non-blocking queries
- Improved scalability and performance

-----------------------------------------------------

### 📦 Version 8 - Clean Architecture & Response Standardization
- Full Service Layer implementation
- Global exception middleware
- Custom exceptions (BadRequest, NotFound)
- Generic `ApiResponse<T>` wrapper
- Consistent API responses

-----------------------------------------------------

### 🔐 Version 9 - Authentication & Security Module

- JWT Authentication
- Role-Based Authorization (Admin/User)
- Protected endpoints
- User registration and login
- Password hashing with BCrypt
- Database-based user management

-----------------------------------------------------

### 🔐 Version 10 - Global Error Handling & Logging

- Global exception middleware
- Structured logging with Serilog
- Standardized error responses
- Improved debugging and observability

-----------------------------------------------------

## 📦 Standard API Response Format

``json
{
  "success": true,
  "message": "Operation completed successfully",
  "data": {}
}

-----------------------------------------------------

## 🧠 Key Concepts Learned

- Layered Architecture (Controller → Service)
- Separation of Concerns
- DTO Pattern
- Entity Framework Core (ORM)
- Database Migrations
- Async/Await (non-blocking operations)
- Global Exception Handling (Middleware)
- Custom Exception Design
- Standardized API Responses
- AutoMapper
- JWT Authentication
- Role-Based Authorization
- Claims-based security
- Password hashing with BCrypt
- Scalable backend design

-----------------------------------------------------

## 🛠️ Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQLite
- Swagger
- AutoMapper
- Dependency Injection
- JWT Bearer Authentication
- BCrypt.Net
- Serilog

-----------------------------------------------------

## ▶️ How to Run

1. Open the solution in Visual Studio  
2. Run the project  
3. The database will be created automatically via migrations  
4. Open Swagger:  
   https://localhost:44356/swagger/index.html  

-----------------------------------------------------

## 👨‍💻 Author

**Esteban Garcia Higuera**

-----------------------------------------------------

## ✅ Project Status

This project is complete as a backend learning journey.

It demonstrates a full progression from basic CRUD operations to a production-ready backend including:

- Secure authentication and authorization
- Clean architecture principles
- Global error handling
- Structured logging

The current implementation reflects a solid foundation for real-world backend development.
