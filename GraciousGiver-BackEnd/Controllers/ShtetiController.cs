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
    public class ShtetiController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public ShtetiController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Shteti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shteti>>> GetShteti()
        {
            return await _context.Shteti.ToListAsync();
        }

        // GET: api/Shteti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shteti>> GetShteti(int id)
        {
            var prod = await _context.Shteti.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<Shteti>>> GetStateByAmount(int nr)
        {
            return await _context.Shteti.Take(nr).ToListAsync();
        }

        // PUT: api/Shteti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShteti(int id, Shteti prod)
        {
            if (id != prod.ShtetiId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Entry(prod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShtetiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Shteti Updated Succesfully!");
        }
            return new JsonResult("Invalid state data!");
       }

        // POST: api/Shteti
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shteti>> PostShteti(Shteti prod)
        {
            if (ModelState.IsValid)
            {
                _context.Shteti.Add(prod);
            await _context.SaveChangesAsync();

               return CreatedAtAction("GetShteti", new { id = prod.ShtetiId }, prod);

            }
            return new JsonResult("Invalid state data!");
        }
        // DELETE: api/Shteti/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shteti>> DeleteShteti(int id)
        {
            var prod = await _context.Shteti.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.Shteti.Remove(prod);
            await _context.SaveChangesAsync();

            return new JsonResult("Shteti Deleted  Succesfully!");
        }

        private bool ShtetiExists(int id)
        {
            return _context.Shteti.Any(e => e.ShtetiId == id);
        }
    }
}