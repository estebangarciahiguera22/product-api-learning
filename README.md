# ASP.NET Core Web API – Scalable Product Management System (Learning Project)
# Product API Learning (ASP.NET Core)
This repository documents my learning journey building a RESTful API using ASP.NET Core.
The project evolves step by step from a simple CRUD implementation to a more professional layered architecture.

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

- REST API design
- Layered architecture
- Separation of concerns
- Dependency Injection
- DTO pattern
- Clean code practices

-----------------------------------------------------

## 🛠️ Technology Tools Used

- ASP.NET Core Web API
- C#
- Swagger (API testing)

-----------------------------------------------------

## ▶️ How to Run

1. Open the solution in Visual Studio
2. Run the project
3. Open Swagger UI: https://localhost:44356/swagger/index.html


-----------------------------------------------------

## 📌Author
**Esteban Garcia Higuera**

-----------------------------------------------------

## 📈 Future Improvements
## Next Technical Goals

- Entity Framework Core integration
- database persistence
- authentication and authorization with JWT
- global exception handling
- unit testing
