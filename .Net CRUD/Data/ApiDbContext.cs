using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostgresDb.Models;

namespace PostgresDb.Data;

public class ApiDbContext : DbContext
{

    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<DriverMadia> DriverMedias { get; set; }


    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Driver>(entity =>{
            
            // 1 - Many 

            entity.HasOne(t => t.Team)
            .WithMany(d => d.Drivers)
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Driver_Team");

            // 1 - 1 
            entity.HasOne(dm => dm.DriverMedia)
            .WithOne(d => d.Driver)
            .HasForeignKey<DriverMadia>(x => x.DriverId);
                    
        });







    }

}