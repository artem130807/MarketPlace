using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts.ContractsAuthors;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AuthorsRepositories:IAuthorRepository
    {
        private readonly MarketPlaceDbContext _context;
        public AuthorsRepositories(MarketPlaceDbContext context)
        {
            _context = context;
        }

        public async Task<Authors> AddAuthor(Authors authors)
        {
            _context.Authors.Add(authors);
            await _context.SaveChangesAsync();
            return authors;
        }

        public async Task DeleteAuthor(int id)
        {
           var deleteauthor =  await _context.Authors.FindAsync(id);
            if(deleteauthor == null)
            {
                throw new Exception("Автор не найден");
            }
           _context.Authors.Remove(deleteauthor);
        }

        public async Task<Authors> GetAuthorById(int id)
        {
            var author = await _context.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
            {
                throw new Exception("Автор не найден");
            }
            return author;
        }
        
        public async Task<List<Authors>> GetAuthors()
        {
            return await _context.Authors.Include(x => x.Books).ToListAsync();
        }

        public async Task<Authors> UpdateAuthor(Authors authors)
        {
            _context.Authors.Update(authors);
            await _context.SaveChangesAsync();
            return authors;
        }
    }
}
