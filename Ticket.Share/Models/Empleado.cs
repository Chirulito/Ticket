using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ticket.Share.Models
{
	public class Empleado
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
		[Column(TypeName = "varchar(100)")]
		public string Nombre { get; set; }
		[Required]
		[MaxLength(50)]
		[Column(TypeName = "varchar(50)")]
		public string Puesto { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Salario { get; set; }
	}
}
