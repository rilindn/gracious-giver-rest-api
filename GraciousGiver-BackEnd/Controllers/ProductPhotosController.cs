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
    public class ProductPhotosController : ControllerBase

    {
        private readonly GraciousDbContext _context;

        public ProductPhotosController(GraciousDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPhotos>>> GetProductPhotos()
        {
            return await _context.ProductPhotos.ToListAsync();
        }
        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductPhotos>>> GetProductPhotos(int id)
        {
            var prod = await _context.ProductPhotos.Where(p => p.Product == id).ToListAsync();

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }
        [HttpPost]
        public async Task<ActionResult<ProductPhotos>> PostProductPhotos(ProductPhotos prod)
        {
            if (ModelState.IsValid)
            {
                _context.ProductPhotos.Add(prod);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProductPhotos", new { id = prod.PhotoId }, prod);
            }
            return new JsonResult("Invalid product photo data!");
    }
        // DELETE: api/productPhotos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductPhotos>> DeleteProductPhoto(int id)
        {
            var prodPhoto = await _context.ProductPhotos.FindAsync(id);
            if (prodPhoto == null)
            {
                return NotFound();
            }

            _context.ProductPhotos.Remove(prodPhoto);
            await _context.SaveChangesAsync();

            return prodPhoto;
        }

    }
}
