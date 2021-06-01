using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GraciousGiver_BackEnd.Data;
using GraciousGiver_BackEnd.Models;

namespace GraciousGiver_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QytetiController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public QytetiController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Qyteti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qyteti>>> GetQyteti()
        {
            return await _context.Qyteti.ToListAsync();
        }

        // GET: api/Qyteti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Qyteti>> GetQyteti(int id)
        {
            var prod = await _context.Qyteti.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        // PUT: api/Qyteti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Qyteti prod)
        {
            if (id != prod.CityId)
            {
                return BadRequest();
            }

            _context.Entry(prod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return (IActionResult)prod;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QytetiExists(id))
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

        // POST: api/Qyteti
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Qyteti>> PostQyteti(Qyteti prod)
        {
            _context.Qyteti.Add(prod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = prod.CityId }, prod);
        }

        // DELETE: api/Qyteti/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Qyteti>> DeleteQyteti(int id)
        {
            var prod = await _context.Qyteti.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.Qyteti.Remove(prod);
            await _context.SaveChangesAsync();

            return prod;
        }

        private bool QytetiExists(int id)
        {
            return _context.Qyteti.Any(e => e.CityId == id);
        }
    }
}