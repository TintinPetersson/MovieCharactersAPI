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
                new Movie { Id = 1, Title = "Filips Adventure", Genre = "Action, Adventure", ReleaseYear = 2001, Director = "Tintin The Big", Picture = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg", Trailer = "https://www.youtube.com/watch?v=OMGBIQHODhw", FranchiseId = 1 },
                new Movie { Id = 2, Title = "Tommy's Wedding", Genre = "Drama, Comedy", ReleaseYear = 2010, Director = "Tintin The Big", Picture = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg", Trailer = "https://www.youtube.com/watch?v=OMGBIQHODhw", FranchiseId = 1 },
                new Movie { Id = 3, Title = "Tintin", Genre = "Action, Comedy", ReleaseYear = 2012, Director = "Albert Einstein", Picture = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg", Trailer = "https://www.youtube.com/watch?v=OMGBIQHODhw", FranchiseId = 2 }
                );
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, FullName = "Filip", Alias = "FillePille", Gender = Gender.Other, Photo = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg" },
                new Character { Id = 2, FullName = "Tommy", Alias = "TommyBoy", Gender = Gender.Male, Photo = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg" },
                new Character { Id = 3, FullName = "Tintin", Alias = "mr100", Gender = Gender.Female, Photo = "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg" }
                );
            modelBuilder.Entity<Franchise>().HasData(
                new Franchise { Id = 1, Name = "Experis Cinematic Universe", Description = "Big Universe with Big ideas." },
                new Franchise { Id = 2, Name = "Yh Cinematic Universe", Description = "Tintins Yh adventures" }
                );
        }
    }
}
