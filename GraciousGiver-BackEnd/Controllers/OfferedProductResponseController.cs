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
    public class OfferedProductResponseController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public OfferedProductResponseController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/OfferedProductResponse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferedProductResponse>>> GetOfferedProductResponse()
        {
            return await _context.OfferedProductResponse.ToListAsync();
        }


        // GET: api/OfferedProductResponse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferedProductResponse>> GetOfferedProductResponse(int id)
        {
            var prod = await _context.OfferedProductResponse.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }


        [HttpGet("receiver/{receiverId}")]
        public async Task<ActionResult<IEnumerable<OfferedProductResponse>>> GetOfferedProductResponseByRequesterId(int receiverId)
        {
            var resp = await _context.OfferedProductResponse.Where(r => r.ReceiverId == receiverId).ToListAsync();

            if (resp == null)
            {
                return NotFound();
            }

            return resp;
        }

        [HttpGet("amount/{nr}/receiver/{receiverId}")]
        public async Task<ActionResult<IEnumerable<OfferedProductResponse>>> GetOfferedProductResponseByReceiverIdAmount(int nr, int receiverId)
        {
            var resp = await _context.OfferedProductResponse.Where(r => r.ReceiverId == receiverId).Take(nr).ToListAsync();

            if (resp == null)
            {
                return NotFound();
            }

            return resp;
        }

        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<OfferedProductResponse>>> GetOfferedProductResponseByAmount(int nr)
        {
            return await _context.OfferedProductResponse.Take(nr).ToListAsync();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferedProductResponse(int id, OfferedProductResponse ofr)
        {
            if (id != ofr.OfferedProductResponseId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Entry(ofr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferedProductResponseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Response Updated Succesfully!");
        }
            return new JsonResult("Invalid response data!");
       }

        // POST: api/OfferedProductResponse
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OfferedProductResponse>> PostOfferedProductResponse(OfferedProductResponse ofr)
        {
            if (ModelState.IsValid)
            {
                _context.OfferedProductResponse.Add(ofr);
            await _context.SaveChangesAsync();

            }
            return new JsonResult("Invalid response data!");
        }

        // DELETE: api/Response/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferedProductResponse>> DeleteOfferedProductResponse(int id)
        {
            var ofr = await _context.OfferedProductResponse.FindAsync(id);
            if (ofr == null)
            {
                return NotFound();
            }

            _context.OfferedProductResponse.Remove(ofr);
            await _context.SaveChangesAsync();

            return new JsonResult("Response Deleted  Succesfully!");
        }

        private bool OfferedProductResponseExists(int id)
        {
            return _context.OfferedProductResponse.Any(e => e.OfferedProductResponseId == id);
        }
    }

}
