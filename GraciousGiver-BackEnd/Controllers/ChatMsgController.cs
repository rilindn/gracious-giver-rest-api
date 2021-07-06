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
    public class ChatMsgController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public ChatMsgController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Notification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatMsg>>> GetChatMsg()
        {
            return await _context.ChatMsg.ToListAsync();
        }


        // GET: api/ChatMsg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatMsg>> GetChatMsg(int id)
        {
            var not = await _context.ChatMsg.FindAsync(id);

            if (not == null)
            {
                return NotFound();
            }

            return not;
        }
        
        // GET: api/ChatMsg/5
        [HttpGet("acceptor/{id}/{sId}")]
        public async Task<ActionResult<IEnumerable<ChatMsg>>> GetChatMsgById(int id,int sId)
        {
            var not = await _context.ChatMsg.
                Where(n=>(n.AcceptorId==id && n.SenderId==sId) || (n.AcceptorId == sId && n.SenderId == id)).ToListAsync();

            if (not == null)
            {
                return NotFound();
            }

            return not;
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatMsg(int id, ChatMsg not)
        {
            if (id != not.MessageId)
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
                    if (!ChatMsgExists(id))
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

        // POST: api/ChatMsg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChatMsg>> PostChatMsg(ChatMsg not)
        {
            if (ModelState.IsValid)
            {
                _context.ChatMsg.Add(not);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetChatMsg", new { id = not.MessageId }, not);
            }
            return new JsonResult("Invalid Notification data!");
        }

        // DELETE: api/ChatMsg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChatMsg>> DeleteChatMsg(int id)
        {
            var not = await _context.ChatMsg.FindAsync(id);
            if (not == null)
            {
                return NotFound();
            }

            _context.ChatMsg.Remove(not);
            await _context.SaveChangesAsync();

            return new JsonResult("Notification Deleted  Succesfully!");
        }

        private bool ChatMsgExists(int id)
        {
            return _context.ChatMsg.Any(e => e.MessageId == id);
        }
    }

}
