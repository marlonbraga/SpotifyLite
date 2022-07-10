using MediatR;

namespace SpotifyLite.Application.Usuario.Handler.Command
{
    public class DeleteUsuarioCommand : IRequest<DeleteUsuarioCommandResponse>
    {
        public Guid IdUsuario { get; set; }

        public DeleteUsuarioCommand(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }

    public class DeleteUsuarioCommandResponse
    {

    }
}
