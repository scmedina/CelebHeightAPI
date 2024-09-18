using Microsoft.AspNetCore.Mvc;
using CelebHeightsAPI.Data;
using CelebHeightsAPI.Models;
using Microsoft.EntityFrameworkCore;
using CelebHeightsAPI.Models.CelebHeightsAPI.Models;

namespace CelebHeightsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CelebritiesController : ControllerBase
    {
        private readonly CelebContext _context;

        public CelebritiesController(CelebContext context)
        {
            _context = context;
        }

        // GET: api/Celebrities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Celebrity>>> GetCelebrities()
        {
            return await _context.Celebrities.ToListAsync();
        }

        // GET: api/Celebrities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Celebrity>> GetCelebrity(Guid id)
        {
            var celebrity = await _context.Celebrities.FindAsync(id);

            if (celebrity == null)
            {
                return NotFound();
            }

            return celebrity;
        }

        // POST: api/Celebrities
        [HttpPost]
        public async Task<ActionResult<Celebrity>> PostCelebrity(Celebrity celebrity)
        {
            _context.Celebrities.Add(celebrity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCelebrity), new { id = celebrity.Id }, celebrity);
        }

        // PUT: api/Celebrities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCelebrity(Guid id, Celebrity celebrity)
        {
            if (id != celebrity.Id)
            {
                return BadRequest();
            }

            _context.Entry(celebrity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelebrityExists(id))
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

        // DELETE: api/Celebrities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCelebrity(Guid id)
        {
            var celebrity = await _context.Celebrities.FindAsync(id);
            if (celebrity == null)
            {
                return NotFound();
            }

            _context.Celebrities.Remove(celebrity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CelebrityExists(Guid id)
        {
            return _context.Celebrities.Any(e => e.Id == id);
        }
    }
}
