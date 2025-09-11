using Serilog;
using System.Reflection;
using Shiftly.Infrastructure;


// --- Serilog bootstrap (antes de crear el builder)
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Reemplaza logging por Serilog
builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console());

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Infraestructura (EF Core)
builder.Services.AddInfrastructure(builder.Configuration);

// MediatR: registramos el assembly de Application
var applicationAssembly = Assembly.Load("Shiftly.Application");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

// CORS básico para luego (Angular 17 en http://localhost:4200)
builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend", p =>
        p.WithOrigins("http://localhost:4200")
         .AllowAnyHeader()
         .AllowAnyMethod()
         .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// pipeline
app.UseHttpsRedirection();
app.UseCors("frontend");
app.MapControllers();

// Logging de arranque
app.Logger.LogInformation("Shiftly API booted");

// run
app.Run();

