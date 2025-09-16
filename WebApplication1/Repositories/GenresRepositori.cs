using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts.ContractsGenres;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class GenresRepositori : IGenresRepository
    {
        private readonly MarketPlaceDbContext _context;
        public GenresRepositori(MarketPlaceDbContext context)
        {
            _context = context;
        }
        public async Task<List<Genres>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }
    }
}
