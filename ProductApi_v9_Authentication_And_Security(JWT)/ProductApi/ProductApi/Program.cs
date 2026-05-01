using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductApi.Data;
using ProductApi.Mappings;
using ProductApi.Middleware;
using ProductApi.Services;
using System.Text;



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

//AuthoDTOs Services Execution
builder.Services.AddScoped<AuthService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtKey = builder.Configuration["Jwt:Key"];

        if (string.IsNullOrWhiteSpace(jwtKey))
        {
            throw new Exception("JWT key is not configured");
        }

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });



var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                                   // Generates Swagger JSON
    app.UseSwaggerUI();                                 // Displays Swagger UI in browser
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();

