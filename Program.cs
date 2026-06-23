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
  return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
  tarea.TareaId = Guid.NewGuid();
  tarea.FechaCreacion = DateTime.UtcNow;

  await dbContext.Tareas.AddAsync(tarea);

  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
  var tareaActual = dbContext.Tareas.Find(id);

  if (tareaActual == null) return Results.NotFound();

  tareaActual.CategoriaId = tarea.CategoriaId;
  tareaActual.Titulo = tarea.Titulo;
  tareaActual.PrioridadTarea = tarea.PrioridadTarea;
  tareaActual.Descipcion = tarea.Descipcion;
  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
  Tarea? tareaActual = dbContext.Tareas.Find(id);

  if (tareaActual == null) return Results.NotFound();

  dbContext.Remove(tareaActual);

  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.Run();
