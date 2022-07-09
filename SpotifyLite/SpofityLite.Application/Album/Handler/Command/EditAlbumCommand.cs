using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class EditAlbumCommand : IRequest<EditAlbumCommandResponse>
    {
        public AlbumInputDto Album { get; set; }

        public Guid IdAlbum { get; set; }

        public EditAlbumCommand(Guid idAlbum, AlbumInputDto album)
        {
            IdAlbum = idAlbum;
            Album = album;
        }
    }

    public class EditAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public EditAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
