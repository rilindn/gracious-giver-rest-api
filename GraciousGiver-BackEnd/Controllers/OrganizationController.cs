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
    public class OrganizationController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public OrganizationController(GraciousDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganization()
        {
            return await _context.Organization.ToListAsync();

        }

        // GET: api/Organization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(int id)
        {
            var prod = await _context.Organization.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<Organization>>> GetStateByAmount(int nr)
        {
            return await _context.Organization.Take(nr).ToListAsync();
        }

        // PUT: api/Shteti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization(int id, Organization prod)
        {
            if (id != prod.OrganizationId)
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
                if (!OrganizationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Organization Updated Succesfully!");
        }

        // POST: api/Organization
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Organization>> PostOrganization(Organization prod)
        {
            _context.Organization.Add(prod);
            await _context.SaveChangesAsync();



            return new JsonResult("Organization Posted Succesfully!");
        }

        // DELETE: api/Organization/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organization>> DeleteOrganization(int id)
        {
            var prod = await _context.Organization.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.Organization.Remove(prod);
            await _context.SaveChangesAsync();

            return new JsonResult("Organization Deleted  Succesfully!");
        }

        private bool OrganizationExists(int id)
        {
            return _context.Organization.Any(e => e.OrganizationId == id);
        }
    }
}



