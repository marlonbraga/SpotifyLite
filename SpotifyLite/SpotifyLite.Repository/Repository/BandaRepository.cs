using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Repository.Context;
using SpotifyLite.Repository.Database;

namespace SpotifyLite.Repository.Repository
{
    public class BandaRepository : Repository<Banda>, IBandaRepository
    {
        public BandaRepository(SpotifyContext context) : base(context)
        {
        }
    }
}
