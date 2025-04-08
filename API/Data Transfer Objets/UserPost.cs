using System.ComponentModel.DataAnnotations;

namespace API.Resources
{
    public class UserPost
    {
        [Required]
        [StringLength(9)]
        public string Identification { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName1 { get; set; }

        [StringLength(50)]
        public string LastName2 { get; set; } = null!;

        [MaxLength(8)]
        public string? Phone { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; } 
    }
}
