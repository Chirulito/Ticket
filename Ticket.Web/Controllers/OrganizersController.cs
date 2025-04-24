using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticket.Web.Models;

namespace Ticket.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrganizersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizer>>> GetOrganizers()
        {
            return await _context.Organizers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organizer>> GetOrganizer(int id)
        {
            var organizer = await _context.Organizers.FindAsync(id);

            if (organizer == null)
                return NotFound();

            return organizer;
        }

        [HttpPost]
        public async Task<ActionResult<Organizer>> PostOrganizer(Organizer organizer)
        {
            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrganizer), new { id = organizer.IdOrganizer }, organizer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizer(int id, Organizer organizer)
        {
            if (id != organizer.IdOrganizer)
                return BadRequest();

            _context.Entry(organizer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Organizers.Any(e => e.IdOrganizer == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            var organizer = await _context.Organizers.FindAsync(id);
            if (organizer == null)
                return NotFound();

            _context.Organizers.Remove(organizer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
