using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services.Characters
{
    public interface ICharacterService
    {
        Task<ICollection<Movie>> GetAllCharacters();
        Task<Movie> GetCharacterById(int id);
        Task AddCharacter(Character character);
        Task UpdateCharacter(Character character);
        Task DeleteCharacter(int id);
    }
}