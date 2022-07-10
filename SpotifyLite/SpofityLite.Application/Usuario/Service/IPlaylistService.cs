using SpofityLite.Application.Usuario.Dto;

namespace SpofityLite.Application.Usuario.Service
{
    public interface IPlaylistService
    {
        Task<PlaylistOutputDto> Criar(PlaylistInputDto dto);
        Task<List<PlaylistOutputDto>> ObterTodos();
        Task<PlaylistOutputDto> Obter(Guid id);
        Task<PlaylistOutputDto> Editar(Guid id, PlaylistInputDto dto);
        Task<PlaylistOutputDto> Deletar(Guid id);
    }
}