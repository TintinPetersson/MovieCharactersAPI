using Microsoft.EntityFrameworkCore;

namespace MovieCharactersAPI.Models
{
    public class MovieCharactersDbContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public MovieCharactersDbContext(DbContextOptions options):base (options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Filips Adventure"},
                new Movie { Id = 2, Title = "Tommy's Wedding" }
                );
            modelBuilder.Entity<Movie>().HasData(
                new Character { Id = 1, FullName = "Filip" },
                new Character { Id = 2, FullName = "Tommy" }
                );
            modelBuilder.Entity<Movie>().HasData(
                new Franchise { Id = 1, Name = "Experis Cinematic Universe" }
                );
        }
    }
}
