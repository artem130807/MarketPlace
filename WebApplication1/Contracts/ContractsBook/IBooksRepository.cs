using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsBook
{
    public interface IBooksRepository
    {
        public Task<List<Books>> GetBooks();
        public Task<Books> GetBookById(int id);
        public Task<Books> AddBook(Books books);    
        public Task<Books> UpdateBook(int id, Books books);
        public Task DeleteBook(int id);
    }
}
