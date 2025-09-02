# Shiftly  Control de jornada (SaaS)

**Stack:** .NET 8 (Web API, Clean Architecture + CQRS), EF Core + SQL Server, Angular 17, Redis, SignalR, Hangfire, Azure (Web App, SQL, App Insights).

## Estructura
- `src/` proyectos de aplicación
- `tests/` pruebas unitarias/integración
- `Directory.Build.props` convenciones globales
- `global.json` SDK fijado a .NET 8

## Roadmap (fijo)
0) Entorno 
1) Repo + .sln 
2) Clean Architecture (Domain, Application, Infrastructure, Api)
3) Paquetes base (MediatR, FluentValidation, Serilog, EF, Swagger)
4) Docker Compose (SQL + Redis)
...
