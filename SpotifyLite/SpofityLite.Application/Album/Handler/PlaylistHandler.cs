using MediatR;
using SpofityLite.Application.Usuario.Service;
using SpotifyLite.Application.Usuario.Handler.Command;
using SpotifyLite.Application.Usuario.Handler.Query;

namespace SpofityLite.Application.Album.Handler
{
    public class PlaylistHandler : IRequestHandler<CreatePlaylistCommand, CreatePlaylistCommandResponse>,
                                IRequestHandler<GetAllPlaylistQuery, GetAllPlaylistQueryResponse>,
                                IRequestHandler<GetPlaylistQuery, GetPlaylistQueryResponse>,
                                IRequestHandler<DeletePlaylistCommand, DeletePlaylistCommandResponse>,
                                IRequestHandler<EditPlaylistCommand, EditPlaylistCommandResponse>
    {
        private readonly IPlaylistService _albumService;

        public PlaylistHandler(IPlaylistService albumService)
        {
            _albumService = albumService;
        }

        public async Task<CreatePlaylistCommandResponse> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Criar(request.Playlist);
            return new CreatePlaylistCommandResponse(result);
        }

        public async Task<GetAllPlaylistQueryResponse> Handle(GetAllPlaylistQuery request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.ObterTodos();
            return new GetAllPlaylistQueryResponse(result);
        }

        public async Task<GetPlaylistQueryResponse> Handle(GetPlaylistQuery request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Obter(request.IdPlaylist);
            return new GetPlaylistQueryResponse(result);
        }

        public async Task<DeletePlaylistCommandResponse> Handle(DeletePlaylistCommand request, CancellationToken cancellationToken)
        {
            await this._albumService.Deletar(request.IdPlaylist);
            return new DeletePlaylistCommandResponse();
        }

        public async Task<EditPlaylistCommandResponse> Handle(EditPlaylistCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Editar(request.IdPlaylist, request.Playlist);
            return new EditPlaylistCommandResponse(result);
        }
    }
}
