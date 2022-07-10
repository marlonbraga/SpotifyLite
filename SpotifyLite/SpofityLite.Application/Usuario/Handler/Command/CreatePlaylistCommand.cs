using MediatR;
using SpofityLite.Application.Usuario.Dto;

namespace SpotifyLite.Application.Usuario.Handler.Command
{
    public class CreatePlaylistCommand : IRequest<CreatePlaylistCommandResponse>
    {
        public PlaylistInputDto Playlist { get; set; }

        public CreatePlaylistCommand(PlaylistInputDto Playlist)
        {
            Playlist = Playlist;
        }
    }

    public class CreatePlaylistCommandResponse
    {
        public PlaylistOutputDto Playlist { get; set; }

        public CreatePlaylistCommandResponse(PlaylistOutputDto Playlist)
        {
            Playlist = Playlist;
        }
    }
}
