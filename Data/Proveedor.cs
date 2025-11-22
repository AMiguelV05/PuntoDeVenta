using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data
{
    [Table("proveedores")]
    public class Proveedor
    {
        [Key]
        [Column("proveedor_id")]
        public long ProveedorId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Column("nombre")]
        [StringLength(255)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RFC es obligatorio")]
        [Column("rfc")]
        [StringLength(13)]
        public string Rfc { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Column("telefono")]
        [StringLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [Column("correo")]
        [StringLength(255)]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [Column("direccion")]
        public string Direccion { get; set; } = string.Empty;

        // Un Proveedor genera muchas Entradas
        public virtual ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
    }
}