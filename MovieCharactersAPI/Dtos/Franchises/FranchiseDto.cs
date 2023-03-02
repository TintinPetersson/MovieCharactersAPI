using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Dtos.Franchises
{
    public class FranchiseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<string> Movies { get; set; }
    }
}
