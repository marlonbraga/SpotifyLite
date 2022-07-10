using SpotifyLite.CrossCutting.Repository;

namespace SpotifyLite.Domain.Album.Repository
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<IEnumerable<Album>> ObterTodosAlbuns();
    }
}
