using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("tickets")]

[Index("Code", Name = "UQ__tickets__357D4CF9D8275298", IsUnique = true)]

public class Ticket
{
    [Key]
    [Column("id_ticket")]
    public int IdTicket { get; set; }


    [Column("id_event")]
    public required int IdEvent { get; set; }


    [Column("code")]
    [StringLength(255)]
    public required string Code { get; set; }


    [Column("status")]
    public required bool Status { get; set; }
}
