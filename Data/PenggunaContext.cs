using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public class PenggunaContext : DbContext
  {
    public PenggunaContext(DbContextOptions<PenggunaContext> options) : base(options)
    {
    }

    public DbSet<Pengguna> Penggunas { get; set; }
    public DbSet<Kantor> Kantors { get; set; }

    public DbSet<Akun> Akuns { get; set; }

    public DbSet<IdAja> IdAjas { get; set; }
  }
}