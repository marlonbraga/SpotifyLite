using AutoMapper;
using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Album.Repository;

namespace SpofityLite.Application.Album.Service
{
    public class MusicaService : IMusicaService
    {
        private readonly IMusicaRepository MusicaRepository;
        private readonly IMapper mapper;

        public MusicaService(IMusicaRepository MusicaRepository, IMapper mapper)
        {
            this.MusicaRepository = MusicaRepository;
            this.mapper = mapper;
        }

        public async Task<MusicaOutputDto> Criar(MusicaInputDto dto)
        {
            var Musica = this.mapper.Map<SpotifyLite.Domain.Album.Musica>(dto);
            await this.MusicaRepository.Save(Musica);
            return this.mapper.Map<MusicaOutputDto>(Musica);
        }

        public async Task<MusicaOutputDto> Deletar(Guid id)
        {
            var Musica = await this.MusicaRepository.Get(id);
            await this.MusicaRepository.Delete(Musica);
            return this.mapper.Map<MusicaOutputDto>(Musica);
        }

        public async Task<MusicaOutputDto> Editar(Guid id, MusicaInputDto dto)
        {
            var Musica = this.mapper.Map<SpotifyLite.Domain.Album.Musica>(dto);
            Musica.Id = id;
            await this.MusicaRepository.Update(Musica);
            return this.mapper.Map<MusicaOutputDto>(Musica);
        }

        public async Task<MusicaOutputDto> Obter(Guid id)
        {
            var Musica = await this.MusicaRepository.Get(id);
            return this.mapper.Map<MusicaOutputDto>(Musica);
        }

        public async Task<List<MusicaOutputDto>> ObterTodos()
        {
            var Musica = await this.MusicaRepository.GetAll();
            return this.mapper.Map<List<MusicaOutputDto>>(Musica);
        }
    }
}
