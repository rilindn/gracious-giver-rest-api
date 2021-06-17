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
    public class ProductCategoryController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public ProductCategoryController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategory()
        {
            return await _context.ProductCategory.ToListAsync();
        }

        // GET: api/ProductCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {
            var prod = await _context.ProductCategory.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategByAmount(int nr)
        {
            return await _context.ProductCategory.Take(nr).ToListAsync();
        }

        // PUT: api/ProductCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductCategory>> PutProduct(int id, ProductCategory prod)
        {
            if (id != prod.ProductCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(prod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return prod;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(id))
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

        // POST: api/ProductCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory prod)
        {
            try
            {
                _context.ProductCategory.Add(prod);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProductCategory", new { id = prod.ProductCategoryId }, prod);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        // DELETE: api/ProductCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductCategory>> DeleteProductCategory(int id)
        {
            var prod = await _context.ProductCategory.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.ProductCategory.Remove(prod);
            await _context.SaveChangesAsync();

            return prod;
        }

        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategory.Any(e => e.ProductCategoryId == id);
        }
    }
}