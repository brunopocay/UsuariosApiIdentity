﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApiIdentity.Model;

namespace UsuariosApiIdentity.Services
{
	public class TokenService
	{
		private readonly IConfiguration _configuration;

		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GenerateToken(Usuario usuario)
		{
			Claim[] claims = new Claim[]
			{
				new Claim("username", usuario.UserName),
				new Claim("Id", usuario.Id),
				new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));
			var signingCredentials = new SigningCredentials(
					key,
					SecurityAlgorithms.HmacSha256
				);

			var token = new JwtSecurityToken(
					expires: DateTime.Now.AddMinutes(60),
					claims: claims,
					signingCredentials: signingCredentials
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}