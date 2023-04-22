using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostgresDb.Models;

namespace PostgresDb.Data;
public class AppDbContext: DbContext
{
    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<DriverMadia> DriverMedias { get; set; }


  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

}
