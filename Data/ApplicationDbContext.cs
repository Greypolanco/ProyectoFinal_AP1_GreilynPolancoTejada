using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal_AP1_GreilynPolancoTejada.Data;

public class ApplicationDbContext : IdentityDbContext
{
    #nullable disable
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Productos> Productos { get; set; }
    public DbSet<Categorias> Categorias { get; set; }
    public DbSet<Proveedores> Proveedores { get; set; }
    public DbSet<Compras> Compras { get; set; }
}
