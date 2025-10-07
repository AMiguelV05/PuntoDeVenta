using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data;

[Table("categoria")] // El nombre exacto de la tabla en PostgreSQL
public class Categoria
{
    [Key]
    [Required]
    [Column("categoria_id")]
    public int CategoriaId { get; set; }

    [Required]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }
}