using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using puppiesApiDotNet.Data;
using puppiesApiDotNet.Model;

namespace puppiesApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuppiesController : ControllerBase
    {
        private readonly puppiesApiDotNetContext _context;

        public PuppiesController(puppiesApiDotNetContext context)
        {
            _context = context;
        }

        // GET: api/Puppies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puppy>>> GetPuppy()
        {
            return await _context.Puppy.ToListAsync();
        }

        // GET: api/Puppies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puppy>> GetPuppy(Guid id)
        {
            var puppy = await _context.Puppy.FindAsync(id);

            if (puppy == null)
            {
                return NotFound();
            }

            return puppy;
        }

        // PUT: api/Puppies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuppy(Guid id, Puppy puppy)
        {
            if (id != puppy.Id)
            {
                return BadRequest();
            }

            _context.Entry(puppy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuppyExists(id))
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

        // POST: api/Puppies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Puppy>> PostPuppy(Puppy puppy)
        {
            _context.Puppy.Add(puppy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuppy", new { id = puppy.Id }, puppy);
        }

        // DELETE: api/Puppies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuppy(Guid id)
        {
            var puppy = await _context.Puppy.FindAsync(id);
            if (puppy == null)
            {
                return NotFound();
            }

            _context.Puppy.Remove(puppy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuppyExists(Guid id)
        {
            return _context.Puppy.Any(e => e.Id == id);
        }
    }
}
