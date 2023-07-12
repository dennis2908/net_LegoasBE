using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  [Table("rooms")]
  public class Room
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("build_no")]
    public int buildNo { get; set; }
    
  }
}