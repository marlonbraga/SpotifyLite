using AutoMapper;
using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Album.Repository;

namespace SpofityLite.Application.Album.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IMapper mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            this.albumRepository = albumRepository;
            this.mapper = mapper;
        }

        public async Task<AlbumOutputDto> Criar(AlbumInputDto dto)
        {
            var album = this.mapper.Map<SpotifyLite.Domain.Album.Album>(dto);
            await this.albumRepository.Save(album);
            return this.mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<List<AlbumOutputDto>> ObterTodos()
        {
            var album = await this.albumRepository.GetAll();
            return this.mapper.Map<List<AlbumOutputDto>>(album);
        }

        public async Task<AlbumOutputDto> Deletar(Guid id)
        {
            var Album = await this.albumRepository.Get(id);
            await this.albumRepository.Delete(Album);
            return this.mapper.Map<AlbumOutputDto>(Album);
        }

        public async Task<AlbumOutputDto> Editar(Guid id, AlbumInputDto dto)
        {
            var Album = this.mapper.Map<SpotifyLite.Domain.Album.Album>(dto);
            Album.Id = id;
            await this.albumRepository.Update(Album);
            return this.mapper.Map<AlbumOutputDto>(Album);
        }

        public async Task<AlbumOutputDto> Obter(Guid id)
        {
            var Album = await this.albumRepository.Get(id);
            return this.mapper.Map<AlbumOutputDto>(Album);
        }
    }
}
