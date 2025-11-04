using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data;

[Table("categorias")]
public class Categoria
{
    [Key]
    [Column("categoria_id")]
    public long CategoriaId { get; set; } 

    [Required] 
    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    // Una Categoria tiene muchos Productos
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}