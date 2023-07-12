using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public class AkunContext : DbContext
  {
    public AkunContext(DbContextOptions<AkunContext> options) : base(options)
    {   
    }

    public DbSet<Akun> Akuns { get; set; }

    public DbSet<Pengguna> Penggunas { get; set; }

    public DbSet<Peran> Perans { get; set; }

    public DbSet<Kantor> Kantors { get; set; }

    public DbSet<Layar> Layars { get; set; }

    public DbSet<PeranLayar> PeranLayars { get; set; }


  }
}