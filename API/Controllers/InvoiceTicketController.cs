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
    public class InvoiceTicketController : ControllerBase
    {
        private readonly TicketContext _context;

        public InvoiceTicketController(TicketContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceTicket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceTicket>>> GetInvoiceTickets()
        {
            return await _context.InvoiceTickets.ToListAsync();
        }

        // GET: api/InvoiceTicket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceTicket>> GetInvoiceTicket(int id)
        {
            var invoiceTicket = await _context.InvoiceTickets.FindAsync(id);

            if (invoiceTicket == null)
            {
                return NotFound();
            }

            return invoiceTicket;
        }

        // PUT: api/InvoiceTicket/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceTicket(int id, InvoiceTicket invoiceTicket)
        {
            if (id != invoiceTicket.IdInvoice)
            {
                return BadRequest();
            }

            _context.Entry(invoiceTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceTicketExists(id))
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

        // POST: api/InvoiceTicket
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceTicket>> PostInvoiceTicket(InvoiceTicket invoiceTicket)
        {
            _context.InvoiceTickets.Add(invoiceTicket);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InvoiceTicketExists(invoiceTicket.IdInvoice))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInvoiceTicket", new { id = invoiceTicket.IdInvoice }, invoiceTicket);
        }

        // DELETE: api/InvoiceTicket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceTicket(int id)
        {
            var invoiceTicket = await _context.InvoiceTickets.FindAsync(id);
            if (invoiceTicket == null)
            {
                return NotFound();
            }

            _context.InvoiceTickets.Remove(invoiceTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceTicketExists(int id)
        {
            return _context.InvoiceTickets.Any(e => e.IdInvoice == id);
        }
    }
}
