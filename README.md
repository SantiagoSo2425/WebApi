# User Management API

Este proyecto es una API para la gestión de usuarios, desarrollada con .NET 8 y C# 12. Incluye operaciones CRUD completas, middlewares personalizados y validación de datos.

## Características

- **CRUD de usuarios**: Endpoints para crear, leer, actualizar y eliminar usuarios.
- **Middlewares personalizados**:
  - `AuthenticationMiddleware`: Valida tokens de autorización.
  - `LoggingMiddleware`: Registra solicitudes y respuestas.
  - `ErrorHandlingMiddleware`: Maneja excepciones globales.
- **Validación de datos**: Uso de atributos como `[Required]` y `[EmailAddress]` para garantizar la integridad de los datos.
- **Documentación con Swagger**: Interfaz interactiva para probar los endpoints.

## Uso de GitHub Copilot

GitHub Copilot fue una herramienta clave en el desarrollo de este proyecto. A continuación, se describen algunos ejemplos de cómo ayudó:

1. **Generación de Middlewares**:
   - Copilot sugirió la estructura base para middlewares como `AuthenticationMiddleware`, incluyendo el uso de `HttpContext` y validación de encabezados.

2. **Controladores CRUD**:
   - Al escribir el controlador `UsersController`, Copilot proporcionó sugerencias para los métodos `GetUsers`, `PostUser`, `PutUser` y `DeleteUser`, acelerando el desarrollo.

3. **Validación de datos**:
   - Durante la creación del modelo `User`, Copilot recomendó el uso de atributos como `[Required]` y `[EmailAddress]` para validar las propiedades `Name` y `Email`.

4. **Configuración de Swagger**:
   - Copilot ayudó a agregar las líneas necesarias en `Program.cs` para habilitar Swagger y su interfaz de usuario.

## Requisitos

- .NET 8 SDK
- Visual Studio 2022 o superior

## Ejecución

1. Clona este repositorio:
   
