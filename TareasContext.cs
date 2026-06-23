using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext : DbContext
{
  public DbSet<Categoria> Categorias { set; get; }
  public DbSet<Tarea> Tareas { set; get; }
  public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Categoria> categoriaInit = new List<Categoria>();
    categoriaInit.Add(
      new Categoria()
      {
        CategoriaId = Guid.Parse("eb23b083-4305-493a-a4a5-cdc10f9d3ed1"),
        Nombre = "Actividades Pendientes",
        // Descripcion = "Actividades que no se han completado",
        Peso = 20
      }
    );
    categoriaInit.Add(
      new Categoria()
      {
        CategoriaId = Guid.Parse("42bef976-8e21-43e7-b2de-d856f4dcf491"),
        Nombre = "Actividades Vencidas",
        // Descripcion = "Actividades que ya no se pueden completar",
        Peso = 50
      }
    );

    modelBuilder.Entity<Categoria>(categoria =>
    {
      categoria.ToTable("categoria");
      categoria.HasKey(p => p.CategoriaId);
      categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
      categoria.Property(p => p.Descripcion).IsRequired(false);
      categoria.Property(p => p.Peso);

      categoria.HasData(categoriaInit);
    });

    List<Tarea> tareaInit = new List<Tarea>();
    tareaInit.Add(
      new Tarea()
      {
        TareaId = Guid.Parse("a982d8ee-1452-446a-aeed-41ef33719ee8"),
        CategoriaId = Guid.Parse("eb23b083-4305-493a-a4a5-cdc10f9d3ed1"),
        Titulo = "Lavar Platos",
        PrioridadTarea = Prioridad.Media,
        FechaCreacion = new DateTime(2026,1,2,0,0,0,DateTimeKind.Utc)
      }
    );
    tareaInit.Add(
      new Tarea()
      {
        TareaId = Guid.Parse("6cf5e8bc-31e4-4eb0-b4a3-e2b658cbabf8"),
        CategoriaId = Guid.Parse("42bef976-8e21-43e7-b2de-d856f4dcf491"),
        Titulo = "Pagar Servicios",
        PrioridadTarea = Prioridad.Alta,
        FechaCreacion = new DateTime(2026,1,1,0,0,0,DateTimeKind.Utc)
      }
    );

    modelBuilder.Entity<Tarea>(tarea =>
    {
      tarea.ToTable("tarea");
      tarea.HasKey(p => p.TareaId);
      tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
      tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
      tarea.Property(p => p.Descipcion).IsRequired(false);
      tarea.Property(p => p.PrioridadTarea);
      tarea.Property(p => p.FechaCreacion);
      tarea.Ignore(p => p.Resumen);

      tarea.HasData(tareaInit);
    });
  }
}