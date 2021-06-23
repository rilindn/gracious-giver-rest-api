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
    public class ProductRequestResponseController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public ProductRequestResponseController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Response
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRequestResponse>>> GetProductRequestResponse()
        {
            return await _context.ProductRequestResponse.ToListAsync();
        }


        // GET: api/Request/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductRequestResponse>> GetProductRequestResponse(int id)
        {
            var prod = await _context.ProductRequestResponse.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

     //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<ProductRequestResponse>>> GetProductRequestResponseByAmount(int nr)
        {
            return await _context.ProductRequestResponse.Take(nr).ToListAsync();
        }

        // PUT: api/Shteti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductRequestResponse(int id, ProductRequestResponse prod)
        {
            if (id != prod.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(prod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductRequestResponseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Request Updated Succesfully!");
        }

        // POST: api/Request
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductRequestResponse>> PostProductRequestResponse(ProductRequestResponse prod)
        {
            _context.ProductRequestResponse.Add(prod);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetShteti", new { id = prod.ShtetiId }, prod);

            return new JsonResult("Request Posted Succesfully!");
        }

        // DELETE: api/Request/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductRequestResponse>> DeleteProductRequestResponse(int id)
        {
            var prod = await _context.ProductRequestResponse.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.ProductRequestResponse.Remove(prod);
            await _context.SaveChangesAsync();

            return new JsonResult("Request Deleted  Succesfully!");
        }

        private bool ProductRequestResponseExists(int id)
        {
            return _context.ProductRequestResponse.Any(e => e.RequestId == id);
        }
    }

}
