using SpotifyLite.CrossCutting.Entity;
using SpotifyLite.Domain.Album.Factory;

namespace SpotifyLite.Domain.Album
{
    public class Banda : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public virtual IList<Album> Albums { get; set; }


        public void CreateAlbum(string nome, IList<Musica> musicas)
        {
            var album = AlbumFactory.Create(nome, musicas);
            this.Albums.Add(album);
        }

        public int QuantidadeAlbuns()
            => this.Albums.Count;

        public IEnumerable<Musica> ObterMusicas()
            => this.Albums.SelectMany(x => x.Musicas).AsEnumerable();

    }
}
