using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Album;

namespace SpofityLite.Application.Album.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<Musica, MusicaOutputDto>()
                .ForMember(x => x.Duracao, f => f.MapFrom(m => m.Duracao.ValorFormatado()));

            CreateMap<MusicaInputDto, Musica>()
                .ForPath(x => x.Duracao.Valor, f => f.MapFrom(m => m.Duracao));

            CreateMap<SpotifyLite.Domain.Album.Album, AlbumOutputDto>();

            CreateMap<AlbumInputDto, SpotifyLite.Domain.Album.Album>();

            CreateMap<BandaInputDto, Banda>();

            CreateMap<Banda, BandaOutputDto>();
        }
    }
}
