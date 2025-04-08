using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Models;

[Table("invoices")]

public class Invoice
{
    [Key]
    [Column("id_invoice")]
    public int IdInvoice { get; set; }


    [Column("id_user")]
    public required int IdUser { get; set; }


    [Column("id_payment_category")]
    public required int IdPaymentCategory { get; set; }


    [Column("date", TypeName = "datetime")]
    public required DateTime Date { get; set; }


    [Column("discount", TypeName = "decimal(18, 2)")]
    public required decimal Discount { get; set; }


    [Column("tax", TypeName = "decimal(18, 2)")]
    public required decimal Tax { get; set; }


    [Column("subtotal", TypeName = "decimal(18, 2)")]
    public required decimal Subtotal { get; set; }


    [Column("total", TypeName = "decimal(20, 2)")]
    public required decimal Total { get; set; }
}
