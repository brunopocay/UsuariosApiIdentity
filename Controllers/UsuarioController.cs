using Microsoft.AspNetCore.Mvc;
using UsuariosApiIdentity.DTOs;
using UsuariosApiIdentity.Services;

namespace UsuariosApiIdentity.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private UsuarioServices _usuarioServices;

		public UsuarioController(UsuarioServices usuarioServices)
		{
			_usuarioServices = usuarioServices;
		}

		[HttpPost("CadastrarUsuario")]
		public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDTO dto)
		{
			await _usuarioServices.Cadastrar(dto);
			return Ok("Usuario cadastrado!");
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginUsuarioDTO dto)
		{
			var token = await _usuarioServices.LoginAsync(dto);
			return Ok(token);
		}
	}
}
