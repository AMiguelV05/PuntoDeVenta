using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data;

[Table("empleados")]
public class Empleado
{
    [Key]
    [Column("empleado_id")]
    public long EmpleadoId { get; set; }

    [Required]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Required]
    [Column("puesto")]
    public string Puesto { get; set; }

    [Required]
    [Column("telefono")]
    public string Telefono { get; set; }

    [Required]
    [Column("usuario")]
    public string Usuario { get; set; }

    [Required]
    [Column("contrasenia_hash")]
    public string ContraseniaHash { get; set; }

    // Un Empleado atiende muchas Ventas
    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();

    // Un Empleado registra muchas Entradas
    public virtual ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
}