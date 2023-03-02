using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services.Franchises
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieCharactersDbContext _context;
        public FranchiseService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public async Task AddFranchise(Franchise franchise)
        {
            await _context.Franchises.AddAsync(franchise);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Franchise>> GetAllFranchises()
        {
            return await _context.Franchises
             .Include(p => p.Movies)
             .ToListAsync();
        }

        public async Task<Franchise> GetFranchiseById(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }
            return franchise;
        }

        public async Task UpdateFranchise(Franchise franchise)
        {
            if (!await FranchiseExists(franchise.Id))
            {
                throw new FranchiseNotFoundException(franchise.Id);
            }
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMoviesFromFranchise(int[] movieIds, int franchiseId)
        {
            if (!await FranchiseExists(franchiseId))
            {
                throw new FranchiseNotFoundException(franchiseId);
            }

            List<Movie> movies = movieIds
                .ToList()
                .Select(movieIds => _context.Movies
                .Where(c => c.Id == movieIds).First())
                .ToList();

            Franchise franchise = await _context.Franchises
                .Where(m => m.Id == franchiseId)
                .FirstAsync();

            franchise.Movies = movies;

            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private async Task<bool> FranchiseExists(int id)
        {
            return await _context.Franchises.AnyAsync(f => f.Id == id);
        }
    }
}
