# SoporteLab - Mesa de Ayuda TI

Sistema básico de Mesa de Ayuda TI desarrollado con ASP.NET Core Web API y Blazor Server.

## Tecnologías utilizadas

- C# / .NET 8
- ASP.NET Core Web API
- Blazor Server
- Entity Framework Core
- SQLite

## Estructura del proyecto

```
SoporteLab/
├── SoporteLab.Api/     # API REST
└── SoporteLab.Web/     # Aplicación Web Blazor
```

## Pasos para ejecutar la API

1. Abrir una terminal y navegar a la carpeta de la API:
```bash
cd SoporteLab.Api
```

2. Ejecutar la API:
```bash
dotnet run
```

3. La API estará disponible en: `http://localhost:5039`
4. Swagger UI disponible en: `http://localhost:5039/swagger`

## Pasos para ejecutar la Web

1. Abrir una segunda terminal y navegar a la carpeta Web:
```bash
cd SoporteLab.Web
```

2. Ejecutar la aplicación Web:
```bash
dotnet run
```

3. La Web estará disponible en: `http://localhost:5270`
4. Página de tickets: `http://localhost:5270/tickets`

## Puertos utilizados

| Proyecto | Puerto |
|----------|--------|
| SoporteLab.Api | 5039 |
| SoporteLab.Web | 5270 |

## Endpoints de la API

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/tickets | Listar todos los tickets |
| GET | /api/tickets/{id} | Consultar ticket por ID |
| POST | /api/tickets | Crear nuevo ticket |
| PUT | /api/tickets/{id} | Actualizar ticket |
| DELETE | /api/tickets/{id} | Eliminar ticket |
| GET | /api/tickets/estado/{estado} | Filtrar por estado |
| GET | /api/tickets/prioridad/{prioridad} | Filtrar por prioridad |
| GET | /api/tickets/abiertos | Tickets abiertos o en proceso |

## Ejemplos de datos de prueba

```json
{
  "titulo": "PC no enciende",
  "descripcion": "La computadora del puesto 3 no enciende al presionar el botón de encendido.",
  "categoria": "Hardware",
  "prioridad": "Alta",
  "estado": "Abierto",
  "solicitante": "María González"
}
```

```json
{
  "titulo": "Sin acceso a internet",
  "descripcion": "El equipo del laboratorio 2 no tiene conexión a la red.",
  "categoria": "Red",
  "prioridad": "Crítica",
  "estado": "Abierto",
  "solicitante": "Carlos Mora"
}
```

```json
{
  "titulo": "Error al instalar software",
  "descripcion": "No se puede instalar Microsoft Office en el puesto 7.",
  "categoria": "Software",
  "prioridad": "Media",
  "estado": "En proceso",
  "solicitante": "Laura Jiménez"
}
```

## Problemas encontrados y solución aplicada

- **Incompatibilidad de versiones**: El proyecto se creó inicialmente con .NET 10. Se resolvió configurando `global.json` con la versión `8.0.422` y actualizando el `TargetFramework` en el `.csproj` a `net8.0`.
- **Paquetes EF Core incompatibles**: Los paquetes de Entity Framework se instalaron en versión 10. Se removieron y se reinstalaron con versión compatible con .NET 8.
- **Swagger no disponible**: Se instaló el paquete `Swashbuckle.AspNetCore` versión `6.6.2` para habilitar Swagger en .NET 8.
- **CORS bloqueando peticiones**: La aplicación Web no podía consumir la API por restricciones de CORS. Se configuró `AddCors` y `UseCors` en el `Program.cs` de la API.
