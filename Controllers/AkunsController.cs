using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace csharp_crud_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AkunsController : ControllerBase
{
    private readonly AkunContext _context;

    public AkunsController(AkunContext context)
    {
        _context = context;
    }

    // GET: api/akuns
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Akun>>> GetAkuns()
    {
        return await _context.Akuns.ToListAsync();
    }

    // GET: api/akuns/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Akun>> GetAkun(int id)
    {
        var akun = await _context.Akuns.FindAsync(id);

        if (akun == null)
        {
            return NotFound();
        }

        return akun;
    }

    // GET api/akuns/SearchByName/search={search}

    [Route("SearchByName")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Akun>>> SearchByName(
        string? search,
        string? criteria
    )
    {
        return await _context.Akuns
            .FromSqlRaw($"Select * From akun where {criteria} like '%{search}%'")
            .AsNoTracking()
            .ToListAsync();
    }

    [Route("AkunData")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AkunPenggunaPeran>>> AkunData(
        string? search,
        string? criteria
    )
    {
        bool b1 = string.IsNullOrEmpty(search);
        if (!b1)
        {
            if (criteria == "nama")
            {
                return await (
                    from a in _context.Akuns
                    join b in _context.Penggunas on a.idPengguna equals b.Id
                    join c in _context.Kantors on b.Kantor equals c.Id
                    join d in _context.Perans on a.idPeran equals d.Id
                    where a.Nama.Contains("" + search)
                    select new AkunPenggunaPeran
                    {
                        Id = a.Id,
                        idPengguna = a.idPengguna,
                        idPeran = a.idPeran,
                        Nama = a.Nama,
                        Password = a.Password,
                        tgl_daftar = a.tgl_daftar,
                        NamaPengguna = b.Nama,
                        Alamat = b.Alamat,
                        KodePos = b.KodePos,
                        Provinsi = b.Provinsi,
                        Kantor = b.Kantor,
                        KodeCabang = c.KodeCabang,
                        NamaCabang = c.NamaCabang,
                        KodePeran = d.KodePeran,
                        NamaPeran = d.NamaPeran
                    }
                ).OrderByDescending(x => x.Id).ToListAsync();
            }
            else
            {
                return await (
                    from a in _context.Akuns
                    join b in _context.Penggunas on a.idPengguna equals b.Id
                    join c in _context.Kantors on b.Kantor equals c.Id
                    join d in _context.Perans on a.idPeran equals d.Id
                    where d.NamaPeran.Contains("" + search)
                    select new AkunPenggunaPeran
                    {
                        Id = a.Id,
                        idPengguna = a.idPengguna,
                        idPeran = a.idPeran,
                        Nama = a.Nama,
                        Password = a.Password,
                        tgl_daftar = a.tgl_daftar,
                        NamaPengguna = b.Nama,
                        Alamat = b.Alamat,
                        KodePos = b.KodePos,
                        Provinsi = b.Provinsi,
                        Kantor = b.Kantor,
                        KodeCabang = c.KodeCabang,
                        NamaCabang = c.NamaCabang,
                        KodePeran = d.KodePeran,
                        NamaPeran = d.NamaPeran
                    }
                ).OrderByDescending(x => x.Id).ToListAsync();
            }
        }
        else
        {
            // return await _context.Penggunas
            //     .FromSqlRaw(
            //         $"Select pengguna.* From pengguna join kantor on kantor.Id = pengguna.kantor order by kantor.Id desc"
            //     ).Select(s => new Pengguna{Id = s.Id,Kantor = 2, kodePos = Pengguna.kodePos})
            //     .AsNoTracking()
            //     .ToListAsync();
            return await (
                from a in _context.Akuns
                join b in _context.Penggunas on a.idPengguna equals b.Id
                join c in _context.Kantors on b.Kantor equals c.Id
                join d in _context.Perans on a.idPeran equals d.Id
                select new AkunPenggunaPeran
                {
                    Id = a.Id,
                    idPengguna = a.idPengguna,
                    idPeran = a.idPeran,
                    Nama = a.Nama,
                    Password = a.Password,
                    tgl_daftar = a.tgl_daftar,
                    NamaPengguna = b.Nama,
                    Alamat = b.Alamat,
                    KodePos = b.KodePos,
                    Provinsi = b.Provinsi,
                    Kantor = b.Kantor,
                    KodeCabang = c.KodeCabang,
                    NamaCabang = c.NamaCabang,
                    KodePeran = d.KodePeran,
                    NamaPeran = d.NamaPeran
                }
            ).OrderByDescending(x => x.Id).ToListAsync();
        }
    }

    // POST api/akuns
    [HttpPost]
    public async Task<ActionResult<Akun>> PostAkun(Akun akun)
    {
        _context.Akuns.Add(akun);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAkun), new { id = akun.Id }, akun);
    }

    [Route("Login")]
    [HttpPost]
    public async Task<ActionResult<IEnumerable<Layar>>> Login(Login login)
    {
        // return await _context.Perans
        //     .FromSqlRaw(
        //         $"Select peran.* from akun join 'peranLayar' on akun.idPeran = peranLayar.id_peran join layar on peranLayar.id_layar = peran.id where akun.nama = '{login.Nama}' and akun.id_peran = '{login.idPeran}' and akun.password = '{login.Password}' group by peran.id,peran.nama_peran"
        //     )
        //     .ToListAsync();

        return await (
            from a in _context.Akuns
            join b in _context.PeranLayars on a.idPeran equals b.idPeran
            join c in _context.Layars on b.idLayar equals c.Id
            where a.Nama.Equals(login.Nama)
            where a.Password.Equals(login.Password)
            where a.idPeran.Equals(login.idPeran)
            select new Layar
            {
                Id = c.Id,
                NamaLayar = c.NamaLayar,
                KodeLayar = c.KodeLayar
            }
        ).ToListAsync();
    }

    // PUT api/akuns/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Akun>> PutAkuns(int id, Akun akun)
    {
        if (id != akun.Id)
        {
            return BadRequest();
        }

        _context.Entry(akun).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        var akunData = await _context.Akuns.FindAsync(id);

        if (akunData == null)
        {
            return NotFound();
        }

        return akunData;
    }

    // DELETE api/akuns/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAkun(int id)
    {
        var akun = await _context.Akuns.FindAsync(id);

        if (akun == null)
        {
            return NotFound();
        }

        _context.Akuns.Remove(akun);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // dummy endpoint to test the database connection
    [HttpGet("test")]
    public string Test()
    {
        return "Hello World!";
    }
}
