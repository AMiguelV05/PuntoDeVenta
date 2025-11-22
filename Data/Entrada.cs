using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data
{
    [Table("entradas")]
    public class Entrada
    {
        [Key]
        [Column("entrada_id")]
        public long EntradaId { get; set; }

        [Column("fecha")]
        public DateTimeOffset Fecha { get; set; }

        [Column("proveedor_id")]
        public long ProveedorId { get; set; }

        [ForeignKey("ProveedorId")]
        public Proveedor? Proveedor { get; set; }

        [Column("empleado_id")]
        public long? EmpleadoId { get; set; }

        [ForeignKey("EmpleadoId")]
        public Empleado? Empleado { get; set; }

        // Relación con detalle
        public ICollection<DetalleEntrada> Detalles { get; set; } = new List<DetalleEntrada>();
    }
}