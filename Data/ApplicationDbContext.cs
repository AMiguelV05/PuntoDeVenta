using Microsoft.EntityFrameworkCore;

namespace PuntoDeVenta.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    // Aquí agregarás los otros DbSet para Empleado, Cliente, Venta, etc.
}