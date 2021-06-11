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
    public class UserController : ControllerBase
    {
        private readonly GraciousDbContext _context;
        public UserController(GraciousDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

  
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetDM_User(int id)
        {
            var prod = await _context.Users.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByAmount(int nr)
        {
            return await _context.Users.Take(nr).ToListAsync();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutDM_User(int id, User prod)
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
        public async Task<ActionResult<User>> PostDM_User(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            return new JsonResult("New User registered Succesfully!");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteDM_User(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return new JsonResult("User Deleted  Succesfully!");
        }

        private bool DM_UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}