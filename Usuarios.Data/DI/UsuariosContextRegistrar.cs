using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Data.Context;

namespace Usuarios.Data.DI;

public static class UsuariosContextRegistrar
{
	public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
	{
		services.AddDbContextFactory<UsuariosContext>(o => o.UseSqlServer("Name=SqlConStr"));
		return services;
	}
}
