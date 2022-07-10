using MediatR;
using SpofityLite.Application.Usuario.Dto;

namespace SpotifyLite.Application.Usuario.Handler.Query
{
    public class GetUsuarioQuery : IRequest<GetUsuarioQueryResponse>
    {
        public Guid IdUsuario { get; set; }

        public GetUsuarioQuery(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }

    public class GetUsuarioQueryResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public GetUsuarioQueryResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
