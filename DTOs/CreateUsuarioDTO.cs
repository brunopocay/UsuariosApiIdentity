using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuariosApiIdentity.DTOs
{
	public class CreateUsuarioDTO
	{
		[Required]
        public string Username { get; set; }
		[Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmarSenha { get; set; }
    }
}
