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
    public class PendingOrganizationsRequestController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public PendingOrganizationsRequestController(GraciousDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PendingOrganizationsRequest>>> GetPendingOrganizationsRequest()
        {
            return await _context.PendingOrganizationsRequest.Where(r => r.Checked == false).ToListAsync();

        }

        // GET: api/Organization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PendingOrganizationsRequest>> PendingOrganizationsRequest(int id)
        {
            var prod = await _context.PendingOrganizationsRequest.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        //amount
        [HttpGet("amount/{nr}")]
        public async Task<ActionResult<IEnumerable<PendingOrganizationsRequest>>> GetPendingOrganizationsRequest(int nr)
        {
            return await _context.PendingOrganizationsRequest.Take(nr).Where(r=>r.Checked==false).ToListAsync();
        }

        // PUT: api/Shteti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPendingOrganizationsRequest(int id, PendingOrganizationsRequest prod)
        {
            if (id != prod.OrganizationId)
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
                if (!PendingOrganizationsRequestExists(id))
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
            return new JsonResult("Invalid organization data!");
        }

        // POST: api/Organization
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Organization>> PostPendingOrganizationsRequest(PendingOrganizationsRequest prod)
        {
            if (ModelState.IsValid)
            {
                _context.PendingOrganizationsRequest.Add(prod);
            await _context.SaveChangesAsync();
            }
            return new JsonResult("Invalid organization data!");
        }

        // DELETE: api/Organization/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PendingOrganizationsRequest>> DeletePendingOrganizationsRequest(int id)
        {
            var prod = await _context.PendingOrganizationsRequest.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.PendingOrganizationsRequest.Remove(prod);
            await _context.SaveChangesAsync();

            return new JsonResult("Organization Deleted  Succesfully!");
        }

        private bool PendingOrganizationsRequestExists(int id)
        {
            return _context.PendingOrganizationsRequest.Any(e => e.OrganizationId == id);
        }
    }
}



