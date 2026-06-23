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
    modelBuilder.Entity<Categoria>(categoria =>
    {
      categoria.ToTable("categoria");
      categoria.HasKey(p => p.CategoriaId);
      categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
      categoria.Property(p => p.Descripcion);
    });

    modelBuilder.Entity<Tarea>(tarea =>
    {
      tarea.ToTable("tarea");
      tarea.HasKey(p => p.TareaId);

      tarea.HasOne(p => p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaId);

      tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
      tarea.Property(p => p.Descipcion);
      tarea.Property(p => p.PrioridadTarea);
      tarea.Property(p => p.FechaCreacion);
      tarea.Ignore(p => p.Resumen);
    });
  }
}