using GraciousGiver_BackEnd.Data;
using GraciousGiver_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferProductController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public OfferProductController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/OfferProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferProduct>>> GetOfferProduct()
        {
            return await _context.OfferProduct.ToListAsync();
        }



        // GET: api/OfferProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferProduct>> GetOfferProduct(int id)
        {
            var prod = await _context.OfferProduct.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

     
        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<OfferProduct>>> GetOfferProductByAmount(int nr)
        {
            return await _context.OfferProduct.Take(nr).ToListAsync();
        }

        // PUT: api/OfferProduct/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferProduct(int id, OfferProduct prod)
        {
            if (id != prod.OfferProductId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Entry(prod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("OfferProduct Updated Succesfully!");
        }
            return new JsonResult("Invalid offer product data!");
        }
        // POST: api/Request
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OfferProduct>> PostOfferProduct(OfferProduct prod)
        {
            if (ModelState.IsValid)
            {
                _context.OfferProduct.Add(prod);
            await _context.SaveChangesAsync();

                // return CreatedAtAction("GetShteti", new { id = prod.ShtetiId }, prod);

            }
            return new JsonResult("Invalid offer product data!");
        }

        // DELETE: api/Request/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferProduct>> DeleteOfferProduct(int id)
        {
            var prod = await _context.OfferProduct.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.OfferProduct.Remove(prod);
            await _context.SaveChangesAsync();

            return new JsonResult("OfferProduct Deleted  Succesfully!");
        }

        private bool OfferProductExists(int id)
        {
            return _context.OfferProduct.Any(e => e.OfferProductId == id);
        }
    }
}
