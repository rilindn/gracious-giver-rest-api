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
    public class ProductController : ControllerBase
    {
        private readonly GraciousDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(GraciousDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }
        
        [HttpGet("donator/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByDonatorId(int id)
        {
            return await _context.Product.Where(p=>p.DonatorId==id).ToListAsync();
        }


        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var prod = await _context.Product.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }
        
        [HttpGet("last")]
        public async Task<ActionResult<Product>> GetLastProduct()
        {
            var prod = await _context.Product.OrderByDescending(p => p.ProductId).FirstOrDefaultAsync();

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        [HttpGet("amount/{nr}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByAmount(int nr)
        {
            return await _context.Product.Take(nr).ToListAsync();
        }
        
        [HttpGet("amount/{nr}/donator/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByAmountDonator(int nr,int id)
        {
            return await _context.Product.Where(p=>p.DonatorId==id).Take(nr).ToListAsync();
        }

        // PUT: api/product/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplikimi(int id, Product prod)
        {
            if (id != prod.ProductId)
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
                if (!ProductExists(id))
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

        // POST: api/product
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product prod)
        {
            _context.Product.Add(prod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = prod.ProductId }, prod);
        }

        // DELETE: api/product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var prod = await _context.Product.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.Product.Remove(prod);
            await _context.SaveChangesAsync();

            return prod;
        }


        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
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
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

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