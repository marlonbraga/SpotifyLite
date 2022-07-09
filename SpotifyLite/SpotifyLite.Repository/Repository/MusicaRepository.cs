using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Repository.Context;
using SpotifyLite.Repository.Database;

namespace SpotifyLite.Repository.Repository
{
    public class MusicaRepository : Repository<Musica>, IMusicaRepository
    {
        public MusicaRepository(SpotifyContext context) : base(context)
        {
        }
    }
}
