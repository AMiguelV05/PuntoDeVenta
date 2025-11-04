using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data;

[Table("facturas")]
public class Factura
{
    [Key]
    [Column("factura_id")]
    public long FacturaId { get; set; }

    [Required]
    [Column("folio")]
    public string Folio { get; set; }

    [Required]
    [Column("fecha_emision")]
    public DateTimeOffset FechaEmision { get; set; } 

    [Required]
    [Column("rfc_emisor")]
    public string RfcEmisor { get; set; }

    [Required]
    [Column("rfc_receptor")]
    public string RfcReceptor { get; set; }

    [Required]
    [Column("subtotal")]
    public decimal Subtotal { get; set; }

    [Required]
    [Column("impuestos")]
    public decimal Impuestos { get; set; }

    [Required]
    [Column("total")]
    public decimal Total { get; set; }

    [Required]
    [Column("estado")]
    public string Estado { get; set; }

    [Required]
    [Column("venta_id")]
    public long VentaId { get; set; }

    // FKs

    // Una Factura pertenece a una Venta
    [ForeignKey("VentaId")]
    public virtual Venta Venta { get; set; } = null!;
}