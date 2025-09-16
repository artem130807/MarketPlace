using AutoMapper;
using WebApplication1.Contracts.ContractsGenres;
using WebApplication1.DtoModels.DtoGenres;

namespace WebApplication1.Service
{
    public class GenresService:IGenresService
    {
        private readonly IGenresRepository _genresRepository;
        private readonly IMapper _mapper;
        public GenresService(IGenresRepository genresRepository, IMapper mapper)
        {
            _genresRepository = genresRepository;
            _mapper = mapper;
        }

        public async Task<List<DtoGenresResponce>> GetGenres()
        {
            var genres = await _genresRepository.GetGenres();
            return _mapper.Map<List<DtoGenresResponce>>(genres);    
        }
    }
}
