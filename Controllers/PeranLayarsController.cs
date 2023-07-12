using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_crud_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeranLayarsController : ControllerBase
{
    private readonly PeranLayarContext _context;

    public PeranLayarsController(PeranLayarContext context)
    {
        _context = context;
    }

    // GET: api/peranLayars
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PeranLayar>>> GetPeranLayars()
    {
        return await _context.PeranLayars.ToListAsync();
    }

    // GET: api/peranLayars/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PeranLayar>> GetPeranLayar(int id)
    {
        var peranLayar = await _context.PeranLayars.FindAsync(id);

        if (peranLayar == null)
        {
            return NotFound();
        }

        return peranLayar;
    }

    // GET api/peranLayars/SearchByName/search={search}

    [Route("SearchByName")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PeranLayar>>> SearchByName(string search)
    {
        return await _context.PeranLayars
            .FromSqlRaw($"Select * From peranLayar where nama like '%{search}%'").OrderByDescending (x => x.Id)
            .AsNoTracking()
            .ToListAsync();
    }

    [Route("PeranLayarData")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PeranLayarDetail>>> PeranLayarData(string? search)
    {
        bool b1 = string.IsNullOrEmpty(search);
        if (!b1)
        {
            // return await _context.PeranLayars
            //     .FromSqlRaw(
            //         $"Select pengguna.*,kode_pos as kodePos From pengguna join kantor on kantor.Id = pengguna.kantor where nama like '%{search}%' order by kantor.Id desc"
            //     )
            //     .Select(s => new Pengguna { Id = s.Id, Kantor = 3 })
            //     .ToListAsync();
            return await (from a in _context.PeranLayars
                 join b in _context.Layars on a.idLayar equals b.Id
                 join c in _context.Perans on a.idPeran equals c.Id
                 select new PeranLayarDetail
                        {
                            Id = a.Id,
                            idLayar = a.idLayar,
                            idPeran = a.idPeran,
                            KodeLayar = b.KodeLayar,
                            NamaLayar = b.NamaLayar,
                            KodePeran = c.KodePeran,
                            NamaPeran = c.NamaPeran
                        }
             ).OrderByDescending (x => x.Id).Where(x => x.NamaPeran != null  && x.NamaPeran.Contains(""+search)).ToListAsync();
        }
        else
        {
            // return await _context.Penggunas
            //     .FromSqlRaw(
            //         $"Select pengguna.* From pengguna join kantor on kantor.Id = pengguna.kantor order by kantor.Id desc"
            //     ).Select(s => new Pengguna{Id = s.Id,Kantor = 2, kodePos = Pengguna.kodePos})
            //     .AsNoTracking()
            //     .ToListAsync();
            return await (from a in _context.PeranLayars
                 join b in _context.Layars on a.idLayar equals b.Id
                 join c in _context.Perans on a.idPeran equals c.Id
                 select new PeranLayarDetail
                        {
                            Id = a.Id,
                            idLayar = a.idLayar,
                            idPeran = a.idPeran,
                            KodeLayar = b.KodeLayar,
                            NamaLayar = b.NamaLayar,
                            KodePeran = c.KodePeran,
                            NamaPeran = c.NamaPeran
                        }
             ).OrderByDescending (x => x.Id).ToListAsync();
        }
    }

    // POST api/peranLayars
    [HttpPost]
    public async Task<ActionResult<PeranLayar>> PostPeranLayar(PeranLayar peranLayar)
    {
        _context.PeranLayars.Add(peranLayar);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPeranLayar), new { id = peranLayar.Id }, peranLayar);
    }

    // PUT api/peranLayars/5
    [HttpPut("{id}")]
    public async Task<ActionResult<PeranLayar>> PutPeranLayar(int id, PeranLayar peranLayar)
    {
        if (id != peranLayar.Id)
        {
            return BadRequest();
        }

        _context.Entry(peranLayar).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        var peranLayarData = await _context.PeranLayars.FindAsync(id);

        if (peranLayarData == null)
        {
            return NotFound();
        }

        return peranLayar;
    }

    // DELETE api/peranLayars/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePeranLayar(int id)
    {
        var peranLayar = await _context.PeranLayars.FindAsync(id);

        if (peranLayar == null)
        {
            return NotFound();
        }

        _context.PeranLayars.Remove(peranLayar);
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
