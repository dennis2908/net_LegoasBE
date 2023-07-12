using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;

namespace Models
{
    [Table("pengguna")]
    public class Pengguna
    {
        public int id;

        public string? nama;
        public string? alamat;
        public string? kodePos;

        public string? provinsi;

        public int kantor;

        [Column("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column("nama")]
        public string? Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        [Column("alamat")]
        public string? Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

        [Column("kode_pos")]
        public string? KodePos
        {
            get { return kodePos; }
            set { kodePos = value; }
        }

        [Column("provinsi")]
        public string? Provinsi
        {
            get { return provinsi; }
            set { provinsi = value; }
        }

        [Column("kantor")]
        public int Kantor
        {
            get { return kantor; }
            set { kantor = value; }
        }
    }
}
