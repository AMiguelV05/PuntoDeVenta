using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PuntoDeVenta.Data;

namespace PuntoDeVenta.Data;

[Table("productos")]
public class Producto
{
    [Key]
    [Column("producto_id")]
    public long ProductoId { get; set; }

    [Required]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("precio_compra")]
    public decimal? PrecioCompra { get; set; }

    [Required]
    [Column("precio_venta")]
    public decimal PrecioVenta { get; set; }

    [Required]
    [Column("stock_actual")]
    public int StockActual { get; set; }

    [Column("categoria_id")]
    public long? CategoriaId { get; set; }

    [Required]
    [Column("codigo_sku")]
    public string CodigoSku { get; set; }

    // FKs

    // Un Producto pertenece a una Categoria
    [ForeignKey("CategoriaId")]
    public virtual Categoria? Categoria { get; set; }

    //  Un Producto puede estar en muchos DetalleVenta
    public virtual ICollection<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();

    // Un Producto puede estar en muchos DetalleEntrada
    public virtual ICollection<DetalleEntrada> DetalleEntradas { get; set; } = new List<DetalleEntrada>();
}