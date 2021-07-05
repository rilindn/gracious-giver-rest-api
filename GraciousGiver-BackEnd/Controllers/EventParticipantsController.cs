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
    public class EventParticipantsController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public EventParticipantsController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/EventParticipants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventParticipants>>> GetEventParticipants()
        {
            return await _context.EventParticipants.ToListAsync();
        }

        [HttpGet("amount/{nr}")]
        public async Task<ActionResult<IEnumerable<EventParticipants>>> GetEventParticipantsByAmount(int nr)
        {
            return await _context.EventParticipants.Take(nr).ToListAsync();
        }

        // GET: api/EventParticipants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventParticipants>> GetEventParticipants(int id)
        {
            var om = await _context.EventParticipants.FindAsync(id);

            if (om == null)
            {
                return NotFound();
            }

            return om;
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventParticipants(int id, EventParticipants om)
        {
            if (id != om.EventParticipantId)
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
                    if (!EventParticipantExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return new JsonResult("Participant  Updated Succesfully!");
            }
            return new JsonResult("Invalid data!");
        }

        // POST: api/OrganizationMember
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrganizationMember>> PostEventParticipants(EventParticipants om)
        {
            if (ModelState.IsValid)
            {
                _context.EventParticipants.Add(om);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEventParticipants", new { id = om.EventParticipantId }, om);
            }
            return new JsonResult("Invalid participant  data!");
        }

        // DELETE: api/OrganizationMember/5
        [HttpDelete("{id}/{eventId}")]
        public async Task<ActionResult<EventParticipants>> DeleteEventParticipants(int id, int eventId)
        {
            var om = _context.EventParticipants.Where(r => r.EventId == eventId && r.ParticipantId == id).FirstOrDefault();
            if (om == null)
            {
                return NotFound();
            }

            _context.EventParticipants.Remove(om);
            await _context.SaveChangesAsync();

            return new JsonResult("Participant Deleted  Succesfully!");
        }

        private bool EventParticipantExists(int id)
        {
            return _context.EventParticipants.Any(e => e.EventParticipantId == id);
        }
    }

}
