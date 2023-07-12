using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  [Table("akun")]
  public class Akun
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("id_pengguna")]
    public int idPengguna { get; set; }

    [Column("id_peran")]
    public int idPeran { get; set; }

    [Column("nama")]
    public string Nama { get; set; } = null!;

    [Column("password")]
    public string Password { get; set; } = null!;

    [Column(TypeName="Date")]
    public DateTime tgl_daftar { get; set; }
    
  }
}