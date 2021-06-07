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
    public class GG_AdminController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public GG_AdminController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/GG_Admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GG_Admin>>> GetGG_Admin()
        {
            return await _context.GG_Admin.ToListAsync();
        }

        // GET: api/GG_Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GG_Admin>> GetGG_Admin(int id)
        {
            var prod = await _context.GG_Admin.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<GG_Admin>>> GetAdminsByAmount(int nr)
        {
            return await _context.GG_Admin.Take(nr).ToListAsync();
        }

        // PUT: api/GG_Admin/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGG_Admin(int id, GG_Admin prod)
        {
            if (id != prod.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(prod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GG_AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("GG_Admin Updated Succesfully!");
        }

        // POST: api/GG_Admin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GG_Admin>> PostGG_Admin(GG_Admin prod)
        {
            _context.GG_Admin.Add(prod);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetGG_Admin", new { id = prod.GG_AdminId }, prod);

            return new JsonResult("GG_Admin Posted Succesfully!");
        }

        // DELETE: api/GG_Admin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GG_Admin>> DeleteGG_Admin(int id)
        {
            var prod = await _context.GG_Admin.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.GG_Admin.Remove(prod);
            await _context.SaveChangesAsync();
            
            return new JsonResult("GG_Admin Deleted  Succesfully!");
        }

        private bool GG_AdminExists(int id)
        {
            return _context.GG_Admin.Any(e => e.AdminId == id);
        }
    }
}