using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticket.Web.Models;

namespace Ticket.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.IdEvent == id);

            if (ev == null)
                return NotFound();

            return ev;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = ev.IdEvent }, ev);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event ev)
        {
            if (id != ev.IdEvent)
                return BadRequest();

            _context.Entry(ev).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Events.Any(e => e.IdEvent == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.IdEvent == id);
            if (ev == null)
                return NotFound();

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
