using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Query
{
    public class GetAllMusicaQuery : IRequest<GetAllMusicaQueryResponse>
    {

    }

    public class GetAllMusicaQueryResponse
    {
        public IList<MusicaOutputDto> Musicas { get; set; }

        public GetAllMusicaQueryResponse(IList<MusicaOutputDto> Musicas)
        {
            this.Musicas = Musicas;
        }
    }
}
