using AutoMapper;
using WebApplication1.Contracts.ContractsBook;
using WebApplication1.DtoModels.DtoBook;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class BooksService:IBooksService
    {
        private IBooksRepository _booksRepository;
        private readonly IMapper _mapper;
        public BooksService(IMapper mapper, IBooksRepository booksRepository) 
        { 
            _mapper = mapper;
            _booksRepository = booksRepository;
        }

        public async Task<DtoBooks> AddBook(DtoBooksCreate dtocreatebooks)
        {
             var book = _mapper.Map<Books>(dtocreatebooks);
             book.YearPublished = DateTime.UtcNow;
             var createdtask = await _booksRepository.AddBook(book);
             return _mapper.Map<DtoBooks>(createdtask);
        }
      
        public async Task DeleteBook(int id)
        {
            await _booksRepository.DeleteBook(id);
        }

        public async Task<DtoBookResponce> GetBookById(int id)
        {
            var  book = await _booksRepository.GetBookById(id);
            return _mapper.Map<DtoBookResponce>(book);
        }

        public async Task<List<DtoBookResponce>> GetBooks()
        {
            var book = await _booksRepository.GetBooks();
            return _mapper.Map<List<DtoBookResponce>>(book);
        }

        public async Task<DtoBooks> UpdateBook(int id, DtoBooksUpdate dtoupdateBooks)
        {
            var book = await _booksRepository.GetBookById(id);
            if(book == null)
            {
                throw new Exception("Ошибка");
            }
            _mapper.Map(dtoupdateBooks, book);
            book.YearPublished = DateTime.UtcNow;
            var updatebook = await _booksRepository.UpdateBook(id, book);
            return _mapper.Map<DtoBooks>(dtoupdateBooks);          
        }
    }
}
