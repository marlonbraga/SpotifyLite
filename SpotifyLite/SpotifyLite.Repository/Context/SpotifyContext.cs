using Microsoft.EntityFrameworkCore;

namespace SpotifyLite.Repository.Context
{
    public class SpotifyContext : DbContext
    {

        public SpotifyContext(DbContextOptions<SpotifyContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpotifyContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
