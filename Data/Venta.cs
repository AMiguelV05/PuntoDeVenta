using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PuntoDeVenta.Data;

namespace PuntoDeVenta.Data;


[Table("ventas")]
public class Venta
{
    [Key]
    [Column("venta_id")]
    public long VentaId { get; set; }

    [Required]
    [Column("fecha_venta")]
    public DateTimeOffset FechaVenta { get; set; }

    [Required]
    [Column("total")]
    public decimal Total { get; set; }

    [Column("cliente_id")]
    public long? ClienteId { get; set; }

    [Required]
    [Column("empleado_id")]
    public long EmpleadoId { get; set; }

    // FKs

    // Una Venta pertenece a un Cliente
    [ForeignKey("ClienteId")]
    public virtual Cliente? Cliente { get; set; } = null!;

    // Una Venta es atendida por un Empleado
    [ForeignKey("EmpleadoId")]
    public virtual Empleado Empleado { get; set; } = null!;

    // Una Venta tiene muchos DetalleVenta
    public virtual ICollection<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();

    // Una Venta puede tener muchas Facturas
    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}