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
    public class EventsController : ControllerBase
    {
        private readonly GraciousDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EventsController(GraciousDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Events>>> GetEvent()
        {
            return await _context.Events.ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Events>> GetEvents(int id)
        {
            var ev = await _context.Events.FindAsync(id);

            if (ev == null)
            {
                return NotFound();
            }

            return ev;
        }

        [HttpGet("amount/{nr}")]
        public async Task<ActionResult<IEnumerable<Events>>> GetEventsByAmount(int nr)
        {
            return await _context.Events.Take(nr).ToListAsync();
        }

        [HttpGet("org/{id}")]
        public async Task<ActionResult<IEnumerable<Events>>> GetEventsByOrgId(int id)
        {
            return await _context.Events.Where(e=>e.OrganizationId==id).ToListAsync();
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvents(int id, Events ev)
        {
            if (id != ev.EventId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {

                _context.Entry(ev).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return new JsonResult("Event Updated Succesfully!");
            }
            return new JsonResult("Invalid Event data!");
        }

        // POST: api/Events
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Events>> PostEvents(Events ev)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(ev);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEvents", new { id = ev.EventId }, ev);
            }
            return new JsonResult("Invalid Event data!");
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Events>> DeleteEvents(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null)
            {
                return NotFound();
            }

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();

            return new JsonResult("Event Deleted  Succesfully!");
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/Organization/Events/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

