using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("akun")]
    public class AkunPenggunaPeran
    {
        private int id;
        private int IdPengguna;
        private int IdPeran;

        private string? nama;

        private string? password;

        private DateTime tglDaftar;

        [Column("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column("id_pengguna")]
        public int idPengguna
        {
            get { return IdPengguna; }
            set { IdPengguna = value; }
        }

        [Column("id_peran")]
        public int idPeran
        {
            get { return IdPeran; }
            set { IdPeran = value; }
        }

        [Column("nama")]
        public string? Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        [Column("password")]
        public string? Password
        {
            get { return password; }
            set { password = value; }
        }

        [Column(TypeName = "Date")]
        public DateTime tgl_daftar
        {
            get { return tglDaftar; }
            set { tglDaftar = value; }
        }

        // Pengguna

        public int kantor;

        public string? namaPengguna;
        public string? alamat;
        public string? kodePos;

        public string? provinsi;
        public string? namaCabang;

        public string? kodeCabang;

        public int Kantor
        {
            get { return kantor; }
            set { kantor = value; }
        }
        public string? NamaPengguna
        {
            get { return namaPengguna; }
            set { namaPengguna = value; }
        }

        [Column("alamat")]
        public string? Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

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

        public string? KodeCabang
        {
            get { return kodeCabang; }
            set { kodeCabang = value; }
        }
        public string? NamaCabang
        {
            get { return namaCabang; }
            set { namaCabang = value; }
        }

        //peran
        public string? kode_peran;
        public string? nama_peran;

        [Column("kode_peran")]
        public string? KodePeran { get {return kode_peran;} set{kode_peran = value;} }

        [Column("nama_peran")]
        public string? NamaPeran { get{return nama_peran;} set{nama_peran = value;} }

    }
}
