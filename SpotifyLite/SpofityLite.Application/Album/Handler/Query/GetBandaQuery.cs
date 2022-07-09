using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Query
{
    public class GetBandaQuery : IRequest<GetBandaQueryResponse>
    {
        public Guid IdBanda { get; set; }

        public GetBandaQuery(Guid idBanda)
        {
            IdBanda = idBanda;
        }
    }

    public class GetBandaQueryResponse
    {
        public BandaOutputDto Banda { get; set; }

        public GetBandaQueryResponse(BandaOutputDto album)
        {
            Banda = album;
        }
    }
}
