using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly TicketContext _context;

        public OrganizerController(TicketContext context)
        {
            _context = context;
        }

        // GET: api/Organizer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizer>>> GetOrganizers()
        {
            return await _context.Organizers.ToListAsync();
        }

        // GET: api/Organizer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organizer>> GetOrganizer(int id)
        {
            var organizer = await _context.Organizers.FindAsync(id);

            if (organizer == null)
            {
                return NotFound();
            }

            return organizer;
        }

        // PUT: api/Organizer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizer(int id, Organizer organizer)
        {
            if (id != organizer.IdOrganizer)
            {
                return BadRequest();
            }

            _context.Entry(organizer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizerExists(id))
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

        // POST: api/Organizer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Organizer>> PostOrganizer(Organizer organizer)
        {
            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizer", new { id = organizer.IdOrganizer }, organizer);
        }

        // DELETE: api/Organizer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            var organizer = await _context.Organizers.FindAsync(id);
            if (organizer == null)
            {
                return NotFound();
            }

            _context.Organizers.Remove(organizer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizerExists(int id)
        {
            return _context.Organizers.Any(e => e.IdOrganizer == id);
        }
    }
}
