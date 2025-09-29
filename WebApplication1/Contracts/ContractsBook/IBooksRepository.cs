using WebApplication1.DtoModels.DtoBook;
using WebApplication1.Models;
using WebApplication1.ModelsFiltr;

namespace WebApplication1.Contracts.ContractsBook
{
    public interface IBooksRepository
    {
        public Task<List<Books>> GetBooks();
        public Task<List<Books>> GetBooksFiltr(BooksQueryParametr booksQueryParametr);
        public Task<Books> GetBookById(int id);
        public Task<Books> GetBookByTitle(string titlename);
        public Task<Books> AddBook(Books books);    
        public Task<Books> UpdateBook(int id, Books books);
        public Task DeleteBook(int id);
    }
}
