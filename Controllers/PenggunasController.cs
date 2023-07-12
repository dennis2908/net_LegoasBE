using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_crud_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PenggunasController : ControllerBase
{
    private readonly PenggunaContext _context;

    public PenggunasController(PenggunaContext context)
    {
        _context = context;
    }

    // GET: api/penggunas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pengguna>>> GetPenggunas()
    {
        return await _context.Penggunas.ToListAsync();
    }

    // GET: api/penggunas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pengguna>> GetPengguna(int id)
    {
        var pengguna = await _context.Penggunas.FindAsync(id);

        if (pengguna == null)
        {
            return NotFound();
        }

        return pengguna;
    }

    // GET api/penggunas/SearchByName/search={search}

    [Route("SearchByName")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pengguna>>> SearchByName(string search)
    {
        return await _context.Penggunas
            .FromSqlRaw($"Select * From pengguna where nama like '%{search}%'")
            .OrderByDescending(x => x.Id)
            .AsNoTracking()
            .ToListAsync();
    }

    [Route("PenggunaData")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PenggunaKantor>>> PenggunaData(
        string? search,
        string? criteria
    )
    {
        bool b1 = string.IsNullOrEmpty(search);
        if (!b1)
        {
            // return await _context.Penggunas
            //     .FromSqlRaw(
            //         $"Select pengguna.*,kode_pos as kodePos From pengguna join kantor on kantor.Id = pengguna.kantor where nama like '%{search}%' order by kantor.Id desc"
            //     )
            //     .Select(s => new Pengguna { Id = s.Id, Kantor = 3 })
            //     .ToListAsync();
            // return await _context.Penggunas
            //     .Join(
            //         _context.Kantors,
            //         emp => emp.Kantor,
            //         en => en.Id,
            //         (emp, per) =>
            //             new PenggunaKantor
            //             {
            //                 Kantor = per.Id,
            //                 Id = emp.Id,
            //                 NamaCabang = per.NamaCabang,
            //                 KodeCabang = per.KodeCabang,
            //                 Alamat = emp.Alamat,
            //                 Nama = emp.Nama,
            //                 Provinsi = emp.Provinsi,
            //                 kodePos = emp.kodePos
            //             }
            //     ).OrderByDescending (x => x.Id)
            //     .Where(en => en.Nama.Contains(search ?? ""))
            //     .ToListAsync();

            if (criteria == "nama")
            {
                return await (
                    from per in _context.Penggunas
                    join emp in _context.Kantors on per.Kantor equals emp.Id
                    where per.Nama.Contains("" + search)
                    select new PenggunaKantor
                    {
                        Kantor = per.Kantor,
                        Id = per.Id,
                        NamaCabang = emp.NamaCabang,
                        KodeCabang = emp.KodeCabang,
                        Alamat = per.Alamat,
                        Nama = per.Nama,
                        Provinsi = per.Provinsi,
                        kodePos = per.kodePos
                    }
                ).OrderByDescending(x => x.Id).ToListAsync();
            }
            else
            {
                return await (
                    from per in _context.Penggunas
                    join emp in _context.Kantors on per.Kantor equals emp.Id
                    where per.Alamat.Contains("" + search)
                    select new PenggunaKantor
                    {
                        Kantor = emp.Id,
                        Id = per.Id,
                        NamaCabang = emp.NamaCabang,
                        KodeCabang = emp.KodeCabang,
                        Alamat = per.Alamat,
                        Nama = per.Nama,
                        Provinsi = per.Provinsi,
                        kodePos = per.kodePos
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
                from per in _context.Penggunas
                join emp in _context.Kantors on per.Kantor equals emp.Id
                select new PenggunaKantor
                {
                    Kantor = emp.Id,
                    Id = per.Id,
                    NamaCabang = emp.NamaCabang,
                    KodeCabang = emp.KodeCabang,
                    Alamat = per.Alamat,
                    Nama = per.Nama,
                    Provinsi = per.Provinsi,
                    kodePos = per.kodePos
                }
            ).OrderByDescending(x => x.Id).ToListAsync();
        }
    }

    // POST api/penggunas
    [HttpPost]
    public async Task<ActionResult<Layar>> PostPengguna(Pengguna pengguna)
    {
        _context.Penggunas.Add(pengguna);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPengguna), new { id = pengguna.Id }, pengguna);
    }

    [Route("PenggunaAkun")]
    [HttpPost]
    public async Task<ActionResult<Layar>> PostPenggunaAkun(PenggunaAkun penggunaAkun)
    {
        var penggunaData = new Pengguna();
        var akunData = new Akun();
        penggunaData.Nama = penggunaAkun.Nama;
        penggunaData.Alamat = penggunaAkun.Alamat;
        penggunaData.KodePos = penggunaAkun.KodePos;
        penggunaData.Provinsi = penggunaAkun.Provinsi;
        penggunaData.Kantor = penggunaAkun.Kantor;

        var dataBack = await _context.IdAjas
            .FromSqlRaw(
                $"INSERT INTO pengguna (nama,alamat,kode_pos,provinsi,kantor) VALUES ('{penggunaData.Nama}', '{penggunaData.Alamat}', '{penggunaData.KodePos}', '{penggunaData.Provinsi}', '{penggunaData.Kantor}') RETURNING id;"
            )
            .ToListAsync();

        akunData.idPengguna = dataBack[0].Id;
        akunData.Nama = penggunaAkun.NamaAkun;
        akunData.Password = penggunaAkun.Password;
        akunData.tgl_daftar = penggunaAkun.tgl_daftar;
        akunData.idPeran = penggunaAkun.idPeran;

        _context.Akuns.Add(akunData);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPengguna), new { id = penggunaData.Id }, penggunaData);

        // return CreatedAtAction(nameof(GetPengguna), new { id = pengguna.Id }, pengguna);
    }

    // PUT api/Penggunas/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Pengguna>> PutPengguna(int id, Pengguna pengguna)
    {
        if (id != pengguna.Id)
        {
            return BadRequest();
        }

        _context.Entry(pengguna).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        var penggunaData = await _context.Penggunas.FindAsync(id);

        if (penggunaData == null)
        {
            return NotFound();
        }

        return penggunaData;
    }

    // DELETE api/penggunas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePengguna(int id)
    {
        var pengguna = await _context.Penggunas.FindAsync(id);

        if (pengguna == null)
        {
            return NotFound();
        }

        _context.Penggunas.Remove(pengguna);
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
