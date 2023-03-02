using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Dtos.Franchises
{
    public class FranchiseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Movies { get; set; }
    }
}
