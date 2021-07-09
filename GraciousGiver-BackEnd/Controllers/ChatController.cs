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
    public class ChatController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public ChatController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Notification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChat()
        {
            return await _context.Chat.ToListAsync();
        }


        // GET: api/Chat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetChat(int id)
        {
            var not = await _context.Chat.FindAsync(id);

            if (not == null)
            {
                return NotFound();
            }

            return not;
        }
        
        // GET: api/Chat/5
        [HttpGet("acceptor/{id}")]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChatById(int id)
        {
            var not = await _context.Chat.Where(n=>n.AcceptorId==id || n.SenderId==id).ToListAsync();

            if (not == null)
            {
                return NotFound();
            }

            return not;
        }
        
        // GET: api/Chat/5
        [HttpGet("check/{FId}/{SId}")]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChatByASId(int FId, int SId)
        {
            var not = await _context.Chat.Where(n=>(n.AcceptorId== FId && n.SenderId== SId)||
            (n.AcceptorId == SId && n.SenderId == FId)).ToListAsync();

            if (not == null)
            {
                return NotFound();
            }

            return not;
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChat(int id, Chat chat)
        {
            if (id != chat.ChatId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Entry(chat).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatExists(id))
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

        // POST: api/Chat
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Chat>> PostChat(Chat chat)
        {
            if (ModelState.IsValid)
            {
                _context.Chat.Add(chat);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetChat", new { id = chat.ChatId }, chat);
            }
            return new JsonResult("Invalid Notification data!");
        }

        // DELETE: api/Chat/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chat>> DeleteChat(int id)
        {
            var not = await _context.Chat.FindAsync(id);
            if (not == null)
            {
                return NotFound();
            }

            _context.Chat.Remove(not);
            await _context.SaveChangesAsync();

            return new JsonResult("Notification Deleted  Succesfully!");
        }

        private bool ChatExists(int id)
        {
            return _context.Chat.Any(e => e.ChatId == id);
        }
    }

}
