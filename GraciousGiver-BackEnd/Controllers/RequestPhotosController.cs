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
    public class RequestPhotosController : ControllerBase

    {
        private readonly GraciousDbContext _context;

        public RequestPhotosController(GraciousDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestPhotos>>> GetRequestPhotos()
        {
            return await _context.RequestPhotos.ToListAsync();
        }
        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RequestPhotos>>> GetRequestPhotos(int id)
        {
            var prod = await _context.RequestPhotos.Where(p => p.Request == id).ToListAsync();

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }
        [HttpPost]
        public async Task<ActionResult<RequestPhotos>> PostRequestPhotos(RequestPhotos prod)
        {
            if (ModelState.IsValid)
            {
                _context.RequestPhotos.Add(prod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestPhotos", new { id = prod.PhotoId }, prod);
        }
            return new JsonResult("Invalid request photo data!");
       }

        // DELETE: api/RequestPhotos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestPhotos>> DeleteRequestPhoto(int id)
        {
            var prodPhoto = await _context.RequestPhotos.FindAsync(id);
            if (prodPhoto == null)
            {
                return NotFound();
            }

            _context.RequestPhotos.Remove(prodPhoto);
            await _context.SaveChangesAsync();

            return prodPhoto;
        }

    }
}
