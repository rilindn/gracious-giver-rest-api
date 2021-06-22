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
    public class Product_RequestController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public Product_RequestController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Request>>> GetProduct_Request()
        {
            return await _context.Product_Request.ToListAsync();
        }

        

        // GET: api/Request/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Request>> GetProduct_Request(int id)
        {
            var prod = await _context.Product_Request.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }


        public async Task<ActionResult<bool>> VerifyProductDonator(int donatorId, int productId)
        {
            var product = await _context.Product.FindAsync(productId);
            return product.DonatorId == donatorId;
        }

        [HttpGet("request/{donatorId}")]
        public async Task<ActionResult<List<Product_Request>>> GetProductDonator(int donatorId)
        {
            var prodR = await _context.Product_Request.ToListAsync();
            List<Product_Request> requests = new List<Product_Request>();
            foreach (Product_Request p in prodR)
            {
                var b = VerifyProductDonator(donatorId, p.GetReqProductId());
                if (b.Result.Value==true)
                {
                    requests.Add(p);
                } 
            }
            return requests;
        }

        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<Product_Request>>> GetProduct_RequestByAmount(int nr)
        {
            return await _context.Product_Request.Take(nr).ToListAsync();
        }

        // PUT: api/Shteti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct_Request(int id, Product_Request prod)
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
                if (!Product_RequestExists(id))
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
        public async Task<ActionResult<Product_Request>> PostProduct_Request(Product_Request prod)
        {
            _context.Product_Request.Add(prod);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetShteti", new { id = prod.ShtetiId }, prod);

            return new JsonResult("Request Posted Succesfully!");
        }

        // DELETE: api/Request/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product_Request>> DeleteProduct_Request(int id)
        {
            var prod = await _context.Product_Request.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.Product_Request.Remove(prod);
            await _context.SaveChangesAsync();

            return new JsonResult("Request Deleted  Succesfully!");
        }

        private bool Product_RequestExists(int id)
        {
            return _context.Product_Request.Any(e => e.RequestId == id);
        }
    }
}

