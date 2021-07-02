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
    public class StreetController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public StreetController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Street
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Street>>> GetStreet()
        {
            return await _context.Street.ToListAsync();
        }

        // GET: api/Street/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Street>> GetStreet(int id)
        {
            var prod = await _context.Street.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<Street>>> GetStreetByAmount(int nr)
        {
            return await _context.Street.Take(nr).ToListAsync();
        }

        // PUT: api/Street/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStreet(int id, Street prod)
        {
            if (id != prod.StreetId)
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
                if (!StreetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Street Updated Succesfully!");
        }
            return new JsonResult("Invalid street data!");
       }

        // POST: api/Street
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Street>> PostStreet(Street prod)
        {
            if (ModelState.IsValid)
            {
                _context.Street.Add(prod);
            await _context.SaveChangesAsync();

                return CreatedAtAction("GetStreet", new { id = prod.StreetId }, prod);

            }
            return new JsonResult("Invalid street data!");
        }
        // DELETE: api/Street/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Street>> DeleteStreet(int id)
        {
            var prod = await _context.Street.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.Street.Remove(prod);
            await _context.SaveChangesAsync();

            return new JsonResult("Street Deleted  Succesfully!");
        }

        private bool StreetExists(int id)
        {
            return _context.Street.Any(e => e.StreetId == id);
        }
    }
}