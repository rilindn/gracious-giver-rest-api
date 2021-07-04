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
    public class RequestController : ControllerBase
    {
        private readonly GraciousDbContext _context;
        private readonly IWebHostEnvironment _env;

        public RequestController(GraciousDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
        {
            try
            {

                var prods = await _context.Request.ToListAsync();
                return prods;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        // GET: api/Request/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var re = await _context.Request.FindAsync(id);

            if (re == null)
            {
                return NotFound();
            }

            return re;
        }

        //amount
        [HttpGet("{amount}/{nr}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequestByAmount(int nr)
        {
            return await _context.Request.Take(nr).ToListAsync();
        }

        [HttpGet("last")]
        public async Task<ActionResult<Request>> GetLastRequest()
        {
            var req = await _context.Request.OrderByDescending(p => p.RequesttId).FirstOrDefaultAsync();

            if (req == null)
            {
                return NotFound();
            }

            return req;
        }

        // PUT: api/Request/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Request>> PutRequest(int id, Request re)
        {
            if (id != re.RequesttId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Entry(re).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    return re;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return new JsonResult("Request updated succesfully!");
            }
                return new JsonResult("Invalid request data!");
        }
            // POST: api/Request
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request re)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Request.Add(re);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetRequest", new { id = re.RequesttId }, re);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return new JsonResult("Invalid request data!");
        }

        // DELETE: api/Request/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(int id)
        {
            var re = await _context.Request.FindAsync(id);
            if (re == null)
            {
                return NotFound();
            }

            _context.Request.Remove(re);
            await _context.SaveChangesAsync();

            return re;
        }

        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.RequesttId == id);
        }

        [Route("SaveFile/Request")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/RequestPhotos/" + filename;

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