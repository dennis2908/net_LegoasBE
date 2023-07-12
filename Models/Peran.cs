using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  [Table("peran")]
  public class Peran
  {
    
    public int id ;
    public string? kode_peran;
    public string? nama_peran;

    [Column("id")]
    
    public int Id { get {return id;} set{id=value;} }

    [Column("kode_peran")]
    public string? KodePeran { get {return kode_peran;} set{kode_peran = value;} }

    [Column("nama_peran")]
    public string? NamaPeran { get{return nama_peran;} set{nama_peran = value;} }

    //public virtual List<Room> Rooms { get; set; }  
    
  }
  
}