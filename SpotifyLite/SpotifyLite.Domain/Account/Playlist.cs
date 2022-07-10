using SpotifyLite.CrossCutting.Entity;
using SpotifyLite.Domain.Album;

namespace SpotifyLite.Domain.Account
{
    public class Playlist : Entity<Guid>
    {
        public string Nome { get; set; }
        public virtual IList<Musica> Musicas { get; set; }
    }
}
