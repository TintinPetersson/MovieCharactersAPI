using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public partial class Character
    {
        public Character()
        {
            Movies = new List<Movie>();
        }
        public int Id { get; set; }
        [MaxLength(40)]
        public string FullName { get; set; }
        [MaxLength(40)]
        public string? Alias { get; set; }
        public Gender Gender { get; set; }
        //Picture (URL to photo – do not store an image)
        public string Photo { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}