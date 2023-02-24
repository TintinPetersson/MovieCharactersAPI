using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models
{
    public class Franchise
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
