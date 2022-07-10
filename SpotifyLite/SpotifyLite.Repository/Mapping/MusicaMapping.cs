using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyLite.Domain.Album;

namespace SpotifyLite.Repository.Mapping
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable("Musica");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);

            builder.OwnsOne(x => x.Duracao, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Duracao").IsRequired();
            });


        }
    }
}

