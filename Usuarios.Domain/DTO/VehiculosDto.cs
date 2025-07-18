using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Domain.DTO;

public class VehiculosDto
{
	public int VehiculoId { get; set; }
	public string? Descripcion { get; set; }
	public double Precio { get; set; }
}
