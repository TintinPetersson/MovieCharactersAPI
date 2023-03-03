using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services.Characters
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieCharactersDbContext _context;
        public CharacterService(MovieCharactersDbContext context)
        {
            _context = context;
        }
        public async Task AddCharacter(Character character)
        {
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Character>> GetAllCharacters()
        {
            return await _context.Characters
             .Include(c => c.Movies)
             .ToListAsync();
        }
        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }
            return character;
        }
        public async Task UpdateCharacter(Character character)
        {
            if (!await CharacterExists(character.Id))
            {
                throw new CharacterNotFoundException(character.Id);
            }
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        private async Task<bool> CharacterExists(int id)
        {
            return await _context.Characters.AnyAsync(c => c.Id == id);
        }
    }
}