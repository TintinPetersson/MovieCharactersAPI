using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services.Movies
{
    public interface IMovieService
    {
        Task<ICollection<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task AddMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task UpdateCharactersFromMovie(int[] characterIds, int movieId);
        Task DeleteMovie(int id);
    }
}
