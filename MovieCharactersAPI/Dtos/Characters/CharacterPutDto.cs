using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Dtos.Characters
{
    public class CharacterPutDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Alias { get; set; } = null!;
        public Gender Gender { get; set; }
        public string Photo { get; set; } = null!;
    }
}
