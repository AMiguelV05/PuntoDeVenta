using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PuntoDeVenta.Data;

[Table("detalle_entrada")]
[PrimaryKey(nameof(EntradaId), nameof(LineaNum))]
public class DetalleEntrada
{
    [Column("entrada_id")] // Primera columna de la PK
    public long EntradaId { get; set; }

    [Column("linea_num")] // Segunda columna de la PK
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