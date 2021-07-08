using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GraciousGiver_BackEnd.Data;
using GraciousGiver_BackEnd.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace GraciousGiver_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IniciativeController : ControllerBase
    {

        private readonly GraciousDbContext _context;

        public IniciativeController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Iniciative
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Iniciative>>> GetIniciative()
        {
            return await _context.Iniciative.ToListAsync();
        }

        // GET: api/Iniciative/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Iniciative>> GetIniciative(int id)
        {
            var inc = await _context.Iniciative.FindAsync(id);

            if (inc == null)
            {
                return NotFound();
            }

            return inc;
        }

        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<Iniciative>>> GetIniciativeByAmount(int nr)
        {
            return await _context.Iniciative.Take(nr).ToListAsync();
        }

        // PUT: api/Iniciative/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIniciative(int id, Iniciative inc)
        {
            if (id != inc.IniciativeId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {

                _context.Entry(inc).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IniciativeExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return new JsonResult("Iniciative Updated Succesfully!");
            }
            return new JsonResult("Invalid Iniciative data!");
        }

        // POST: api/Events
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Iniciative>> PostIniciative(Iniciative inc)
        {
            if (ModelState.IsValid)
            {
                _context.Iniciative.Add(inc);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetIniciative", new { id = inc.IniciativeId }, inc);
            }
            return new JsonResult("Invalid Iniciative data!");
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Iniciative>> DeleteIniciative(int id)
        {
            var inc = await _context.Iniciative.FindAsync(id);
            if (inc == null)
            {
                return NotFound();
            }

            _context.Iniciative.Remove(inc);
            await _context.SaveChangesAsync();

            return new JsonResult("Iniciative Deleted  Succesfully!");
        }

        private bool IniciativeExists(int id)
        {
            return _context.Iniciative.Any(e => e.IniciativeId == id);
        }
    }
}

