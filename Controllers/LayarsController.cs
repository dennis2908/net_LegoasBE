using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_crud_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LayarsController : ControllerBase
{
  private readonly LayarContext _context;

  public LayarsController(LayarContext context)
  {
    _context = context;
  }

  // GET: api/layars
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Layar>>> GetLayars()
  {
    return await _context.Layars.ToListAsync();
  }

  // GET: api/layars/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Layar>> GetLayar(int id)
  {
    var layar = await _context.Layars.FindAsync(id);

    if (layar == null)
    {
      return NotFound();
    }

    return layar;
  }

  [Route("LayarData")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Layar>>> LayarData(
        string? search
    )
    {
        bool b1 = string.IsNullOrEmpty(search); 
        if (!b1)
        {
            return await _context.Layars
            .FromSqlRaw(
                $"Select * From layar where nama_layar like '%{search}%' order by Id desc"
            ).OrderByDescending (x => x.Id)
            .AsNoTracking()
            .ToListAsync();
        }
        else{
          return await _context.Layars
            .FromSqlRaw(
                $"Select * From layar order by Id desc"
            ).OrderByDescending (x => x.Id)
            .AsNoTracking()
            .ToListAsync();
        }

        
    }

  // POST api/layars
  [HttpPost]
  public async Task<ActionResult<Layar>> PostLayar(Layar layar)
  {
    _context.Layars.Add(layar);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetLayar), new { id = layar.Id }, layar);
  }

  // PUT api/layars/5
  [HttpPut("{id}")]
  public async Task<ActionResult<Layar>> PutLayar(int id, Layar layar)
{
    if (id != layar.Id)
    {
      return BadRequest();
    }

    _context.Entry(layar).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    var layarData = await _context.Layars.FindAsync(id);

    if (layarData == null)
    {
      return NotFound();
    }

    return layarData;

}

  // DELETE api/layars/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteLayar(int id)
  {
    var layar = await _context.Layars.FindAsync(id);

    if (layar == null)
    {
      return NotFound();
    }

    _context.Layars.Remove(layar);
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