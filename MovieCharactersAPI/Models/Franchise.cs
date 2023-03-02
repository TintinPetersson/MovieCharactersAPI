using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models
{
    public partial class Franchise
    {
        public Franchise()
        {
            Movies = new List<Movie>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
