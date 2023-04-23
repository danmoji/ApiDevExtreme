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
    public class FlowsController : ControllerBase
    {
        private readonly DashboardContext _context;

        public FlowsController(DashboardContext context)
        {
            _context = context;
        }

        // GET: api/Flows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flow>>> GetFlows()
        {
          if (_context.Flows == null)
          {
              return NotFound();
          }
            return await _context.Flows.ToListAsync();
        }

        // GET: api/Flows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flow>> GetFlow(int id)
        {
          if (_context.Flows == null)
          {
              return NotFound();
          }
            var flow = await _context.Flows.FindAsync(id);

            if (flow == null)
            {
                return NotFound();
            }

            return flow;
        }

        // PUT: api/Flows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlow(int id, Flow flow)
        {
            if (id != flow.Id)
            {
                return BadRequest();
            }

            _context.Entry(flow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlowExists(id))
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

        // POST: api/Flows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flow>> PostFlow(Flow flow)
        {
          if (_context.Flows == null)
          {
              return Problem("Entity set 'DashboardContext.Flows'  is null.");
          }
            _context.Flows.Add(flow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlow", new { id = flow.Id }, flow);
        }

        // DELETE: api/Flows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlow(int id)
        {
            if (_context.Flows == null)
            {
                return NotFound();
            }
            var flow = await _context.Flows.FindAsync(id);
            if (flow == null)
            {
                return NotFound();
            }

            _context.Flows.Remove(flow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlowExists(int id)
        {
            return (_context.Flows?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
