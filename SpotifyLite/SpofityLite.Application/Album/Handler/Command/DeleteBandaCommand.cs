using MediatR;

namespace SpofityLite.Application.Album.Handler.Command
{
    public class DeleteBandaCommand : IRequest<DeleteBandaCommandResponse>
    {
        public Guid IdBanda { get; set; }

        public DeleteBandaCommand(Guid idBanda)
        {
            IdBanda = idBanda;
        }
    }

    public class DeleteBandaCommandResponse
    {

    }
}
