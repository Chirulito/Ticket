using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ticket.Share.Models
{
	public class Medicamento
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
		[Column(TypeName = "varchar(100)")]
		public string Nombre { get; set; }
		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Precio { get; set; }
		public int Stock { get; set; }
	}
}
