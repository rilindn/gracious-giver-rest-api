using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GraciousGiver_BackEnd.Data;
using GraciousGiver_BackEnd.Models;

namespace GraciousGiver_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DM_UserController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public DM_UserController(GraciousDbContext context)
        {
            _context = context;
        }

               [HttpGet]
        public async Task<ActionResult<IEnumerable<DM_User>>> GetDM_User()
        {
            return await _context.DM_User.ToListAsync();
        }

  
        [HttpGet("{id}")]
        public async Task<ActionResult<DM_User>> GetDM_User(int id)
        {
            var prod = await _context.DM_User.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDM_User(int id, DM_User prod)
        {
            if (id != prod.UserId)
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
                if (!DM_UserExists(id))
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

        [HttpPost]
        public async Task<ActionResult<DM_User>> PostDM_User(DM_User prod)
        {
            _context.DM_User.Add(prod);
            await _context.SaveChangesAsync();

      

            return new JsonResult("User Posted Succesfully!");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<DM_User>> DeleteDM_User(int id)
        {
            var prod = await _context.DM_User.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.DM_User.Remove(prod);
            await _context.SaveChangesAsync();

            return new JsonResult("User Deleted  Succesfully!");
        }

        private bool DM_UserExists(int id)
        {
            return _context.DM_User.Any(e => e.UserId == id);
        }
    }
}