using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  public class Login
  {

    private int IdPeran;
    private string? password;
    private string? nama;
    
    [Column("id_peran")]
    public int idPeran { get{return IdPeran;} set{IdPeran=value;} }

    [Column("nama")]
    public string? Nama { get{return nama;} set{nama=value;} }

    [Column("password")]
    public string? Password { get{return password;} set{password=value;} }


    //public virtual List<Room> Rooms { get; set; }  
    
  }
  
}