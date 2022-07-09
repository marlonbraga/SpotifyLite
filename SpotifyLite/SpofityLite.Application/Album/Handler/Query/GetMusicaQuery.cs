using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Query
{
    public class GetMusicaQuery : IRequest<GetMusicaQueryResponse>
    {
        public Guid IdMusica { get; set; }

        public GetMusicaQuery(Guid idMusica)
        {
            IdMusica = idMusica;
        }
    }

    public class GetMusicaQueryResponse
    {
        public MusicaOutputDto Musica { get; set; }

        public GetMusicaQueryResponse(MusicaOutputDto musica)
        {
            Musica = musica;
        }
    }
}
