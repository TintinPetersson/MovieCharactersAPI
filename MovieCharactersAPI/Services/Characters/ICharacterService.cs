using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services.Characters
{
    public interface ICharacterService
    {
        Task<ICollection<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
        Task AddCharacter(Character character);
        Task UpdateCharacter(Character character);
        Task DeleteCharacter(int id);
    }
}