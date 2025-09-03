CrudClientes – Clean Architecture (.NET 8)

Proyecto de ejemplo con Clean Architecture para gestionar clientes.
Capas y responsabilidades:

Domain: entidades y reglas de negocio puras.

Application: casos de uso (servicios), DTOs, Requests/Responses, validaciones (FluentValidation), mapeos (AutoMapper).

Infrastructure: persistencia con EF Core (DbContext, repositorios).

WebApi: endpoints REST, serialización, Swagger.

Tecnologías: .NET 8, ASP.NET Core Web API, EF Core (SQL Server), AutoMapper, FluentValidation, Swagger.

Estructura de casos de uso:

Validación de entrada (FluentValidation).

Acceso a datos vía repositorio (Application → Infrastructure).

Mapeo Entity ↔ DTO (AutoMapper).

Respuestas uniformes con PagedResponse<T> (paginación).
