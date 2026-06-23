using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;
using proyectoef.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("cnTareas")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("Base de datos en memoria:" + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
  return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == Prioridad.Alta));
});


app.Run();
