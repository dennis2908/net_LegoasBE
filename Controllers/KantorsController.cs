using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_crud_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KantorsController : ControllerBase
{
  private readonly KantorContext _context;

  public KantorsController(KantorContext context)
  {
    _context = context;
  }

  // GET: api/kantors
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Kantor>>> GetKantors()
  {
    return await _context.Kantors.ToListAsync();
  }

  [Route("KantorData")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Kantor>>> KantorData(
        string? search
    )
    {
        bool b1 = string.IsNullOrEmpty(search); 
        if (!b1)
        {
            return await _context.Kantors
            .FromSqlRaw(
                $"Select * From kantor where nama_cabang like '%{search}%' order by Id desc"
            ).OrderByDescending (x => x.Id)
            .AsNoTracking()
            .ToListAsync();
        }
        else{
          return await _context.Kantors
            .FromSqlRaw(
                $"Select * From kantor order by Id desc"
            ).OrderByDescending (x => x.Id)
            .AsNoTracking()
            .ToListAsync();
        }

        
    }

  // GET: api/kantors/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Kantor>> GetKantor(int id)
  {
    var kantor = await _context.Kantors.FindAsync(id);

    if (kantor == null)
    {
      return NotFound();
    }

    return kantor;
  }

  // POST api/kantors
  [HttpPost]
  public async Task<ActionResult<Kantor>> PostKantor(Kantor kantor)
  {
    _context.Kantors.Add(kantor);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetKantor), new { id = kantor.Id }, kantor);
  }

  // PUT api/kantors/5
  [HttpPut("{id}")]
  public async Task<ActionResult<Kantor>> PutKantor(int id, Kantor kantor)
{
    if (id != kantor.Id)
    {
      return BadRequest();
    }

    _context.Entry(kantor).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    var kantorData = await _context.Kantors.FindAsync(id);

    if (kantorData == null)
    {
      return NotFound();
    }

    return kantorData;

}

  // DELETE api/kantors/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteKantor(int id)
  {
    var kantor = await _context.Kantors.FindAsync(id);

    if (kantor == null)
    {
      return NotFound();
    }

    _context.Kantors.Remove(kantor);
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