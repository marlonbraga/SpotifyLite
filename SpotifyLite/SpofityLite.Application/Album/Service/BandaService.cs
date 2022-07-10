using AutoMapper;
using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;

namespace SpofityLite.Application.Album.Service
{
    public class BandaService : IBandaService
    {
        private readonly IBandaRepository bandaRepository;
        private readonly IMapper mapper;

        public BandaService(IBandaRepository bandaRepository, IMapper mapper)
        {
            this.bandaRepository = bandaRepository;
            this.mapper = mapper;
        }

        public async Task<BandaOutputDto> Criar(BandaInputDto dto)
        {
            var banda = this.mapper.Map<Banda>(dto);
            await this.bandaRepository.Save(banda);
            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<List<BandaOutputDto>> ObterTodos()
        {
            var result = await this.bandaRepository.GetAll();
            return this.mapper.Map<List<BandaOutputDto>>(result);
        }

        public async Task<BandaOutputDto> Deletar(Guid id)
        {
            var Banda = await this.bandaRepository.Get(id);
            await this.bandaRepository.Delete(Banda);
            return this.mapper.Map<BandaOutputDto>(Banda);
        }

        public async Task<BandaOutputDto> Editar(Guid id, BandaInputDto dto)
        {
            var Banda = this.mapper.Map<SpotifyLite.Domain.Album.Banda>(dto);
            Banda.Id = id;
            await this.bandaRepository.Update(Banda);
            return this.mapper.Map<BandaOutputDto>(Banda);
        }

        public async Task<BandaOutputDto> Obter(Guid id)
        {
            var Banda = await this.bandaRepository.Get(id);
            return this.mapper.Map<BandaOutputDto>(Banda);
        }
    }
}
