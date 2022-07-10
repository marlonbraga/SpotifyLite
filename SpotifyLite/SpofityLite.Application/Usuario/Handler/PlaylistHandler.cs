using MediatR;
using SpofityLite.Application.Usuario.Service;
using SpotifyLite.Application.Usuario.Handler.Command;
using SpotifyLite.Application.Usuario.Handler.Query;

namespace SpofityLite.Application.Usuario.Handler
{
    public class PlaylistHandler : IRequestHandler<CreatePlaylistCommand, CreatePlaylistCommandResponse>,
                                   IRequestHandler<GetAllPlaylistQuery, GetAllPlaylistQueryResponse>,
                                   IRequestHandler<GetPlaylistQuery, GetPlaylistQueryResponse>,
                                   IRequestHandler<DeletePlaylistCommand, DeletePlaylistCommandResponse>,
                                   IRequestHandler<EditPlaylistCommand, EditPlaylistCommandResponse>
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistHandler(IPlaylistService PlaylistService)
        {
            _playlistService = PlaylistService;
        }

        public async Task<CreatePlaylistCommandResponse> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.Criar(request.Playlist);
            return new CreatePlaylistCommandResponse(result);
        }

        public async Task<GetAllPlaylistQueryResponse> Handle(GetAllPlaylistQuery request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.ObterTodos();
            return new GetAllPlaylistQueryResponse(result);
        }

        public async Task<GetPlaylistQueryResponse> Handle(GetPlaylistQuery request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.Obter(request.IdPlaylist);
            return new GetPlaylistQueryResponse(result);
        }

        public async Task<DeletePlaylistCommandResponse> Handle(DeletePlaylistCommand request, CancellationToken cancellationToken)
        {
            await this._playlistService.Deletar(request.IdPlaylist);
            return new DeletePlaylistCommandResponse();
        }

        public async Task<EditPlaylistCommandResponse> Handle(EditPlaylistCommand request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.Editar(request.IdPlaylist, request.Playlist);
            return new EditPlaylistCommandResponse(result);
        }
    }
}
