using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Dtos.Movies;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly MovieCharactersDbContext _context;
        public MovieService(MovieCharactersDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Movie>> GetAllMovies()
        {
            return await _context.Movies
             .Include(m => m.Characters)
             .ToListAsync();
        }
        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }
            return movie;
        }
        public async Task AddMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateMovie(Movie movie)
        {
            if (!await MovieExists(movie.Id))
            {
                throw new MovieNotFoundException(movie.Id);
            }
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCharactersFromMovie(int[] characterIds, int movieId)
        {
            if (!await MovieExists(movieId))
            {
                throw new MovieNotFoundException(movieId);
            }

            List<Character> characters = characterIds
                .ToList()
                .Select(characterId => _context.Characters
                .Where(c => c.Id == characterId).First())
                .ToList();

            Movie movie = await _context.Movies
                .Where(m => m.Id == movieId)
                .FirstAsync();

            movie.Characters = characters;

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
        private async Task<bool> MovieExists(int id)
        {
            return await _context.Movies.AnyAsync(m => m.Id == id);
        }
    }
}