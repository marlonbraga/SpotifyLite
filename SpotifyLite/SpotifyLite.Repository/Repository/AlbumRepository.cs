using Microsoft.EntityFrameworkCore;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Repository.Context;
using SpotifyLite.Repository.Database;

namespace SpotifyLite.Repository.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(SpotifyContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Album>> ObterTodosAlbuns()
        {
            return await this.Query.Include(x => x.Musicas).ToListAsync();
        }

    }
}
