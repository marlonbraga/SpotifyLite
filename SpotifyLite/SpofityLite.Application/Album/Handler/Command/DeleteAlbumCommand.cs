using MediatR;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class DeleteAlbumCommand : IRequest<DeleteAlbumCommandResponse>
    {
        public Guid IdAlbum { get; set; }

        public DeleteAlbumCommand(Guid idAlbum)
        {
            IdAlbum = idAlbum;
        }
    }

    public class DeleteAlbumCommandResponse
    {

    }
}
