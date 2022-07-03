using MediatR;
using SpofityLite.Application.Usuario.Dto;

namespace SpotifyLite.Application.Usuario.Handler.Query
{
    public class GetAllUsuarioQuery : IRequest<GetAllUsuarioQueryResponse>
    {
    }

    public class GetAllUsuarioQueryResponse
    {
        public IList<UsuarioOutputDto> Usuarios { get; set; }

        public GetAllUsuarioQueryResponse(IList<UsuarioOutputDto> usuarios)
        {
            Usuarios = usuarios;
        }
    }
}
