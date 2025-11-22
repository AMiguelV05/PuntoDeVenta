using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PuntoDeVenta.Data
{
    [Table("detalle_entrada")]
    [PrimaryKey(nameof(EntradaId), nameof(LineaNum))]
    public class DetalleEntrada
    {
        [Column("entrada_id")]
        public long EntradaId { get; set; }
        
        [ForeignKey("EntradaId")]
        public Entrada? Entrada { get; set; }

        [Column("linea_num")]
        public int LineaNum { get; set; }

        [Column("producto_id")]
        public long ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto? Producto { get; set; }

        [Column("cantidad")]
        public decimal Cantidad { get; set; }

        [Column("costo_unitario")]
        public decimal CostoUnitario { get; set; }
    }
}