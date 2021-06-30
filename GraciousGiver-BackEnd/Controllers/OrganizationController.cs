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
    public class OrganizationController : ControllerBase
    {
        private readonly GraciousDbContext _context;
        private readonly IUserRepository _repository;
        public OrganizationController(IUserRepository repository,GraciousDbContext context)
        {
            _context = context;
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganization()
        {
            return await _context.Organization.ToListAsync();

        }

        // GET: api/Organization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(int id)
        {
            var prod = await _context.Organization.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }

            return prod;
        }

        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<Organization>>> GetStateByAmount(int nr)
        {
            return await _context.Organization.Take(nr).ToListAsync();
        }

        // PUT: api/Shteti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization(int id, Organization prod)
        {
            if (id != prod.OrganizationId)
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
                if (!OrganizationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Organization Updated Succesfully!");
        }
            return new JsonResult("Invalid organization data!");
       }
        // POST: api/Organization
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Organization>> PostOrganization(Organization orgg)
        {
            if (ModelState.IsValid)
            {

                var org = new Organization
                {
                    Username = orgg.Username,
                    Password = BCrypt.Net.BCrypt.HashPassword(orgg.Password),
                    Name = orgg.Name,
                    Email = orgg.Email,
                    Category = orgg.Category,
                    Description = orgg.Description,
                    Location = orgg.Location,
                };
                return Created("success", _repository.CreateOrg(org));
            }

            return new JsonResult("Invalid data!");
        }
        // DELETE: api/Organization/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organization>> DeleteOrganization(int id)
        {
            var prod = await _context.Organization.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.Organization.Remove(prod);
            await _context.SaveChangesAsync();

            return new JsonResult("Organization Deleted  Succesfully!");
        }

        private bool OrganizationExists(int id)
        {
            return _context.Organization.Any(e => e.OrganizationId == id);
        }
    }
}



