using MediatR;
using SpofityLite.Application.Usuario.Dto;

namespace SpotifyLite.Application.Usuario.Handler.Command
{
    public class EditPlaylistCommand : IRequest<EditPlaylistCommandResponse>
    {
        public PlaylistInputDto Playlist { get; set; }

        public Guid IdPlaylist { get; set; }

        public EditPlaylistCommand(Guid idPlaylist, PlaylistInputDto Playlist)
        {
            IdPlaylist = idPlaylist;
            Playlist = Playlist;
        }
    }

    public class EditPlaylistCommandResponse
    {
        public PlaylistOutputDto Playlist { get; set; }

        public EditPlaylistCommandResponse(PlaylistOutputDto Playlist)
        {
            Playlist = Playlist;
        }
    }
}
