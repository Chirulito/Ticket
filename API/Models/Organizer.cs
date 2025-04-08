using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("organizers")]

[Index("Email", Name = "UQ__organize__AB6E6164EF087C6D", IsUnique = true)]

public class Organizer
{
    [Key]
    [Column("id_organizer")]
    public int IdOrganizer { get; set; }


    [Column("name")]
    [StringLength(100)]
    public required string Name { get; set; }


    [Column("email")]
    [StringLength(200)]
    public required string Email { get; set; }


    [Column("phone")]
    [StringLength(8)]
    public required string Phone { get; set; }
}
