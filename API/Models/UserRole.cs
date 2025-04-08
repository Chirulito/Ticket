using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    [PrimaryKey("IdRole", "IdUser")]

    [Table("user_roles")]

    public class UserRole
    {
        [Key]
        [Column("id_role")]
        public int IdRole { get; set; }


        [Key]
        [Column("id_user")]
        public int IdUser { get; set; }
    }
}
