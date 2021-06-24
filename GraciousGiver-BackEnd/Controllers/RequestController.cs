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
    public class RequestController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public RequestController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
        {
            return await _context.Request.ToListAsync();
        }

        // GET: api/Request/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var re = await _context.Request.FindAsync(id);

            if (re == null)
            {
                return NotFound();
            }

            return re;
        }

        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequestByAmount(int nr)
        {
            return await _context.Request.Take(nr).ToListAsync();
        }

        // PUT: api/Request/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Request>> PutRequest(int id, Request re)
        {
            if (id != re.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(re).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return re;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Request
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request re)
        {
            try
            {
                _context.Request.Add(re);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetRequest", new { id = re.RequestId }, re);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // DELETE: api/Request/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(int id)
        {
            var re = await _context.Request.FindAsync(id);
            if (re == null)
            {
                return NotFound();
            }

            _context.Request.Remove(re);
            await _context.SaveChangesAsync();

            return re;
        }

        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.RequestId == id);
        }
    }
}