using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApplication1.Contracts.ContractsAuthors;
using WebApplication1.Contracts.ContractsBook;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogandBooksController : ControllerBase
    {
       private readonly IAuthorsService _authorsService;
        private readonly IBooksService _booksService;

       public CatalogandBooksController(IAuthorsService authorsService, IBooksService booksService)
       {
            _authorsService = authorsService;
            _booksService = booksService;
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
        [HttpGet]
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
    }
}
