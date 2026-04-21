using ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Swagger integration to enable interactive API documentation and testing.
// Requires Swashbuckle.AspNetCore package for proper visualization.

// Servicios
builder.Services.AddControllers();                      // Activa el uso de controllers.
builder.Services.AddEndpointsApiExplorer();             // Le permite a Swagger descubrir tus Endpoints. 
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ProductService>();        // Genera una sola instancia de ProductService para toda la aplicación

// Genera la documentación Swagger/OpenAPI.

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                                   // Crea el archivo Swagger en ejecución.
    app.UseSwaggerUI();                                 // Muestra la interfaz visual en el navegador.
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();