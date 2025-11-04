using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data;

[Table("clientes")]
public class Cliente
{
    [Key]
    [Column("cliente_id")]
    public long ClienteId { get; set; }

    [Required]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Required]
    [Column("rfc")]
    public string Rfc { get; set; }

    [Column("telefono")]
    public string? Telefono { get; set; }

    [Column("correo")]
    public string? Correo { get; set; }

    [Column("direccion")]
    public string? Direccion { get; set; }

    // Un Cliente puede tener muchas Ventas
    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}