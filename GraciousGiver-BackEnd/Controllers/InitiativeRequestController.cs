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
    public class InitiativeRequestController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public InitiativeRequestController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/OrganizationMemberRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationMemberRequest>>> GetOrganizationMemberRequest()
        {
            return await _context.OrganizationMemberRequest.Where(r => r.Checked == false).ToListAsync();
        }

        [HttpGet("amount/{nr}")]
        public async Task<ActionResult<IEnumerable<OrganizationMemberRequest>>> GetOrganizationMemberRequestByAmount(int nr)
        {
            return await _context.OrganizationMemberRequest.Where(r => r.Checked == false).Take(nr).ToListAsync();
        }

        // GET: api/OrganizationMemberRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationMemberRequest>> GetOrganizationMemberRequest(int id)
        {
            var om = await _context.OrganizationMemberRequest.FindAsync(id);

            if (om == null)
            {
                return NotFound();
            }

            return om;
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult>PutInitiativeRequest(int id,InitiativeRequest om)
        {
            if (id != om.InitativeRequestId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Entry(om).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InitiativeRequestExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return new JsonResult("Organization Member Updated Succesfully!");
            }
            return new JsonResult("Invalid data!");
        }

        // POST: api/OrganizationMemberRequest
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrganizationMemberRequest>> PostOrganizationMemberRequest(OrganizationMemberRequest om)
        {
            if (ModelState.IsValid)
            {
                _context.OrganizationMemberRequest.Add(om);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOrganizationMemberRequest", new { id = om.OrganizationMemberRequestId }, om);
            }
            return new JsonResult("Invalid Organization Member data!");
        }

        // DELETE: api/OrganizationMemberRequest/5
        [HttpDelete("{id}/{orgId}")]
        public async Task<ActionResult<OrganizationMemberRequest>> DeleteOrganizationMemberRequest(int id, int orgId)
        {
            var om = _context.OrganizationMemberRequest.Where(r => r.OrganizationId == orgId && r.UserId == id).FirstOrDefault();
            if (om == null)
            {
                return NotFound();
            }

            _context.OrganizationMemberRequest.Remove((OrganizationMemberRequest)om);
            await _context.SaveChangesAsync();

            return new JsonResult("Organization Member Deleted  Succesfully!");
        }

        private bool InitiativeRequestExists(int id)
        {
            return _context.OrganizationMemberRequest.Any(e => e.OrganizationMemberRequestId == id);
        }
    }

}
