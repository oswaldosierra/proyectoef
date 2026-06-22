using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext : DbContext
{
  public DbSet<Categoria> Categorias { set; get; }
  public DbSet<Tarea> Tareas { set; get; }
  public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }
}