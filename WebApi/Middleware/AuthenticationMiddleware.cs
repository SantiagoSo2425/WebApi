using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApi.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationMiddleware> _logger;

        public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Permitir acceso a Swagger sin autenticación
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            // Verificar que el encabezado de autorización esté presente
            if (!context.Request.Headers.TryGetValue("Authorization", out var token) || !IsValidToken(token))
            {
                _logger.LogWarning("Unauthorized request. Missing or invalid token.");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            // Continuar con la cadena de middleware si el token es válido
            await _next(context);
        }


        // Método de ejemplo para validar el token (puede ser reemplazado con lógica real)
        private bool IsValidToken(string token)
        {
            // Ejemplo simple: activar solo si el token inicia con "Bearer " y contiene alguna cadena a continuación.
            if (token.StartsWith("Bearer ") && token.Length > "Bearer ".Length)
            {
                // Aquí podrías agregar lógica adicional de validación (verificación de firma, caducidad, etc.)
                return true;
            }
            return false;
        }
    }
}
