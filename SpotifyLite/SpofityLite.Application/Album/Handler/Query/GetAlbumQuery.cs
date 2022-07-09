using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Query
{
    public class GetAlbumQuery : IRequest<GetAlbumQueryResponse>
    {
        public Guid IdAlbum { get; set; }

        public GetAlbumQuery(Guid idAlbum)
        {
            IdAlbum = idAlbum;
        }
    }

    public class GetAlbumQueryResponse
    {
        public AlbumOutputDto Album { get; set; }

        public GetAlbumQueryResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
