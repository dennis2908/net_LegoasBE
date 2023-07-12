using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public class PeranLayarContext : DbContext
  {
    public PeranLayarContext(DbContextOptions<PeranLayarContext> options) : base(options)
    {
    }
    

    public DbSet<PeranLayar> PeranLayars { get; set; }

    public DbSet<Peran> Perans { get; set; }

    public DbSet<Layar> Layars { get; set; }
    
  }
}