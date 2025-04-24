using System.ComponentModel.DataAnnotations;

namespace Ticket.Web.Models
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; } // o simplemente Id

        public int IdEventCategory { get; set; }
        public int IdOrganizer { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public decimal Price { get; set; }
    }
}
