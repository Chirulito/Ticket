using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("roles")]

public class Role
{
    [Key]
    [Column("id_role")]
    public int IdRole { get; set; }


    [Column("role_name")]
    [StringLength(100)]
    public required string RoleName { get; set; }
}
