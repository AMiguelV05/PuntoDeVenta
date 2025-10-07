using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PuntoDeVenta.Data;

namespace PuntoDeVenta.Data;

[Table("productos")] // El nombre exacto de la tabla en PostgreSQL
public class Producto
{
    [Key]
    [Column("producto_id")]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("precio_compra")]
    public decimal? PrecioCompra { get; set; }

    [Required(ErrorMessage = "El precio de venta es obligatorio")]
    [Column("precio_venta")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio de venta debe ser mayor a cero")]
    public decimal PrecioVenta { get; set; }

    [Required]
    [Column("stock_actual")]
    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
    public int StockActual { get; set; }

    [Column("categoria_id")]
    public int? CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    public virtual Categoria? Categoria { get; set; }
}