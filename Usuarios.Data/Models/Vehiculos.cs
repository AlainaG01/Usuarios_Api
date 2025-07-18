using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Data.Models;

public class Vehiculo
{
	[Key]
	public int VehiculoId { get; set; }

	[Required(ErrorMessage = "Campo Obligatorio")]
	[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten letras")]

	public string? Descripcion { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se permiten numeros enteros o decimales")]
	public double Precio { get; set; }

}
