using WebApplication1.DtoModels.DtoBook;
using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsBook
{
    public interface IBooksService
    {
        public Task<List<DtoBookResponce>> GetBooksFiltr(DtoBookFiltr dtoBookFiltr);
        public Task<DtoBookResponce> GetBookById(int id);
        public Task<List<DtoBookResponce>> GetBooks();
        public Task<DtoBookByName> GetBookByTitle(string titlename);
        public Task<DtoBooks> AddBook(DtoBooksCreate dtocreatebooks);
        public Task<DtoBooks> UpdateBook(int id, DtoBooksUpdate dtoupdateBooks);
        public Task DeleteBook(int id);
    }
}
