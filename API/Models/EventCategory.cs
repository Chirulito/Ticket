using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Models;

[Table("event_categories")]

public class EventCategory
{
    [Key]
    [Column("id_event_category")]
    public int IdEventCategory { get; set; }

    [Column("name")]
    [StringLength(100)]
    public required string Name { get; set; }
}
