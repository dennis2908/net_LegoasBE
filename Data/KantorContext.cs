using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public class KantorContext : DbContext
  {
    public KantorContext(DbContextOptions<KantorContext> options) : base(options)
    {
    }

    public DbSet<Kantor> Kantors { get; set; }
  }
}