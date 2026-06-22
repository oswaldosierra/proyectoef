using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(options =>
    options.UseNpgsql("Host=127.0.0.1;Port=5432;Database=profectoef;Username=postgres;Password=root"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("Base de datos en memoria:" + dbContext.Database.IsInMemory());
});

app.Run();
