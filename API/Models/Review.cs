using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Models;

[Table("reviews")]

public class Review
{
    [Key]
    [Column("id_review")]
    public int IdReview { get; set; }


    [Column("id_event")]
    public required int IdEvent { get; set; }


    [Column("id_user")]
    public required int IdUser { get; set; }


    [Column("rating")]
    public required int Rating { get; set; }


    [Column("comment", TypeName = "text")]
    public string? Comment { get; set; }


    [Column("date", TypeName = "datetime")]
    public required DateTime Date { get; set; }
}
