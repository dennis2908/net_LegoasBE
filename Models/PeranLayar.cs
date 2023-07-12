using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  [Table("peranlayar")]
  public class PeranLayar
  {
    
    public int id ;
    public int IdPeran;
    public int IdLayar;

    [Column("id")]
    
    public int Id { get {return id;} set{id=value;} }

    [Column("id_peran")]
    
    public int idPeran { get {return IdPeran;} set{IdPeran=value;} }

    [Column("id_layar")]
    
    public int idLayar { get {return IdLayar;} set{IdLayar=value;} }
    //public virtual List<Room> Rooms { get; set; }  
    
  }
  
}