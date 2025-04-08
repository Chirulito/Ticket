using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("payment_categories")]

public class PaymentCategory
{
    [Key]
    [Column("id_payment_category")]
    public int IdPaymentCategory { get; set; }


    [Column("name")]
    [StringLength(100)]
    public required string Name { get; set; }
}
