using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Abstractions;
using Usuarios.Data.Context;
using Usuarios.Data.Models;
using Usuarios.Domain.DTO;

namespace Usuarios.Services;

public class UsuariosService(IDbContextFactory<UsuariosContext> DbFactory) : IUsuariosService
{
	public async Task<UsuariosDto> Buscar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		var usuario = await contexto.Usuarios
			.Where(e => e.UsuarioId == id).Select(p => new UsuariosDto()
			{
				UsuarioId = p.UsuarioId,
				Nombre = p.Nombre,
				Balance = p.Balance
			}).FirstOrDefaultAsync();
		return usuario ?? new UsuariosDto();
	}

	public async Task<bool> Eliminar(int usuarioId)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Usuarios
			.Where(e => e.UsuarioId == usuarioId)
			.ExecuteDeleteAsync() > 0;
	}

	public async Task<bool> ExisteUsusario(int id, string nombre)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Usuarios
			.AnyAsync(e => e.UsuarioId != id
			&& e.Nombre.ToLower().Equals(nombre.ToLower()));
	}

	private async Task<bool> Insertar(UsuariosDto usuarioDto)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		var usuario = new Usuario()
		{
			Nombre = usuarioDto.Nombre,
			Balance = usuarioDto.Balance
		};
		contexto.Usuarios.Add(usuario);
		var guardo = await contexto.SaveChangesAsync() > 0;
		usuarioDto.UsuarioId = usuario.UsuarioId;
		return guardo;
	}

	private async Task<bool> Modificar(UsuariosDto usuarioDto)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		var usuario = new Usuario()
		{
			UsuarioId = usuarioDto.UsuarioId,
			Nombre = usuarioDto.Nombre,
			Balance = usuarioDto.Balance
		};
		contexto.Update(usuario);
		var modificado = await contexto.SaveChangesAsync() > 0;
		return modificado;
	}

	private async Task<bool> Existe(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Usuarios
			.AnyAsync(e => e.UsuarioId == id);
	}


	public async Task<bool> Guardar(UsuariosDto usuario)
	{
		if (!await Existe(usuario.UsuarioId))
			return await Insertar(usuario);
		else
			return await Modificar(usuario);
	}

	public async Task<List<UsuariosDto>> Listar(Expression<Func<UsuariosDto, bool>> criterio)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Usuarios.Select(p => new UsuariosDto()
		{
			UsuarioId = p.UsuarioId,
			Nombre = p.Nombre,
			Balance = p.Balance,
		})
		.Where(criterio)
		.ToListAsync();
	}
}
