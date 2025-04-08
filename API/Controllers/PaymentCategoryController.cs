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
    public class PaymentCategoryController : ControllerBase
    {
        private readonly TicketContext _context;

        public PaymentCategoryController(TicketContext context)
        {
            _context = context;
        }

        // GET: api/PaymentCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentCategory>>> GetPaymentCategories()
        {
            return await _context.PaymentCategories.ToListAsync();
        }

        // GET: api/PaymentCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentCategory>> GetPaymentCategory(int id)
        {
            var paymentCategory = await _context.PaymentCategories.FindAsync(id);

            if (paymentCategory == null)
            {
                return NotFound();
            }

            return paymentCategory;
        }

        // PUT: api/PaymentCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentCategory(int id, PaymentCategory paymentCategory)
        {
            if (id != paymentCategory.IdPaymentCategory)
            {
                return BadRequest();
            }

            _context.Entry(paymentCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentCategoryExists(id))
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

        // POST: api/PaymentCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentCategory>> PostPaymentCategory(PaymentCategory paymentCategory)
        {
            _context.PaymentCategories.Add(paymentCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentCategory", new { id = paymentCategory.IdPaymentCategory }, paymentCategory);
        }

        // DELETE: api/PaymentCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentCategory(int id)
        {
            var paymentCategory = await _context.PaymentCategories.FindAsync(id);
            if (paymentCategory == null)
            {
                return NotFound();
            }

            _context.PaymentCategories.Remove(paymentCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentCategoryExists(int id)
        {
            return _context.PaymentCategories.Any(e => e.IdPaymentCategory == id);
        }
    }
}
