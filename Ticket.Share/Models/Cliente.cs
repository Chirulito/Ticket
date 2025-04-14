using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticket.Share.Models
{
	public class Cliente
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
		[Column(TypeName = "varchar(100)")]
		public string Nombre { get; set; }
		[Required]
		[MaxLength(8)]
		[Column(TypeName = "varchar(8)")]
		public string Telefono { get; set; }
		[EmailAddress]
		[MaxLength(100)]
		[Column(TypeName = "varchar(100)")]
		public string Correo { get; set; }

	}
}
