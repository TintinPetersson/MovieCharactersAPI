using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services.Franchises
{
    public interface IFranchiseService
    {
        Task<ICollection<Franchise>> GetAllFranchises();
        Task<Franchise> GetFranchiseById(int id);
        Task AddFranchise(Franchise franchise);
        Task UpdateFranchise(Franchise franchise);
        Task DeleteFranchise(int id);
        Task UpdateMoviesFromFranchise(int[] movieIds, int id);
    }
}
