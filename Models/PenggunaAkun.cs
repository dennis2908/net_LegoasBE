using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PenggunaAkun
    {
        private int id;
        private int IdPeran;
        private string? namaAkun;

        private string? password;

        private DateTime tglDaftar;

        [Column("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column("id_peran")]
        public int idPeran
        {
            get { return IdPeran; }
            set { IdPeran = value; }
        }

        public string? NamaAkun
        {
            get { return namaAkun; }
            set { namaAkun = value; }
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

        public string? nama;
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

    }
}