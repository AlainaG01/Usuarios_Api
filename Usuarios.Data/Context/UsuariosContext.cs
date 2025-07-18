using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Data.Models;

namespace Usuarios.Data.Context;

public class UsuariosContext : DbContext
{
	public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) { }
	public DbSet<Usuario> Usuarios { get; set; }
	public DbSet<Vehiculo> Vehiculo { get; set; }
}
