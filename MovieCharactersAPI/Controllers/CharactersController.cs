using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Dtos.Characters;
using MovieCharactersAPI.Dtos.Franchises;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Services.Characters;
using System.Net.Mime;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        /// <summary>
        ///     Gets all characters stored in Db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return Ok(_mapper.Map<ICollection<CharacterDTO>>(await _characterService.GetAllCharacters()));
        }

        /// <summary>
        ///     Gets specific character by id
        /// </summary>
        /// <param name="id">character id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            try
            {
                var character = await _characterService.GetCharacterById(id);
                var characterDto = _mapper.Map<CharacterDTO>(character);
                return Ok(characterDto);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        ///     Updates a existing character in Db
        /// </summary>
        /// <param name="id">character id</param>
        /// <param name="character">Character information like Full name, alias mm, see example values below: </param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterPutDto character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            try
            {
                await _characterService.UpdateCharacter(
                    _mapper.Map<Character>(character));
                return NoContent();
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        ///     Inserts a new character to Db
        /// </summary>
        /// <param name="character">Character information like Full name, alias mm, see example values below: </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterPostDto character)
        {
            Character newCharacter = _mapper.Map<Character>(character);
            await _characterService.AddCharacter(newCharacter);
            return CreatedAtAction("GetCharacter", new { id = newCharacter.Id }, newCharacter);
        }

        /// <summary>
        ///     Deletes a existing character in Db
        /// </summary>
        /// <param name="id">character id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                await _characterService.DeleteCharacter(id);
            }
            catch (CharacterNotFoundException ex)
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
