using MediatR;
using SpofityLite.Application.Usuario.Service;
using SpotifyLite.Application.Usuario.Handler.Command;
using SpotifyLite.Application.Usuario.Handler.Query;

namespace SpofityLite.Application.Usuario.Handler
{
    public class UsuarioHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioCommandResponse>,
                                  IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioQueryResponse>,
                                  IRequestHandler<GetUsuarioQuery, GetUsuarioQueryResponse>,
                                  IRequestHandler<DeleteUsuarioCommand, DeleteUsuarioCommandResponse>,
                                  IRequestHandler<EditUsuarioCommand, EditUsuarioCommandResponse>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<CreateUsuarioCommandResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.Criar(request.Usuario);
            return new CreateUsuarioCommandResponse(result);
        }

        public async Task<GetAllUsuarioQueryResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.ObterTodos();
            return new GetAllUsuarioQueryResponse(result);
        }

        public async Task<GetUsuarioQueryResponse> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.Obter(request.IdUsuario);
            return new GetUsuarioQueryResponse(result);
        }

        public async Task<DeleteUsuarioCommandResponse> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            await this._usuarioService.Deletar(request.IdUsuario);
            return new DeleteUsuarioCommandResponse();
        }

        public async Task<EditUsuarioCommandResponse> Handle(EditUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.Editar(request.IdUsuario, request.Usuario);
            return new EditUsuarioCommandResponse(result);
        }
    }
}
