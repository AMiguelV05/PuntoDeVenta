using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data;

[Table("entradas")]
public class Entrada
{
    [Key]
    [Column("entrada_id")]
    public long EntradaId { get; set; }

    [Required]
    [Column("fecha")]
    public DateTimeOffset Fecha { get; set; }

    [Required]
    [Column("proveedor_id")]
    public long ProveedorId { get; set; }

    [Column("empleado_id")]
    public long? EmpleadoId { get; set; }

    // FKs

    // Una Entrada viene de un Proveedor
    [ForeignKey("ProveedorId")]
    public virtual Proveedor Proveedor { get; set; } = null!;

    // Una Entrada es registrada por un Empleado [cite: 71]
    [ForeignKey("EmpleadoId")]
    public virtual Empleado? Empleado { get; set; }

    // Una Entrada tiene muchos DetalleEntrada
    public virtual ICollection<DetalleEntrada> DetalleEntradas { get; set; } = new List<DetalleEntrada>();
}