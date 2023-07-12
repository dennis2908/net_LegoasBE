using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public class LayarContext : DbContext
  {
    public LayarContext(DbContextOptions<LayarContext> options) : base(options)
    {
    }

    public DbSet<Layar> Layars { get; set; }
  }
}