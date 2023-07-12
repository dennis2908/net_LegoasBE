using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  [Table("layar")]
  public class Layar
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("kode_layar")]
    public string KodeLayar { get; set; } = null!;

    [Column("nama_layar")]
    public string NamaLayar { get; set; } = null!;

    //public virtual List<Room> Rooms { get; set; }  
    
  }
  
}