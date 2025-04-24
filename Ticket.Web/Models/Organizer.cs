using System.ComponentModel.DataAnnotations;

namespace Ticket.Web.Models
{
    public class Organizer
    {
        [Key]
        public int IdOrganizer { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
