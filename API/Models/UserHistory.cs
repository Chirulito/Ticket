using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    [PrimaryKey("IdUser", "IdEvent")]

    [Table("user_history")]

    public class UserHistory
    {
        [Key]
        [Column("id_user")]
        public int IdUser { get; set; }


        [Key]
        [Column("id_event")]
        public int IdEvent { get; set; }
    }
}

