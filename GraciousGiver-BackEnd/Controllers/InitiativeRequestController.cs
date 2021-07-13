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

        // GET: api/InitiativeRequest
        [HttpGet("{orgId}")]
        public async Task<ActionResult<IEnumerable<InitiativeRequest>>> GetInitiativeRequestByOrgId( int orgId)
        {
            return await _context.InitiativeRequest.Where(r => r.Checked == false && r.OrganizationId == orgId).ToListAsync();
        }

        [HttpGet("amount/{nr}/{orgId}")]
        public async Task<ActionResult<IEnumerable<InitiativeRequest>>> GetInitiativeRequestByAmount(int nr,int orgId)
        {
            return await _context.InitiativeRequest.Where(r => r.Checked == false && r.OrganizationId==orgId).Take(nr).ToListAsync();
        }

        // GET: api/InitiativeRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InitiativeRequest>> GetInitiativeRequest(int id)
        {
            var om = await _context.InitiativeRequest.FindAsync(id);

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
            if (id != om.IniciativeRequestId)
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

        // POST: api/InitiativeRequest
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InitiativeRequest>> PostInitiativeRequest(InitiativeRequest om)
        {
            if (ModelState.IsValid)
            {
                _context.InitiativeRequest.Add(om);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetInitiativeRequest", new { id = om.IniciativeRequestId }, om);
            }
            return new JsonResult("Invalid Organization Member data!");
        }

        // DELETE: api/InitiativeRequest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InitiativeRequest>> DeleteInitiativeRequest(int id)
        {
            var om = _context.InitiativeRequest.Where(r => r.IniciativeRequestId == id).FirstOrDefault();
            if (om == null)
            {
                return NotFound();
            }

            _context.InitiativeRequest.Remove((InitiativeRequest)om);
            await _context.SaveChangesAsync();

            return new JsonResult("Organization Member Deleted Succesfully!");
        }

        private bool InitiativeRequestExists(int id)
        {
            return _context.InitiativeRequest.Any(e => e.IniciativeRequestId == id);
        }
    }

}
