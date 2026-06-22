namespace proyectoef.Models;

public class Tarea
{
  public Guid TareaId { get; set; }
  public Guid CategoriaId { get; set; }
  public string Titulo { set; get; }
  public string Descipcion { set; get; }
  public Prioridad PrioridadTarea { set; get; }
  public DateTime FechaCreacion { set; get; }
  public virtual Categoria Categoria { set; get; }
}

public enum Prioridad
{
  Alta,
  Media,
  Baja,
}