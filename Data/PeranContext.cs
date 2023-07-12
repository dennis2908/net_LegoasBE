using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public class PeranContext : DbContext
  {
    public PeranContext(DbContextOptions<PeranContext> options) : base(options)
    {
    }
    

    public DbSet<Peran> Perans { get; set; }
    
  }
}