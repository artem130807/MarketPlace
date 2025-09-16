using WebApplication1.DtoModels.DtoGenres;

namespace WebApplication1.Contracts.ContractsGenres
{
    public interface IGenresService
    {
        public Task<List<DtoGenresResponce>> GetGenres();
    }
}
