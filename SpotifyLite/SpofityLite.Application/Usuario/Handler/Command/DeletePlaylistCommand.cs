using MediatR;

namespace SpotifyLite.Application.Usuario.Handler.Command
{
    public class DeletePlaylistCommand : IRequest<DeletePlaylistCommandResponse>
    {
        public Guid IdPlaylist { get; set; }

        public DeletePlaylistCommand(Guid idPlaylist)
        {
            IdPlaylist = idPlaylist;
        }
    }

    public class DeletePlaylistCommandResponse
    {

    }
}
