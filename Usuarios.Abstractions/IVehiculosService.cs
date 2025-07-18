using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Domain.DTO;

namespace Usuarios.Abstractions;

public interface IVehiculosService
{
	Task<bool> Guardar(VehiculosDto vehiculo);
	Task<bool> Eliminar(int vehiculoId);
	Task<VehiculosDto> Buscar(int id);
	Task<List<VehiculosDto>> Listar(Expression<Func<VehiculosDto, bool>> criterio);
	Task<bool> ExisteCliente(int id, string descripcion);
}
