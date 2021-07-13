﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GraciousGiver_BackEnd.Data;
using GraciousGiver_BackEnd.Models;

namespace GraciousGiver_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly GraciousDbContext _context;

        public DonationController(GraciousDbContext context)
        {
            _context = context;
        }

        // GET: api/Donation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donation>>> GetDonation()
        {
            return await _context.Donation.ToListAsync();
        }

        [HttpGet("amount/{nr}")]
        public async Task<ActionResult<IEnumerable<Donation>>> GetDonationsByAmount(int nr)
        {
            return await _context.Donation.Take(nr).ToListAsync();
        }

        [HttpGet("amount/{nr}/{InitiativeId}")]
        public async Task<ActionResult<IEnumerable<Donation>>> GetDonationsByAmountInitiativeIdt(int nr, int InitiativeId)
        {
            return await _context.Donation.Where(e => e.Initiative == InitiativeId).Take(nr).ToListAsync();
        }

        [HttpGet("initiative/{InitiativeId}")]
        public async Task<ActionResult<IEnumerable<Donation>>> GetAllEventParticipants(int InitiativeId)
        {
            return await _context.Donation.Where(e => e.Initiative == InitiativeId).ToListAsync();
        }

        // GET: api/Donation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donation>> GetDonation(int id)
        {
            var donation = await _context.Donation.FindAsync(id);

            if (donation == null)
            {
                return NotFound();
            }

            return donation;
        }

        // PUT: api/Donation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonation(int id, Donation donation)
        {
            if (id != donation.DonationId)
            {
                return BadRequest();
            }

            _context.Entry(donation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationExists(id))
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

        // POST: api/Donation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Donation>> PostDonation(Donation donation)
        {
            _context.Donation.Add(donation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonation", new { id = donation.DonationId }, donation);
        }

        // DELETE: api/Donation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            var donation = await _context.Donation.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }

            _context.Donation.Remove(donation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonationExists(int id)
        {
            return _context.Donation.Any(e => e.DonationId == id);
        }
    }
}
