using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("users")]

[Index("Identification", Name = "UQ__users__AAA7C1F53EEE0032", IsUnique = true)]
[Index("Email", Name = "UQ__users__AB6E616449661ED7", IsUnique = true)]
[Index("Username", Name = "UQ__users__F3DBC5726F5E0BE5", IsUnique = true)]

public class User
{
    [Key]
    [Column("id_user")]
    public int IdUser { get; set; }


    [Column("identification")]
    [StringLength(9)]
    public required string Identification { get; set; }


    [Column("first_name")]
    [StringLength(50)]
    public required string FirstName { get; set; }


    [Column("last_name_1")]
    [StringLength(50)]
    public required string LastName1 { get; set; }


    [Column("last_name_2")]
    [StringLength(50)]
    public string? LastName2 { get; set; }


    [Column("phone")]
    [MaxLength(8)]
    public string? Phone { get; set; }


    [Column("birth_date")]
    public DateTime? BirthDate { get; set; }


    [Column("email")]
    [MaxLength(100)]
    public required string Email { get; set; }


    [Column("username")]
    [MaxLength(50)]
    public required string Username { get; set; }


    [Column("password")]
    [MaxLength(255)]
    public required byte[] Password { get; set; }
}
