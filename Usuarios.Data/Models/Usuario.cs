using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Data.Models;

public class Usuario
{
	[Key]
	public int UsuariaId { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras")]
	public string? Nombre { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se permiten numeros enteros o decimales")]
	public double Balance { get; set; }
}
