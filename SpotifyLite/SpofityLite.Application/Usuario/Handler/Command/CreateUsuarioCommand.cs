using MediatR;
using SpofityLite.Application.Usuario.Dto;

namespace SpotifyLite.Application.Usuario.Handler.Command
{
    public class CreateUsuarioCommand : IRequest<CreateUsuarioCommandResponse>
    {
        public UsuarioInputDto Usuario { get; set; }

        public CreateUsuarioCommand(UsuarioInputDto usuario)
        {
            Usuario = usuario;
        }
    }

    public class CreateUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public CreateUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
