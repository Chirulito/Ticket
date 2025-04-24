using System.ComponentModel.DataAnnotations;

namespace Ticket.Web.Models
{
    public class Invoice
    {
        [Key]
        public int IdInvoice { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Seat { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
