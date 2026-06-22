using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoef.Models;

public class Tarea
{
  [Key]
  public Guid TareaId { get; set; }

  [ForeignKey("CategoriaId")]
  public Guid CategoriaId { get; set; }

  [Required]
  [MaxLength(200)]
  public string Titulo { set; get; }
  public string Descipcion { set; get; }
  public Prioridad PrioridadTarea { set; get; }
  public DateTime FechaCreacion { set; get; }
  public virtual Categoria Categoria { set; get; }

  [NotMapped]
  public string Resumen { set; get; }
}

public enum Prioridad
{
  Alta,
  Media,
  Baja,
}