using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_crud_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeransController : ControllerBase
{
  private readonly PeranContext _context;

  public PeransController(PeranContext context)
  {
    _context = context;
  }

  // GET: api/perans
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Peran>>> GetPerans()
  {
    return await _context.Perans.ToListAsync();
  }

  // GET: api/perans/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Peran>> GetPeran(int id)
  {
    var peran = await _context.Perans.FindAsync(id);

    if (peran == null)
    {
      return NotFound();
    }

    return peran;
  }

  [Route("PeranData")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Peran>>> PeranData(
        string? search
    )
    {
        bool b1 = string.IsNullOrEmpty(search); 
        if (!b1)
        {
            return await _context.Perans
            .FromSqlRaw(
                $"Select * From peran where nama_peran like '%{search}%' order by Id desc"
            )
            .AsNoTracking()
            .ToListAsync();
        }
        else{
          return await _context.Perans
            .FromSqlRaw(
                $"Select * From peran order by Id desc"
            )
            .AsNoTracking()
            .ToListAsync();
        }

        
    }

  // POST api/perans
  [HttpPost]
  public async Task<ActionResult<Peran>> PostPeran(Peran peran)
  {
    _context.Perans.Add(peran);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetPeran), new { id = peran.Id }, peran);
  }

  // PUT api/perans/5
  [HttpPut("{id}")]
  public async Task<ActionResult<Peran>> PutPeran(int id, Peran peran)
{
    if (id != peran.Id)
    {
      return BadRequest();
    }

    _context.Entry(peran).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    var peranData = await _context.Perans.FindAsync(id);

    if (peranData == null)
    {
      return NotFound();
    }

    return peranData;

}

  // DELETE api/perans/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletePeran(int id)
  {
    var peran = await _context.Perans.FindAsync(id);

    if (peran == null)
    {
      return NotFound();
    }

    _context.Perans.Remove(peran);
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