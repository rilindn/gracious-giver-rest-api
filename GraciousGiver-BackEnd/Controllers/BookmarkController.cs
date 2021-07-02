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
        public async Task<ActionResult<Bookmark>> PostBookmark(Bookmark prod)
        {
            if (ModelState.IsValid)
            {
                _context.Bookmark.Add(prod);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBookmark", new { id = prod.BookmarkId }, prod);
            }
            return new JsonResult("Invalid Bookmark data!");
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



