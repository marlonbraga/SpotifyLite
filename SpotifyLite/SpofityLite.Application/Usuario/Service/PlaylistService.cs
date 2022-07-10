using AutoMapper;
using SpofityLite.Application.Usuario.Dto;
using SpotifyLite.Domain.Account.Repository;

namespace SpofityLite.Application.Album.Service
{
    public class PlaylistService
    {
        private readonly IPlaylistRepository PlaylistRepository;
        private readonly IMapper mapper;

        public PlaylistService(IPlaylistRepository PlaylistRepository, IMapper mapper)
        {
            this.PlaylistRepository = PlaylistRepository;
            this.mapper = mapper;
        }

        public async Task<PlaylistOutputDto> Criar(PlaylistInputDto dto)
        {
            var Playlist = this.mapper.Map<SpotifyLite.Domain.Account.Playlist>(dto);
            await this.PlaylistRepository.Save(Playlist);
            return this.mapper.Map<PlaylistOutputDto>(Playlist);
        }

        public async Task<PlaylistOutputDto> Deletar(Guid id)
        {
            var Playlist = await this.PlaylistRepository.Get(id);
            await this.PlaylistRepository.Delete(Playlist);
            return this.mapper.Map<PlaylistOutputDto>(Playlist);
        }

        public async Task<PlaylistOutputDto> Editar(Guid id, PlaylistInputDto dto)
        {
            var Playlist = this.mapper.Map<SpotifyLite.Domain.Account.Playlist>(dto);
            Playlist.Id = id;
            await this.PlaylistRepository.Update(Playlist);
            return this.mapper.Map<PlaylistOutputDto>(Playlist);
        }

        public async Task<PlaylistOutputDto> Obter(Guid id)
        {
            var Playlist = await this.PlaylistRepository.Get(id);
            return this.mapper.Map<PlaylistOutputDto>(Playlist);
        }

        public async Task<List<PlaylistOutputDto>> ObterTodos()
        {
            var Playlist = await this.PlaylistRepository.GetAll();
            return this.mapper.Map<List<PlaylistOutputDto>>(Playlist);
        }
    }
}
