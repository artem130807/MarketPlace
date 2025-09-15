using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsAuthors
{
    public interface IAuthorRepository
    {
        public Task<List<Authors>> GetAuthors();
        public Task<Authors> GetAuthorById(int id);
        public Task<Authors> AddAuthor(Authors authors);
        public Task<Authors> UpdateAuthor(Authors authors);
        public Task DeleteAuthor(int id);       
    }
}
