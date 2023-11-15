using AutoMapper;
using UsuariosApiIdentity.DTOs;
using UsuariosApiIdentity.Model;

namespace UsuariosApiIdentity.Profiles
{
	public class UsuarioProfile : Profile
	{
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDTO, Usuario>();
        }
    }
}
