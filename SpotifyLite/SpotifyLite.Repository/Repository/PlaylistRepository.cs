using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Account.Repository;
using SpotifyLite.Repository.Context;
using SpotifyLite.Repository.Database;

namespace SpotifyLite.Repository.Repository
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(SpotifyContext context) : base(context)
        {
        }
    }
}
