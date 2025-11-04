using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data;

[Table("proveedores")]
public class Proveedor
{
    [Key]
    [Column("proveedor_id")]
    public long ProveedorId { get; set; }

    [Required]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Required]
    [Column("rfc")]
    public string Rfc { get; set; }

    [Required]
    [Column("telefono")]
    public string Telefono { get; set; }

    [Required]
    [Column("correo")]
    public string Correo { get; set; }

    [Required]
    [Column("direccion")]
    public string Direccion { get; set; }

    // Un Proveedor genera muchas Entradas
    public virtual ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
}