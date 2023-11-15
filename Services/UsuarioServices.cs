using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApiIdentity.DTOs;
using UsuariosApiIdentity.Model;

namespace UsuariosApiIdentity.Services
{
	public class UsuarioServices
	{
		private readonly UserManager<Usuario> _userManager;
		private readonly IMapper _mapper;
		private readonly SignInManager<Usuario> _signInManager;
		private readonly TokenService _tokenService;

		public UsuarioServices(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService)
		{
			_mapper = mapper;
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenService = tokenService;
		}

		public async Task Cadastrar(CreateUsuarioDTO dto)
		{
			Usuario usuario = _mapper.Map<Usuario>(dto);
			IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

			if (!result.Succeeded)
				throw new ApplicationException("Falha ao cadastrar");
						
		}

		public async Task<string> LoginAsync(LoginUsuarioDTO dto)
		{
			var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

			if (!resultado.Succeeded)
			{
				throw new ApplicationException("Usuário não autenticado.");
			}

			var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

			var token = _tokenService.GenerateToken(usuario);

			return token;
		}
	}
}
