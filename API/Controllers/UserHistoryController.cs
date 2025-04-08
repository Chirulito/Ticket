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
    public class UserHistoryController : ControllerBase
    {
        private readonly TicketContext _context;

        public UserHistoryController(TicketContext context)
        {
            _context = context;
        }

        // GET: api/UserHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserHistory>>> GetUserHistory()
        {
            return await _context.UserHistory.ToListAsync();
        }

        // GET: api/UserHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserHistory>> GetUserHistory(int id)
        {
            var userHistory = await _context.UserHistory.FindAsync(id);

            if (userHistory == null)
            {
                return NotFound();
            }

            return userHistory;
        }

        // PUT: api/UserHistory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserHistory(int id, UserHistory userHistory)
        {
            if (id != userHistory.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(userHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserHistoryExists(id))
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

        // POST: api/UserHistory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserHistory>> PostUserHistory(UserHistory userHistory)
        {
            _context.UserHistory.Add(userHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserHistoryExists(userHistory.IdUser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserHistory", new { id = userHistory.IdUser }, userHistory);
        }

        // DELETE: api/UserHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserHistory(int id)
        {
            var userHistory = await _context.UserHistory.FindAsync(id);
            if (userHistory == null)
            {
                return NotFound();
            }

            _context.UserHistory.Remove(userHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserHistoryExists(int id)
        {
            return _context.UserHistory.Any(e => e.IdUser == id);
        }
    }
}
