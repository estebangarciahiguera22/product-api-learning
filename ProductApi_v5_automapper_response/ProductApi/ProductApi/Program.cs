using ProductApi.Services;
using ProductApi.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Swagger integration to enable interactive API documentation and testing.
// Requires Swashbuckle.AspNetCore package for proper visualization.

// Services
builder.Services.AddControllers();                      // Enables controllers
builder.Services.AddEndpointsApiExplorer();             // Allows Swagger to discover endpoints
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ProductService>();        // Single instance of ProductService for the entire app

// AutoMapper configuration
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                                   // Generates Swagger JSON
    app.UseSwaggerUI();                                 // Displays Swagger UI in browser
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();