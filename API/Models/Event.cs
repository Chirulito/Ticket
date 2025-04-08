using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("events")]
public class Event
{
    [Key]
    [Column("id_event")]
    public int IdEvent { get; set; }


    [Column("id_event_category")]
    public required int IdEventCategory { get; set; }


    [Column("id_organizer")]
    public  required int IdOrganizer { get; set; }


    [Column("description", TypeName = "text")]
    public string? Description { get; set; }


    [Column("date", TypeName = "datetime")]
    public required DateTime Date { get; set; }


    [Column("location")]
    [StringLength(255)]
    public required string Location { get; set; }


    [Column("capacity")]
    public required int Capacity { get; set; }


    [Column("price", TypeName = "decimal(10, 2)")]
    public required decimal Price { get; set; }
}
