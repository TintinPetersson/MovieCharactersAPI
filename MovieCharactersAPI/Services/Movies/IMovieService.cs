using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services.Movies
{
    public interface IMovieService
    {
        Task<ICollection<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task AddMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task UpdateCharactersAsync(int[] characterIds, int movieId);
        Task DeleteMovie(int id);
    }
}
