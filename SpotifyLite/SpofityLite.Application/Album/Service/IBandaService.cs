using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Service
{
    public interface IBandaService
    {
        Task<BandaOutputDto> Criar(BandaInputDto dto);
        Task<List<BandaOutputDto>> ObterTodos();
        Task<BandaOutputDto> Obter(Guid id);
        Task<BandaOutputDto> Editar(Guid id, BandaInputDto dto);
        Task<BandaOutputDto> Deletar(Guid id);
    }
}