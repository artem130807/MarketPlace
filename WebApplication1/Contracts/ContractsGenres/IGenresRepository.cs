using WebApplication1.DtoModels.DtoGenres;
using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsGenres
{
    public interface IGenresRepository
    {
        public Task<List<Genres>> GetGenres();
    }
}
