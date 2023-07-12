using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  [Table("peranLayar")]
  public class PeranLayarDetail
  {
    
    public int id ;
    public int IdPeran;
    public int IdLayar;
    public string? namaPeran;
    public string? kodePeran;
    public string? namaLayar;
    public string? kodeLayar;

    [Column("id")]
    
    public int Id { get {return id;} set{id=value;} }

    [Column("id_peran")]
    
    public int idPeran { get {return IdPeran;} set{IdPeran=value;} }

    [Column("id_layar")]
    
    public int idLayar { get {return IdLayar;} set{IdLayar=value;} }

    [Column("kode_peran")]
    
    public string? KodeLayar { get {return kodeLayar;} set{kodeLayar=value;} }

    public string? NamaLayar { get {return namaLayar;} set{namaLayar=value;} }

    public string? NamaPeran { get {return namaPeran;} set{namaPeran=value;} }

    public string? KodePeran { get {return kodePeran;} set{kodePeran=value;} }
    //public virtual List<Room> Rooms { get; set; }  
    
  }
  
}