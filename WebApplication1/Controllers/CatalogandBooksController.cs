using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApplication1.Contracts.ContractsAuthors;
using WebApplication1.Contracts.ContractsBook;
using WebApplication1.Contracts.ContractsGenres;
using WebApplication1.DtoModels.DtoBook;
using WebApplication1.ModelsFiltr;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogandBooksController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;
        private readonly IBooksService _booksService;
        private readonly IGenresService _genresService;

       public CatalogandBooksController(IAuthorsService authorsService, IBooksService booksService, IGenresService genresService)
       {
            _authorsService = authorsService;
            _booksService = booksService;
            _genresService = genresService;
       }
        
        [HttpGet("authors/{id}")]
        public async Task<IActionResult> GetAuthorsById(int id)
        {
            var author = await _authorsService.GetAuthorById(id);
            if (author == null)
            {
                return BadRequest("Автор не найден");
            }
            return Ok(author);
        }
        [HttpGet("books")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _booksService.GetBooks();
            return Ok(books);
        }
        [HttpGet("books/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _booksService.GetBookById(id);
            if (book == null)
            {
                return BadRequest("Книга не найдена");
            }
            return Ok(book);
        }
        [HttpGet("authors")]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorsService.GetAuthors();
            return Ok(authors);
        }
        [HttpGet("genres")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _genresService.GetGenres();
            return Ok(genres);
        }
        [HttpGet("booksfiltr")]
        public async Task<IActionResult> GetBooksFiltr([FromQuery] DtoBookFiltr dtoBookFiltr)
        {
            var books = await _booksService.GetBooksFiltr(dtoBookFiltr);
            return Ok(books);
        }
    }
}
