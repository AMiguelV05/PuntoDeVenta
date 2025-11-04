using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data;

[Table("detalle_entrada")]
public class DetalleEntrada
{
    [Key]
    [Column("entrada_id", Order = 0)] // Primera columna de la PK
    public long EntradaId { get; set; }

    [Key]
    [Column("linea_num", Order = 1)] // Segunda columna de la PK
    public int LineaNum { get; set; }

    [Required]
    [Column("producto_id")]
    public long ProductoId { get; set; }

    [Required]
    [Column("cantidad")]
    public decimal Cantidad { get; set; }

    [Required]
    [Column("costo_unitario")]
    public decimal CostoUnitario { get; set; }

    // FKs

    // Este detalle pertenece a una Entrada
    [ForeignKey("EntradaId")]
    public virtual Entrada Entrada { get; set; } = null!;

    // Este detalle es de un Producto
    [ForeignKey("ProductoId")]
    public virtual Producto Producto { get; set; } = null!;
}