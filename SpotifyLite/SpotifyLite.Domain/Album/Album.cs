using SpotifyLite.CrossCutting.Entity;

namespace SpotifyLite.Domain.Album
{
    public class Album : Entity<Guid>
    {
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Backdrop { get; set; }
        public virtual IList<Musica> Musicas { get; set; }

    }
}
