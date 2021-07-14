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
    public class OrganizationMemberController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public OrganizationMemberController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/OrganizationMember
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationMember>>> GetOrganizationMember()
        {
            return await _context.OrganizationMember.ToListAsync();
        }

        [HttpGet("amount/{nr}")]
        public async Task<ActionResult<IEnumerable<OrganizationMember>>> GetOrganizationMemberByAmount(int nr)
        {
            return await _context.OrganizationMember.Take(nr).ToListAsync();
        }


        // GET: api/OrganizationMember/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationMember>> GetOrganizationMember(int id)
        {
            var om = await _context.OrganizationMember.FindAsync(id);

            if (om == null)
            {
                return NotFound();
            }

            return om;
        }
        
        [HttpGet("joined/{orgid}/{userid}")]
        public Boolean GetJoinedOrganizationMember(int orgid, int userid)
        {
            var om =  _context.OrganizationMember.Where(o => o.OrganizationId == orgid && o.UserId == userid).FirstOrDefault();

            if (om == null)
            {
                return false;
            }

            return true;
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationMember(int id, OrganizationMember om)
        {
            if (id != om.OrganizationMemberId)
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
                    if (!OrganizationMemberExists(id))
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

        // POST: api/OrganizationMember
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrganizationMember>> PostOrganizationMember(OrganizationMember om)
        {
            if (ModelState.IsValid)
            {
                _context.OrganizationMember.Add(om);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOrganizationMember", new { id = om.OrganizationMemberId }, om);
            }
            return new JsonResult("Invalid Organization Member data!");
        }

        // DELETE: api/OrganizationMember/5
        [HttpDelete("{id}/{orgId}")]
        public async Task<ActionResult<OrganizationMember>> DeleteOrganizationMember(int id,int orgId)
        {
            var om = _context.OrganizationMember.Where(r=>r.OrganizationId==orgId && r.UserId==id).FirstOrDefault();
            if (om == null)
            {
                return NotFound();
            }

            _context.OrganizationMember.Remove(om);
            await _context.SaveChangesAsync();

            return new JsonResult("Organization Member Deleted  Succesfully!");
        }

        private bool OrganizationMemberExists(int id)
        {
            return _context.OrganizationMember.Any(e => e.OrganizationMemberId == id);
        }
    }

}
