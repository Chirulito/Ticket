using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[PrimaryKey("IdInvoice", "IdTicket")]

[Table("invoice_tickets")]

public class InvoiceTicket
{
    [Key]
    [Column("id_invoice")]
    public int IdInvoice { get; set; }


    [Key]
    [Column("id_ticket")]
    public int IdTicket { get; set; }


    [Column("quantity")]
    public required int Quantity { get; set; }
}
