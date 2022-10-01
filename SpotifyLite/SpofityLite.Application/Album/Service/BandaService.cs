using AutoMapper;
using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Repository.Infraestructure;

namespace SpofityLite.Application.Album.Service
{
    public class BandaService : IBandaService
    {
        private readonly IBandaRepository bandaRepository;
        private readonly IMapper mapper;
        private IHttpClientFactory httpClientFactory;
        private AzureBlobStorage storage;

        public BandaService(IBandaRepository bandaRepository, IMapper mapper, IHttpClientFactory httpClientFactory, AzureBlobStorage storage)
        {
            this.bandaRepository = bandaRepository;
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
            this.storage = storage;
        }

        public async Task<BandaOutputDto> Criar(BandaInputDto dto)
        {
            var banda = this.mapper.Map<Banda>(dto);
            HttpClient httpClient = this.httpClientFactory.CreateClient();
            using HttpResponseMessage response = await httpClient.GetAsync(banda.Foto);
            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                var fileName = $"{Guid.NewGuid()}.jpg";
                var pathStorage = await this.storage.UploadFile(fileName, stream, "bandas");
                banda.Foto = pathStorage;

            }

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
