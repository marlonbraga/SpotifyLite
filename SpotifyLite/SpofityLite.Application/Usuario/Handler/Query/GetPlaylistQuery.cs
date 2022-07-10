using MediatR;
using SpofityLite.Application.Usuario.Dto;

namespace SpotifyLite.Application.Usuario.Handler.Query
{
    public class GetPlaylistQuery : IRequest<GetPlaylistQueryResponse>
    {
        public Guid IdPlaylist { get; set; }

        public GetPlaylistQuery(Guid idPlaylist)
        {
            IdPlaylist = idPlaylist;
        }
    }

    public class GetPlaylistQueryResponse
    {
        public PlaylistOutputDto Playlist { get; set; }

        public GetPlaylistQueryResponse(PlaylistOutputDto Playlist)
        {
            Playlist = Playlist;
        }
    }
}
