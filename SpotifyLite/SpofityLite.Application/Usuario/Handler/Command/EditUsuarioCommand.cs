using MediatR;
using SpofityLite.Application.Usuario.Dto;

namespace SpotifyLite.Application.Usuario.Handler.Command
{
    public class EditUsuarioCommand : IRequest<EditUsuarioCommandResponse>
    {
        public UsuarioInputDto Usuario { get; set; }

        public Guid IdUsuario { get; set; }

        public EditUsuarioCommand(Guid idUsuario, UsuarioInputDto usuario)
        {
            IdUsuario = idUsuario;
            Usuario = usuario;
        }
    }

    public class EditUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public EditUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
