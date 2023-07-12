CREATE TABLE "akun" (
  "id" SERIAL PRIMARY KEY,
  "id_pengguna" INTEGER NOT NULL,
  "nama" VARCHAR(50) NOT NULL,
  "password" VARCHAR(100) NOT NULL,
  "tgl_daftar" DATE NOT NULL,
  "id_peran" INTEGER NOT NULL
);

CREATE TABLE "pengguna" (
  "id" SERIAL PRIMARY KEY,
  "nama" VARCHAR(50) NOT NULL,
  "alamat" VARCHAR(100) NOT NULL,
  "kode_pos" VARCHAR(255) NOT NULL,
  "provinsi" VARCHAR(50) NOT NULL,
  "kantor" INTEGER NOT NULL
);

CREATE TABLE "kantor" (
  "id" SERIAL PRIMARY KEY,
  "kode_cabang" VARCHAR(50) NOT NULL,
  "nama_cabang" VARCHAR(50) NOT NULL
);

CREATE TABLE "peran" (
  "id" SERIAL PRIMARY KEY,
  "kode_peran" VARCHAR(50) NOT NULL,
  "nama_peran" VARCHAR(50) NOT NULL
);

CREATE TABLE "layar" (
  "id" SERIAL PRIMARY KEY,
  "kode_layar" VARCHAR(50) NOT NULL,
  "nama_layar" VARCHAR(50) NOT NULL
);

CREATE TABLE "peranlayar" (
  "id" SERIAL PRIMARY KEY,
  "id_peran" INTEGER NOT NULL,
  "id_layar" INTEGER NOT NULL
);

insert into layar ("kode_layar","nama_layar") values ('001','Menu Pengguna'),('002','Menu Akun'),('003','Menu Kantor'),('004','Menu Peran'),('005','Menu Peran Layar'),('006','Akses Update')
    ,('007','Akses Tambah'),('008','Akses Hapus'),('009','Menu Layar'),('010','Menu Pengguna Akun');
insert into peran ("kode_peran","nama_peran") values ('001','Super Admin'),('002','Manajer'),('003','Admin Pengguna');
insert into kantor ("kode_cabang","nama_cabang") values ('001','Jakarta'),('002','Bogor'),('003','Surabaya');
insert into peranlayar ("id_peran","id_layar") values (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(2,1),(2,2),(2,3),(2,4),(2,5),(2,9),(3,1),(3,2),(3,10);
insert into pengguna ("nama","alamat","kode_pos","provinsi","kantor") values ('dennis dennis','jakarta jakarta jakarta jakarta','12333','DKI Jakarta',1),('maman maman','bogor bogor bogor bogor','23333','Jawa Barat',2),('alicia alicia','surabaya surabaya surabaya surabaya','43333','Jawa Barat',3);
insert into akun ("id_pengguna","id_peran","nama","password","tgl_daftar") values (1,1,'dennis01','dennis01','2020-02-02'),(2,2,'maman02','maman02','2020-03-02'),(3,3,'alicia03','alicia03','2020-04-02');