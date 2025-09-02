# Shiftly  Control de jornada (SaaS)

**Stack:** .NET 8 (Web API, Clean Architecture + CQRS), EF Core + SQL Server, Angular 17, Redis, SignalR, Hangfire, Azure (Web App, SQL, App Insights).

## Estructura actual de la solución
Shiftly 
- **Shiftly.Domain** → Entidades y lógica de dominio (no depende de nadie).  
- **Shiftly.Application** → Casos de uso, CQRS, validaciones (depende solo de Domain).  
- **Shiftly.Infrastructure** → Persistencia, EF Core, servicios externos (depende de Application + Domain).  
- **Shiftly.Api** → Web API (depende de Application + Infrastructure).  
- tests (pendiente)

## Roadmap
0. Entorno. **Hecho**
1. Repo + `.sln` **Hecho** 
2. Clean Architecture (Domain, Application, Infrastructure, Api) **Hecho**
3. Paquetes base (MediatR, FluentValidation, Serilog, EF, Swagger)  **Actualmente**  
4. Docker Compose (SQL + Redis)  
5. Implementación de casos de uso iniciales (usuarios, fichajes)  
6. Integración Angular 17 (frontend)  
7. Autenticación y autorización con Identity  
8. Despliegue en Azure (App Service, SQL, App Insights)

---

## Cómo ejecutar
1. Clonar el repositorio  
2. Abrir `Shiftly.sln` en Visual Studio 2022  
3. Establecer **Shiftly.Api** como proyecto de inicio  
4. Ejecutar con **F5** → Swagger disponible en `https://localhost:<puerto>/swagger`  
