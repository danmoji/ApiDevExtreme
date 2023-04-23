using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDevExtreme.Data;
using ApiDevExtreme.Models;

namespace ApiDevExtreme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualitiesController : ControllerBase
    {
        private readonly DashboardContext _context;

        public QualitiesController(DashboardContext context)
        {
            _context = context;
        }

        // GET: api/Qualities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quality>>> GetQualities()
        {
          if (_context.Qualities == null)
          {
              return NotFound();
          }
            return await _context.Qualities.ToListAsync();
        }

        // GET: api/Qualities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quality>> GetQuality(int id)
        {
          if (_context.Qualities == null)
          {
              return NotFound();
          }
            var quality = await _context.Qualities.FindAsync(id);

            if (quality == null)
            {
                return NotFound();
            }

            return quality;
        }

        // PUT: api/Qualities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuality(int id, Quality quality)
        {
            if (id != quality.Id)
            {
                return BadRequest();
            }

            _context.Entry(quality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualityExists(id))
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

        // POST: api/Qualities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quality>> PostQuality(Quality quality)
        {
          if (_context.Qualities == null)
          {
              return Problem("Entity set 'DashboardContext.Qualities'  is null.");
          }
            _context.Qualities.Add(quality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuality", new { id = quality.Id }, quality);
        }

        // DELETE: api/Qualities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuality(int id)
        {
            if (_context.Qualities == null)
            {
                return NotFound();
            }
            var quality = await _context.Qualities.FindAsync(id);
            if (quality == null)
            {
                return NotFound();
            }

            _context.Qualities.Remove(quality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QualityExists(int id)
        {
            return (_context.Qualities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
