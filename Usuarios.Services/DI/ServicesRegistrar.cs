using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Abstractions;
using Usuarios.Data.DI;

namespace Usuarios.Services.DI;

public static class ServicesRegistrar
{
	public static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services.RegisterDbContextFactory();
		services.AddScoped<IUsuariosService, UsuariosService>();
		return services;
	}
}
