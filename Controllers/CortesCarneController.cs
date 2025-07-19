using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlmaCarne.Data;
using AlmaCarne.Models;

namespace AlmaCarne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CortesCarneController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CortesCarneController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CortesCarne
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorteCarne>>> GetCortesCarne()
        {
            return await (_context.CortesCarne?.ToListAsync() ?? Task.FromResult(new List<CorteCarne>()));
        }

        // GET: api/CortesCarne/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CorteCarne>> GetCorteCarne(int id)
        {
            if (_context.CortesCarne == null)
            {
                return NotFound();
            }

            var corte = await _context.CortesCarne.FindAsync(id);

            if (corte == null)
            {
                return NotFound();
            }

            return corte;
        }

        // POST: api/CortesCarne
        [HttpPost]
        public async Task<ActionResult<CorteCarne>> PostCorteCarne(CorteCarne corte)
        {
            if (_context.CortesCarne == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CortesCarne' is null.");
            }

            _context.CortesCarne.Add(corte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCorteCarne), new { id = corte.Id }, corte);
        }

        // PUT: api/CortesCarne/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorteCarne(int id, CorteCarne corte)
        {
            if (id != corte.Id)
            {
                return BadRequest();
            }

            _context.Entry(corte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorteCarneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/CortesCarne/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorteCarne(int id)
        {
            if (_context.CortesCarne == null)
            {
                return NotFound();
            }

            var corte = await _context.CortesCarne.FindAsync(id);
            if (corte == null)
            {
                return NotFound();
            }

            _context.CortesCarne.Remove(corte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorteCarneExists(int id)
        {
            return _context.CortesCarne?.Any(e => e.Id == id) == true;
        }
    }
}
