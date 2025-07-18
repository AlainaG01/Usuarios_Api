using Microsoft.AspNetCore.Mvc;
using Usuarios.Abstractions;
using Usuarios.Data.Models;
using Usuarios.Domain.DTO;

namespace UsuariosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController(IUsuariosService usuariosService) : ControllerBase
{
	// GET: api/Usuarios
	[HttpGet]
	public async Task<ActionResult<IEnumerable<UsuariosDto>>> GetUsuarios()
	{
		return await usuariosService.Listar(p => true);
	}

	// GET: api/Usuarios/5
	[HttpGet("{id}")]
	public async Task<ActionResult<UsuariosDto>> GetUsuarios(int id)
	{
		return await usuariosService.Buscar(id);
	}

	// PUT: api/Usuarios/5
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPut("{id}")]
	public async Task<IActionResult> PutUsuarios(int id, UsuariosDto usuariosDto)
	{
		if (id != usuariosDto.UsuarioId)
		{
			return BadRequest();
		}

		await usuariosService.Guardar(usuariosDto);

		return NoContent();
	}

	// POST: api/Usuarios
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPost]
	public async Task<ActionResult<Usuario>> PostUsuarios(UsuariosDto usuariosDto)
	{
		await usuariosService.Guardar(usuariosDto);

		return CreatedAtAction("GetUsuarios", new { id = usuariosDto.UsuarioId }, usuariosDto);
	}

	// DELETE: api/Usuarios/5
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteUsuarios(int id)
	{
		await usuariosService.Eliminar(id);

		return NoContent();
	}
}
