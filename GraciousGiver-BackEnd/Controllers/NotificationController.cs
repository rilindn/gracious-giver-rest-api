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
    public class NotificationController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public NotificationController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Notification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notifications>>> GetNotifications()
        {
            return await _context.Notifications.ToListAsync();
        }


        // GET: api/Notifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notifications>> GetNotifications(int id)
        {
            var not = await _context.Notifications.FindAsync(id);

            if (not == null)
            {
                return NotFound();
            }

            return not;
        }
        
        // GET: api/Notifications/5
        [HttpGet("acceptor/{id}")]
        public async Task<ActionResult<IEnumerable<Notifications>>> GetNotificationsById(int id)
        {
            var not = await _context.Notifications.Where(n=>n.Acceptor==id).ToListAsync();

            if (not == null)
            {
                return NotFound();
            }

            return not;
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotifications(int id, Notifications not)
        {
            if (id != not.NotificationId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Entry(not).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationsExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return new JsonResult("Notification Updated Succesfully!");
            }
            return new JsonResult("Invalid!");
        }

        // POST: api/Notifications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Notifications>> PostNotifications(Notifications not)
        {
            if (ModelState.IsValid)
            {
                _context.Notifications.Add(not);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetNotifications", new { id = not.NotificationId }, not);
            }
            return new JsonResult("Invalid Notification data!");
        }

        // DELETE: api/Notifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notifications>> DeleteNotifications(int id)
        {
            var not = await _context.Notifications.FindAsync(id);
            if (not == null)
            {
                return NotFound();
            }

            _context.Notifications.Remove(not);
            await _context.SaveChangesAsync();

            return new JsonResult("Notification Deleted  Succesfully!");
        }

        private bool NotificationsExists(int id)
        {
            return _context.Notifications.Any(e => e.NotificationId == id);
        }
    }

}
