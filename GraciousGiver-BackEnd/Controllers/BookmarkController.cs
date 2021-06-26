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
            public class BookmarkController : ControllerBase
            {
                private readonly GraciousDbContext _context;

                public BookmarkController(GraciousDbContext context)
                {
                    _context = context;
                }


        [HttpPost]
        public async Task<ActionResult<Bookmark>> Bookmark(Bookmark prod)
        {
            _context.Bookmark.Add(prod);
            await _context.SaveChangesAsync();

            return new JsonResult("Product has been bookmarked succesfully!");
        }

        [HttpGet("id/{UserId}")]
        public async Task<ActionResult<IEnumerable<Bookmark>>> GetBookmarkByUserId(int UserId)
        {
            return await _context.Bookmark.Where(u => u.UserId == UserId).ToListAsync();
        }
        
        [HttpGet("bookmarked/{UserId}/{productId}")]
        public async Task<ActionResult<Boolean>> GetBookmarkByUserId(int UserId,int productId)
        {
            var bookmark = await _context.Bookmark.Where(u => u.UserId == UserId && u.ProductId == productId).ToListAsync();

            if (bookmark.Capacity==0)
            {
                return false;
            }
            return true;
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutDM_Bookmark(int id, Bookmark prod)
        {
            if (id != prod.BookmarkId)
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
                if (!DM_BookmarkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("User Updated Succesfully!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bookmark>> DeleteDM_Bookmark(int id)
        {
            var bookmark = await _context.Bookmark.FindAsync(id);
            if (bookmark == null)
            {
                return NotFound();
            }

            _context.Bookmark.Remove(bookmark);
            await _context.SaveChangesAsync();

            return new JsonResult("Bookmark Deleted  Succesfully!");
        }

        private bool DM_BookmarkExists(int id)
        {
            return _context.Bookmark.Any(e => e.BookmarkId == id);
        }
    }    
}



