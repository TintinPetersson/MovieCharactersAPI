using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public interface IMovieService
    {
        Task<ICollection<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> AddMovie(Movie movie);
        Task DeleteMovie(int id);
        Task<Movie> UpdateMovie(Movie movie);
    }
}
