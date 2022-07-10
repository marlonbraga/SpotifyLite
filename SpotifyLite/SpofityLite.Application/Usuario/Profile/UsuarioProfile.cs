using SpofityLite.Application.Usuario.Dto;

namespace SpofityLite.Application.Usuario.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<SpotifyLite.Domain.Account.Usuario, UsuarioOutputDto>()
                .ForPath(x => x.Email, f => f.MapFrom(m => m.Email.Valor))
                .ForPath(x => x.Password, f => f.MapFrom(m => m.Password.Valor));

            CreateMap<UsuarioInputDto, SpotifyLite.Domain.Account.Usuario>()
                .ForPath(x => x.Email.Valor, f => f.MapFrom(m => m.Email))
                .ForPath(x => x.Password.Valor, f => f.MapFrom(m => m.Password));
        }

    }
}