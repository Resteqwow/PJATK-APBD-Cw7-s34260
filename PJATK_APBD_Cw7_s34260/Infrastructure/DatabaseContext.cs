using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s34260.Models;

namespace PJATK_APBD_Cw7_s34260.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    
    public DbSet<PcComponents> PCComponents { get; set; }
    
    public DbSet<PCs> PCs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PCs>().HasData([
            new PCs()
            {
                Id=1,
                Name="",
                Weight = 0.5f,
                Warranty = 2,
                CreatedAt = DateTime.Parse("2024-05-05") ,
                Stock = 4
            }
        ]);
        modelBuilder.Entity<ComponentManufacturers>().HasData([
            new ComponentManufacturers()
            {
                Id=1,
                Abbreviation = "pongos",
                FullName="pongos pongos",
                FoundationDate = DateTime.Parse("2024-05-05")
            }
        ]);
        modelBuilder.Entity<ComponentTypes>().HasData([
            new ComponentTypes()
            {
                Id=1,
                Abbreviation = "plingos",
                Name = "Plingos pangos",
            }

        ]);
        modelBuilder.Entity<Components>().HasData([
            new Components()
            {
                Code = "1234567891",
                Name = "panglor",
                Description = "panglor ultimax",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1,
            }
        ]);
        
        
        modelBuilder.Entity<PcComponents>().HasData([
            new PcComponents()
            {
                PCId = 1,
                ComponentCode = "1234567891",
                Amount = 50
            }
        
        ]);
    }
}