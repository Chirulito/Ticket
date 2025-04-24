using System.ComponentModel.DataAnnotations;

namespace Ticket.Web.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Province { get; set; } = string.Empty;
    }
}
