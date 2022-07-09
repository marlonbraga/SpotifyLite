using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Query
{
    public class GetAllBandaQuery : IRequest<GetAllBandaQueryResponse>
    {

    }

    public class GetAllBandaQueryResponse
    {
        public IList<BandaOutputDto> Bandas { get; set; }

        public GetAllBandaQueryResponse(IList<BandaOutputDto> albums)
        {
            this.Bandas = albums;
        }
    }
}
