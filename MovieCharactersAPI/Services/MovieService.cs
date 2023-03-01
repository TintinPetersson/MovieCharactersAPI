using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
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
             .Include(p => p.Characters)
             .ToListAsync();
        }
        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if(movie == null)
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