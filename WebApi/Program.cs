
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar la canalización de middleware en el orden correcto

// 1. Middleware de manejo de errores: captura excepciones desde todos los siguientes middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

// 2. Middleware de autenticación: valida los tokens antes de continuar
app.UseMiddleware<AuthenticationMiddleware>();

// 3. Middleware de logging: registra la solicitud y respuesta (se ejecuta después de autenticación)
app.UseMiddleware<LoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
