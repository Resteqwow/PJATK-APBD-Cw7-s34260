using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s34260.Models;

namespace PJATK_APBD_Cw7_s34260.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    
    public DbSet<PCComponents> PCComponents { get; set; }
    
    public DbSet<PCs> PCs { get; set; }
}