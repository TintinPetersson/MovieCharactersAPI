using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Dtos.Movies;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Services.Movies;
using System.Net.Mime;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/v1/movie")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }
        /// <summary>
        ///     Gets all movies stored in Db
        /// </summary>
        /// <returns></returns>
        [HttpGet("movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return Ok(_mapper.Map<ICollection<MovieDto>>(await _movieService.GetAllMovies()));
        }
        /// <summary>
        ///     Gets specific movie by id
        /// </summary>
        /// <param name="id">Movie id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            try
            {
                return await _movieService.GetMovieById(id);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        /// <summary>
        ///     Inserts a new move to Db
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MoviePostDto movie)
        {
            Movie newMovie = _mapper.Map<Movie>(movie);
            await _movieService.AddMovie(newMovie);
            return CreatedAtAction("GetMovie", new { id = newMovie.Id }, newMovie);
        }
        /// <summary>
        ///     Updates a existing move in Db
        /// </summary>
        /// <param name="id">Movie id</param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MoviePutDto movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            try
            {
                await _movieService.UpdateMovie(
                    _mapper.Map<Movie>(movie));
                return NoContent();
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> UpdateCharactersInMovie(int[] characterIds, int id)
        {
            try
            {
                await _movieService.UpdateCharactersFromMovie(characterIds, id);
                return NoContent();
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        /// <summary>
        ///     Deletes a existing move in Db
        /// </summary>
        /// <param name="id">Movie id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _movieService.DeleteMovie(id);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
            return NoContent();
        }
    }
}
