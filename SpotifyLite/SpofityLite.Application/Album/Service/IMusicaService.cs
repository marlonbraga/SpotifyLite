using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Service
{
    public interface IMusicaService
    {
        Task<MusicaOutputDto> Criar(MusicaInputDto dto);
        Task<List<MusicaOutputDto>> ObterTodos();
        Task<MusicaOutputDto> Obter(Guid id);
        Task<MusicaOutputDto> Editar(Guid id, MusicaInputDto dto);
        Task<MusicaOutputDto> Deletar(Guid id);
    }
}