using AutoMapper;
using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Repository.Infraestructure;
using System.Net.Http;

namespace SpofityLite.Application.Album.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IMapper mapper;
        private IHttpClientFactory httpClientFactory;
        private AzureBlobStorage storage;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper, IHttpClientFactory httpClientFactory, AzureBlobStorage storage)
        {
            this.albumRepository = albumRepository;
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
            this.storage = storage;
        }

        public async Task<AlbumOutputDto> Criar(AlbumInputDto dto)
        {
            var album = this.mapper.Map<SpotifyLite.Domain.Album.Album>(dto);
            HttpClient httpClient = this.httpClientFactory.CreateClient();
            using HttpResponseMessage response = await httpClient.GetAsync(album.Backdrop);
            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                var fileName = $"{Guid.NewGuid()}.jpg";
                var pathStorage = await this.storage.UploadFile(fileName, stream, "capas");
                album.Backdrop = pathStorage;

            }

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
