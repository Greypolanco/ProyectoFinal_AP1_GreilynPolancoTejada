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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categorias>().HasData(
            new Categorias{
                CategoriaId = 1,
                Nombre ="Papeleria",
                Total = 0
            },
            new Categorias{
                CategoriaId =2,
                Nombre = "Escritura",
                Total = 0
            },
            new Categorias{
                CategoriaId = 3,
                Nombre = "Arte Y Manualidad",
                Total = 0
            },
            new Categorias{
                CategoriaId = 4,
                Nombre ="Libros",
                Total = 0
            },
            new Categorias{
                CategoriaId = 5,
                Nombre = "Suministros de Oficina",
                Total = 0
            },
            new Categorias{
                CategoriaId = 6,
                Nombre = "Electronica",
                Total = 0
            }
        );
    }
}
