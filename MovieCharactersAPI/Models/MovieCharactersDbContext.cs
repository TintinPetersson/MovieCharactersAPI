using Microsoft.EntityFrameworkCore;

namespace MovieCharactersAPI.Models
{
    public class MovieCharactersDbContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public MovieCharactersDbContext(DbContextOptions options):base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Filips Adventure"},
                new Movie { Id = 2, Name = "Tommy's Wedding" }
                );
        }
    }
}
