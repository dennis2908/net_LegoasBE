using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("kantor")]
    public class Kantor
    {
        public int id;

        private string? kodeCabang;

        private string? namaCabang;

        [Column("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column("kode_cabang")]
        public string? KodeCabang
        {
            get { return kodeCabang; }
            set { kodeCabang = value; }
        }
        [Column("nama_cabang")]
        public string? NamaCabang
        {
            get { return namaCabang; }
            set { namaCabang = value; }
        }

        //public virtual List<Room> Rooms { get; set; }
    }
}
