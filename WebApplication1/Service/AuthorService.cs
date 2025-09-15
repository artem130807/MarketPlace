using AutoMapper;
using WebApplication1.Contracts.ContractsAuthors;
using WebApplication1.DtoModels.DtoAuthor;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class AuthorService:IAuthorsService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<DtoAuthors> AddAuthor(DtoCreateAuthor dtoCreateAuthor)
        {
            var author = _mapper.Map<Authors>(dtoCreateAuthor);
            var addauthor = await _authorRepository.AddAuthor(author);
            return _mapper.Map<DtoAuthors>(addauthor);
        }

        public async Task DeleteAuthor(int id)
        {
            await _authorRepository.DeleteAuthor(id);
        }

        public async Task<DtoAuthorsResponce> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetAuthorById(id);
            return _mapper.Map<DtoAuthorsResponce>(author);
        }

        public async Task<List<DtoAuthors>> GetAuthors()
        {
             var author = await _authorRepository.GetAuthors();
             return _mapper.Map<List<DtoAuthors>>(author);
        }

        public async Task<DtoAuthors> UpdateAuthor(int id, DtoUpdateAuthors dtoUpdateAuthors)
        {
            var author = await _authorRepository.GetAuthorById(id);
            if(author == null)
            { 
                throw new Exception("Ошибка");
            }
            _mapper.Map(dtoUpdateAuthors, author); 
            var updateauthor = await _authorRepository.UpdateAuthor(author);
            return _mapper.Map<DtoAuthors>(dtoUpdateAuthors);
        }
    }
}
