using MediatR;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;
using SpofityLite.Application.Album.Service;

namespace SpofityLite.Application.Album.Handler
{
    public class MusicaHandler : IRequestHandler<CreateMusicaCommand, CreateMusicaCommandResponse>,
                                 IRequestHandler<GetAllMusicaQuery, GetAllMusicaQueryResponse>,
                                 IRequestHandler<GetMusicaQuery, GetMusicaQueryResponse>,
                                 IRequestHandler<DeleteMusicaCommand, DeleteMusicaCommandResponse>,
                                 IRequestHandler<EditMusicaCommand, EditMusicaCommandResponse>
    {
        private readonly IMusicaService _musicaService;

        public MusicaHandler(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        public async Task<CreateMusicaCommandResponse> Handle(CreateMusicaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._musicaService.Criar(request.Musica);
            return new CreateMusicaCommandResponse(result);
        }

        public async Task<GetAllMusicaQueryResponse> Handle(GetAllMusicaQuery request, CancellationToken cancellationToken)
        {
            var result = await this._musicaService.ObterTodos();
            return new GetAllMusicaQueryResponse(result);
        }

        public async Task<GetMusicaQueryResponse> Handle(GetMusicaQuery request, CancellationToken cancellationToken)
        {
            var result = await this._musicaService.Obter(request.IdMusica);
            return new GetMusicaQueryResponse(result);
        }

        public async Task<DeleteMusicaCommandResponse> Handle(DeleteMusicaCommand request, CancellationToken cancellationToken)
        {
            await this._musicaService.Deletar(request.IdMusica);
            return new DeleteMusicaCommandResponse();
        }

        public async Task<EditMusicaCommandResponse> Handle(EditMusicaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._musicaService.Editar(request.IdMusica, request.Musica);
            return new EditMusicaCommandResponse(result);
        }
    }
}
