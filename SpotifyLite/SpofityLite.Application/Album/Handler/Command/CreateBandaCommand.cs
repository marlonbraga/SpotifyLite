using MediatR;
using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class CreateBandaCommand : IRequest<CreateBandaCommandResponse>
    {
        public BandaInputDto Banda { get; set; }

        public CreateBandaCommand(BandaInputDto album)
        {
            this.Banda = album;
        }
    }

    public class CreateBandaCommandResponse
    {
        public BandaOutputDto Banda { get; set; }

        public CreateBandaCommandResponse(BandaOutputDto album)
        {
            Banda = album;
        }
    }
}
