using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Dtos.Franchises;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Services.Franchises;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        /// <summary>
        ///     Gets all franchises stored in Db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            return Ok(_mapper.Map<ICollection<FranchiseDto>>(await _franchiseService.GetAllFranchises()));
        }

        /// <summary>
        ///     Gets specific franchise by id
        /// </summary>
        /// <param name="id">franchise id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            try
            {
                return await _franchiseService.GetFranchiseById(id);
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        ///     Updates a existing franchise in Db
        /// </summary>
        /// <param name="id">franchise id</param>
        /// <param name="franchise">franchise name, id and description</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchisePutDto franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            try
            {
                await _franchiseService.UpdateFranchise(
                    _mapper.Map<Franchise>(franchise));
                return NoContent();
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        ///     Inserts a new franchise to Db
        /// </summary>
        /// <param name="franchise">franchise name and description</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchisePostDto franchise)
        {
            Franchise newFranchise = _mapper.Map<Franchise>(franchise);
            await _franchiseService.AddFranchise(newFranchise);
            return CreatedAtAction("GetFranchise", new { id = newFranchise.Id }, newFranchise);
        }

        /// <summary>
        ///     Updates movies that a character have stared in
        /// </summary>
        /// <param name="id">franchise id</param>
        /// <param name="movieIds">Enter a list of movies by Id that a character stars in</param>
        /// <returns></returns>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateMoviesInFranchise(int[] movieIds, int id)
        {
            try
            {
                await _franchiseService.UpdateMoviesFromFranchise(movieIds, id);
                return NoContent();
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        ///     Deletes a existing franchise in Db
        /// </summary>
        /// <param name="id">franchise id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                await _franchiseService.DeleteFranchise(id);
            }
            catch (FranchiseNotFoundException ex)
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
