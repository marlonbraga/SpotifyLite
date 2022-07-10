using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Service
{
    public interface IAlbumService
    {
        Task<AlbumOutputDto> Criar(AlbumInputDto dto);
        Task<List<AlbumOutputDto>> ObterTodos();
        Task<AlbumOutputDto> Obter(Guid id);
        Task<AlbumOutputDto> Editar(Guid id, AlbumInputDto dto);
        Task<AlbumOutputDto> Deletar(Guid id);
    }
}