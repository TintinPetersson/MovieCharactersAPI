using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public interface IMovieService
    {
        Task<ICollection<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task AddMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
    }
}
