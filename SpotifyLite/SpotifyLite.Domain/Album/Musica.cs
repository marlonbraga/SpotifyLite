using SpotifyLite.CrossCutting.Entity;
using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Album.ValueObject;

namespace SpotifyLite.Domain.Album
{
    public class Musica : Entity<Guid>
    {
        public string Nome { get; set; }
        public Duracao Duracao { get; set; }

        public virtual IList<Playlist> Playlists { get; set; }
    }
}
