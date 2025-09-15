using WebApplication1.DtoModels.DtoAuthor;
using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsAuthors
{
    public interface IAuthorsService
    {
        public Task<List<DtoAuthors>> GetAuthors();
        public Task<DtoAuthorsResponce> GetAuthorById(int id);
        public Task<DtoAuthors> AddAuthor(DtoCreateAuthor dtocreateauthors);
        public Task<DtoAuthors> UpdateAuthor(int id,DtoUpdateAuthors dtoupdateauthors);
        public Task DeleteAuthor(int id);
    }
}
