using GraciousGiver_BackEnd.Data;
using GraciousGiver_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationCategoryController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public OrganizationCategoryController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/OrganizationCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationCategory>>> GetOrganizationCategory()
        {
            return await _context.OrganizationCategory.ToListAsync();
        }

        // GET: api/OrganizationCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationCategory>> GetOrganizationCategory(int id)
        {
            var prod = await _context.OrganizationCategory.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<OrganizationCategory>>> GetOrganizationCategoryByAmount(int nr)
        {
            return await _context.OrganizationCategory.Take(nr).ToListAsync();
        }

        // PUT: api/OrganizationCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<OrganizationCategory>> PutOrganizationCategory(int id, OrganizationCategory prod)
        {
            if (id != prod.OrganizationCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(prod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return prod;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationCategoryExists(id))
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

        // POST: api/OrganizationCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrganizationCategory>> PostOrganizationCategory(OrganizationCategory prod)
        {
            try
            {
                _context.OrganizationCategory.Add(prod);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOrganizationCategory", new { id = prod.OrganizationCategoryId }, prod);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // DELETE: api/OrganizationCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrganizationCategory>> DeleteOrganizationCategory(int id)
        {
            var prod = await _context.OrganizationCategory.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.OrganizationCategory.Remove(prod);
            await _context.SaveChangesAsync();

            return prod;
        }

        private bool OrganizationCategoryExists(int id)
        {
            return _context.OrganizationCategory.Any(e => e.OrganizationCategoryId == id);
        }
    }
}
