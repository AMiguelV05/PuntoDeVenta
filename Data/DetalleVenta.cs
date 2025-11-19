using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PuntoDeVenta.Data;

[Table("detalle_venta")]
[PrimaryKey(nameof(VentaId), nameof(LineaNum))]
public class DetalleVenta
{
    [Column("venta_id")] // primera columna de la PK
    public long VentaId { get; set; }

    [Column("linea_num")] // segunda columna de la PK
    public int LineaNum { get; set; }

    [Required]
    [Column("cantidad")]
    public decimal Cantidad { get; set; }

    [Required]
    [Column("precio_unitario")]
    public decimal PrecioUnitario { get; set; }

    [Required]
    [Column("producto_id")]
    public long ProductoId { get; set; }

    [Column("descuento")]
    public decimal Descuento {get; set;}

    // FKs

    // Este detalle pertenece a una Venta
    [ForeignKey("VentaId")]
    public virtual Venta Venta { get; set; } = null!;

    // Este detalle es de un Producto
    [ForeignKey("ProductoId")]
    public virtual Producto Producto { get; set; } = null!;
}