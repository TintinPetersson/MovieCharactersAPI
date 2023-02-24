using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Character
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string FullName { get; set; }
        [MaxLength(40)]
        public string? Alias { get; set; }
        public Gender Gender { get; set; }
        //Picture (URL to photo – do not store an image)
        public string Photo { get; set; }
        public List<Movie> Movies { get; set; }
    }
}