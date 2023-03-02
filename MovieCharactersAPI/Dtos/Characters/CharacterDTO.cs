using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Dtos.Characters
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Alias { get; set; }
        public Gender Gender { get; set; }
        public string Photo { get; set; }
        public List<string> Movies { get; set; }
    }
}
