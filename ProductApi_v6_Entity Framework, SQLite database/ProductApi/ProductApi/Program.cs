using ProductApi.Services;
using ProductApi.Mappings;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Swagger integration to enable interactive API documentation and testing.
// Requires Swashbuckle.AspNetCore package for proper visualization.

// Services
builder.Services.AddControllers();                      // Enables controllers
builder.Services.AddEndpointsApiExplorer();             // Allows Swagger to discover endpoints
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>    // Register Data Bases
    options.UseSqlite("Data Source=products.db"));

builder.Services.AddScoped<ProductService>();        // Now the Database is call by the request , not as singleton 

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