using Microsoft.AspNetCore.Mvc;
using Usuarios.Abstractions;
using Usuarios.Data.Models;
using Usuarios.Domain.DTO;

namespace UsuariosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiculosController(IVehiculosService vehiculoService) : ControllerBase
{
	// GET: api/Vehiculo
	[HttpGet]
	public async Task<ActionResult<IEnumerable<VehiculosDto>>> GetVehiculos()
	{
		return await vehiculoService.Listar(p => true);
	}

	// GET: api/Vehiculo/5
	[HttpGet("{id}")]
	public async Task<ActionResult<VehiculosDto>> GetVehiculo(int id)
	{
		return await vehiculoService.Buscar(id);
	}

	// PUT: api/Vehiculo/5
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPut("{id}")]
	public async Task<IActionResult> PutVehiculo(int id, VehiculosDto vehiculoDto)
	{
		if (id != vehiculoDto.VehiculoId)
		{
			return BadRequest();
		}

		// Actualizar el Vehiculo
		await vehiculoService.Guardar(vehiculoDto);
		return NoContent();
	}

	// POST: api/Vehiculo
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPost]
	public async Task<ActionResult<Vehiculo>> PostVehiculo(VehiculosDto vehiculoDto)
	{
		await vehiculoService.Guardar(vehiculoDto);
		return CreatedAtAction("GetVehiculos", new { id = vehiculoDto.VehiculoId }, vehiculoDto);
	}

	// DELETE: api/Vehiculo/5
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteVehiculo(int id)
	{
		await vehiculoService.Eliminar(id);
		return NoContent();
	}
}
