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
    public class EventCategoryController : ControllerBase
    {
        private readonly TicketContext _context;

        public EventCategoryController(TicketContext context)
        {
            _context = context;
        }

        // GET: api/EventCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventCategory>>> GetEventCategories()
        {
            return await _context.EventCategories.ToListAsync();
        }

        // GET: api/EventCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventCategory>> GetEventCategory(int id)
        {
            var eventCategory = await _context.EventCategories.FindAsync(id);

            if (eventCategory == null)
            {
                return NotFound();
            }

            return eventCategory;
        }

        // PUT: api/EventCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventCategory(int id, EventCategory eventCategory)
        {
            if (id != eventCategory.IdEventCategory)
            {
                return BadRequest();
            }

            _context.Entry(eventCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventCategoryExists(id))
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

        // POST: api/EventCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventCategory>> PostEventCategory(EventCategory eventCategory)
        {
            _context.EventCategories.Add(eventCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventCategory", new { id = eventCategory.IdEventCategory }, eventCategory);
        }

        // DELETE: api/EventCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventCategory(int id)
        {
            var eventCategory = await _context.EventCategories.FindAsync(id);
            if (eventCategory == null)
            {
                return NotFound();
            }

            _context.EventCategories.Remove(eventCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventCategoryExists(int id)
        {
            return _context.EventCategories.Any(e => e.IdEventCategory == id);
        }
    }
}
