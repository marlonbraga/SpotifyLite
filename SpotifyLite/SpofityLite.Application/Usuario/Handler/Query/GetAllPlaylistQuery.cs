using MediatR;
using SpofityLite.Application.Usuario.Dto;

namespace SpotifyLite.Application.Usuario.Handler.Query
{
    public class GetAllPlaylistQuery : IRequest<GetAllPlaylistQueryResponse>
    {
    }

    public class GetAllPlaylistQueryResponse
    {
        public IList<PlaylistOutputDto> Playlists { get; set; }

        public GetAllPlaylistQueryResponse(IList<PlaylistOutputDto> Playlists)
        {
            Playlists = Playlists;
        }
    }
}
