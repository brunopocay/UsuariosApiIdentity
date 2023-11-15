using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosApiIdentity.Model;

namespace UsuariosApiIdentity.Data
{
	public class UsuarioDbContext : IdentityDbContext<Usuario>
	{
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        {
            
        }
    }
}
