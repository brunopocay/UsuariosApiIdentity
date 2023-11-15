using Microsoft.AspNetCore.Identity;

namespace UsuariosApiIdentity.Model
{
	public class Usuario : IdentityUser
	{
        public DateTime DataNascimento { get; set; }
        public Usuario() : base() { }
    }
}
